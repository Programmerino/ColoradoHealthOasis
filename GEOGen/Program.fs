module GEOGen

open FSharpPlus
open FSharp.Data
open System
open Helpers.Extensions
open GeoJSON.Net.Feature
open GeoJSON.Net.Geometry
open Newtonsoft.Json
open System.IO
open System.Text.Json
open System.Text.Json.Serialization
open FSharp.Stats
open FSharp.Stats.Signal

type Licenses =
    CsvProvider<"./data/Professional_and_Occupational_Licenses_in_Colorado.csv", HasHeaders=true, AssumeMissingValues=true, PreferOptionals=true>

type Normalized = CsvProvider<"./data/zip_data.csv", HasHeaders=true, PreferOptionals=true, IgnoreErrors=true>
type Population = CsvProvider<"./data/populationData.csv", HasHeaders=true, PreferOptionals=true, SkipRows=1>

type SurfacePop =
    CsvProvider<"./data/sampleSurfacePop.csv", Schema="zipcode (string), population, squaremeters", HasHeaders=true, PreferOptionals=true>

type OccDesc = JsonProvider<"./data/TypesOfOccupations.json", InferTypesFromValues=true>

let licenses =
    Licenses.Load("../../../data/Professional_and_Occupational_Licenses_in_Colorado.csv")

let normalized = Normalized.Load("../../../data/zip_data.csv")
let populationRaw = Population.Load("../../../data/populationData.csv")
let descriptionArray = OccDesc.Load("../../../data/TypesOfOccupations.json")

let zipcodesRaw =
    JsonConvert.DeserializeObject<FeatureCollection>(File.ReadAllText("./data/zip-code-tabulation-area.json"))

let zipcodesCO =
    zipcodesRaw.Features
    |> Seq.filter (fun x -> let zip = x.Properties["ZCTA5CE20"] :?> string |> int in (zip >= 80001 && zip <= 81658)) // Filters out zipcodes outside the range of CO
    |> ResizeArray
    |> FeatureCollection

// populationMap maps zip codes to their corresponding population
let populationMap: Map<string, int> =
    populationRaw.Rows
    |> Seq.map (fun x -> x.``Geographic Area Name`` |> String.skip 6, x.``Estimate!!Total``) // Removes "ZCTA5 " from start of string
    |> Map.ofSeq

// normMap maps the combination of a zip code and license type to the normalized value computed elsewhere (i.e. the number of people with the license / total population / square meters of the zip code)
let normMap =
    normalized.Rows
    |> Seq.map (fun x -> (x.Zip, x.License_type), x.Norm_value)
    |> Seq.distinct
    |> Map.ofSeq

type Coords =
    | Poly of Collections.ObjectModel.ReadOnlyCollection<Polygon>
    | LineString of Collections.ObjectModel.ReadOnlyCollection<LineString>

// Converts polygons and multipolygons into circles (point-radius pair) by finding the center of the polygon and using the average distance between sides for the radius
let coordinatesToCircle (x: Coords) =
    monad {
        let coords =
            match x with
            | Poly x -> x |> Seq.collect (fun x -> x.Coordinates)
            | LineString x -> x
            |> Seq.collect (fun x -> x.Coordinates)

        let minFloat = Option.protect Seq.max >> Option.map float
        let maxFloat = Option.protect Seq.min >> Option.map float

        let xs = coords |> Seq.map (fun x -> x.Longitude)
        let ys = coords |> Seq.map (fun x -> x.Latitude)
        let! maxx = maxFloat xs
        let! minx = minFloat xs
        let! maxy = maxFloat ys
        let! miny = minFloat ys
        Point(Position((miny + maxy) / 2.0, (minx + maxx) / 2.0)), ((maxx - minx) / 2.0 + (maxy - miny) / 2.0) / 2.0
    }
    |> Option.log $"{x} could not be converted into a circle!"

// zipcodes is a map between zipcodes and GeoJSON polygons that can be mapped
let zipcodes =
    zipcodesCO.Features
    |> Seq.toArray
    |> Array.map (fun x -> x.Properties["ZCTA5CE20"] :?> string, x)
    |> Map.ofArray

// getZip is a wrapper for Map.tryFind which returns an option with logging
let getZip x =
    zipcodes
    |> Map.tryFind x
    |> Option.log $"Could not find information for {x}"

// descriptions is a map between license-type abbreviations and their full names/descriptions
let descriptions =
    descriptionArray
    |> Array.map (fun x -> x.Abbreviation, x.Description)
    |> Map.ofArray

// normalizationPass accepts structures which can yield a float and normalizes their data in groups determined by the keyFn. The normalized value is returned back with each element
let inline normalizationPass (getter: 'a -> float) (keyFn: 'a -> 'b) (data: seq<'a>) : seq<'a * float> =
    data
    |> Seq.groupBy keyFn
    |> Seq.map snd
    |> Seq.bind (fun normGroup ->
        normGroup
        |> Seq.map getter
        |> Vector.ofSeq
        |> Normalization.zScoreTransformPopulation
        |> Seq.zip normGroup)

// Generates and writes all the data used by other parts of the program
let geoData () =
    // Preprocessing used to generate several data files
    let pre =
        licenses.Rows
        |> Seq.filter (fun x ->
            (x.LicenseStatusDescription
             |> Option.defaultValue "") = "Active")
        |> Seq.filter (fun x -> (x.State |> Option.defaultValue "CO") = "CO")
        |> Seq.filter (fun x -> // Filters out licenses without written fullnames (these are not directed towards healthcare)
            x.LicensePrefix
            |> Option.map (fun x -> descriptions |> Map.tryFind x)
            |> Option.map (konst true)
            |> Option.defaultValue false)
        |> Seq.map (fun x ->
            monad {
                let! license = x.LicensePrefix
                let! zipCode = x.MailZipCode
                let! first = x.FirstName
                let! second = x.LastName
                license, zipCode, first, second
            })
        |> Seq.choose id

    let licensesCoords =
        pre
        |> Seq.groupBy (fun (x, y, _, _) -> x, y)
        |> Seq.map (fun (x, y) -> x, y |> Seq.map (fun (_, _, f, l) -> f, l))
        |> Seq.map (fun ((license, zipCode), licensees) ->
            monad {
                let feature = lazy (getZip zipCode)
                license, feature, licensees
            })
        |> Seq.choose id

    // Provides data for the "Relative" map
    let normalized =
        Seq.allPairs
            (descriptionArray
             |> Array.map (fun x -> x.Abbreviation))
            (zipcodesCO.Features
             |> Seq.map (fun x -> x.Properties["ZCTA5CE20"] :?> string)) // Provides every license-type/zipcode combination
        |> Seq.map (fun (abbrev, zip) -> {| Abbrev = abbrev; Zip = zip |})
        |> Seq.map (fun x ->
            let zipInt = int x.Zip // Convert zipcode to int to deal with data generated elsewhere (shouldn't convert ints to strings because "80520" is represented as 8052 in integer form)

            let nVal =
                Map.tryFind (zipInt, x.Abbrev) normMap
                |> Option.defaultValue 0

            {| Abbrev = x.Abbrev
               Zip = x.Zip
               IntZip = zipInt
               initNVal = nVal |})
        |> normalizationPass (fun x -> x.initNVal) (fun x -> x.Abbrev)
        |> Seq.groupBy (fun (x, _) -> x.Zip)
        |> Seq.map (fun (zip, licenses) ->
            monad {
                let! feature = getZip zip

                let properties =
                    licenses
                    |> Seq.fold
                        (fun acc (x, nVal) ->
                            acc
                            |> Map.add x.Abbrev (System.Math.Round(nVal, 2) |> float32 :> obj)) // Rounds the float to save space (Mapbox limitations)
                        Map.empty
                    |> Map.add "ZipCode" zip

                Feature(feature.Geometry, properties)
            })
        |> Seq.choose id
        |> ResizeArray

    // Used by the heatmap and individual providers maps (the heatmap currently uses a non-normalized version of this data which was generated previously)
    let features =
        licensesCoords
        |> Seq.map (fun (license, feature, licensees) ->
            monad {
                let! feature = feature.Force()
                let zip = feature.Properties["ZCTA5CE20"]

                let coords =
                    match feature.Geometry with
                    | :? Polygon as poly -> LineString poly.Coordinates
                    | :? MultiPolygon as poly -> Poly poly.Coordinates
                    | _ as e -> failwith $"Unexpected feature type {e.GetType()}"

                let! (geo, radius) =
                    coords
                    |> coordinatesToCircle
                    |> Option.log $"{zip} had a geometry which could not be converted into a point!"

                return
                    (geo,
                     {| LicenseAbbrev = license
                        Radius = radius * 10.0
                        Count = length licensees
                        ZipCode = zip |})
            })
        |> Seq.choose id
        |> normalizationPass (fun (_, props) -> props.Count) (fun (_, props) -> props.LicenseAbbrev)
        |> Seq.map (fun ((obj, props), norm) ->
            Feature(
                obj,
                {| LicenseAbbrev = props.LicenseAbbrev
                   Radius = props.Radius
                   NormCount = System.Math.Round(norm, 2) |> float32
                   ZipCode = props.ZipCode |}
            ))
        |> ResizeArray

    // Generates data to be used elsewhere containing the population and area of each CO zipcode
    let surfacePop =
        zipcodesCO.Features
        |> Seq.map (fun x -> x.Properties["ZCTA5CE20"] :?> string, x.Properties["ALAND20"] :?> int64)
        |> Seq.map (fun (zip, area) ->
            monad {
                let! pop =
                    populationMap
                    |> Map.tryFind zip
                    |> Option.log $"{zip} had no population data!"

                SurfacePop.Row(zip, pop, area |> int)
            })
        |> Seq.choose id

    // Generates a mapping between zipcode/license-type combinations and the licensee names associated (used for the click popups for all maps). This cannot be embedded in the GeoJSON
    // due to space limitations
    let mapToNames =
        licensesCoords
        |> Seq.map (fun (license, geometry, licensees) ->
            monad {
                let! feature = geometry.Force()

                {| Zip = feature.Properties["ZCTA5CE20"]
                   Abbrev = license
                   Names =
                    (licensees
                     |> Seq.toList
                     |> Seq.map (fun (x, y) -> $"{x} {y}")
                     |> Seq.sort
                     |> Seq.distinct) |}
            })
        |> Seq.choose id

    GC.Collect()

    File.WriteAllText("surfacePop.csv", (new SurfacePop(surfacePop)).SaveToString())
    File.WriteAllText("heatmapAndPoints.geojson", JsonConvert.SerializeObject(FeatureCollection(features)))
    File.WriteAllText("normalized.geojson", JsonConvert.SerializeObject(FeatureCollection(normalized)))

    // Separate JSON serializer to support anonymous records
    let options = JsonSerializerOptions()
    options.Converters.Add(JsonFSharpConverter())

    File.WriteAllText("namemap.json", JsonSerializer.Serialize({| names = mapToNames |}, options))

[<EntryPoint>]
let main argv =
    geoData ()

    0
