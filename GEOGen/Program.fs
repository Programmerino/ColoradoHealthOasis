module GEOGen

open FSharpPlus
open FSharp.Data
open System
open Helpers
open GeoJSON.Net
open GeoJSON.Net.Feature
open GeoJSON.Net.Geometry
open Newtonsoft.Json

type Licenses = CsvProvider<"./data/Professional_and_Occupational_Licenses_in_Colorado.csv", HasHeaders=true, AssumeMissingValues=true, PreferOptionals=true>
type ZipCode = JsonProvider<"./data/sample-zips.json", InferTypesFromValues=false>
type OccDesc = JsonProvider<"./data/TypesOfOccupations.json", InferTypesFromValues=true>
type CatMembership = JsonProvider<"./data/Categories.json", InferTypesFromValues=true>

let licenses = Licenses.Load(".,/../../../../data/Professional_and_Occupational_Licenses_in_Colorado.csv")
let zipcodeRaw = ZipCode.Load(".,/../../../../data/zipcodes.geojson")
let descriptionArray = OccDesc.Load(".,/../../../../data/TypesOfOccupations.json")
let categoryArray = CatMembership.Load(".,/../../../../data/Categories.json")

let averageRadius = 0.13519668553901884

let coordinatesToCircle (x: ZipCode.NumbersOrArrays array array) =
    monad {
        let coords = x
                                                                |> Array.collect id
                                                                |> Array.collect (fun x -> if (length x.Arrays = 0) then [|x.Numbers|] else x.Arrays)
                                                                |> Array.map(fun x -> (x[0], x[1]))
        
        let xs = coords |> Array.map(fst)
        let ys = coords |> Array.map(snd)
        let! maxx = xs |> Option.protect Array.max |> Option.map float
        let! minx = xs |> Option.protect Array.min |> Option.map float
        let! maxy = ys |> Option.protect Array.max |> Option.map float
        let! miny = ys |> Option.protect Array.min |> Option.map float
        Point(Position((miny + maxy) / 2.0, (minx + maxx) / 2.0)), ((maxx - minx) / 2.0 + (maxy - miny) / 2.0) / 2.0
    }

let zipcodes =
    zipcodeRaw.Features
    |> Array.map(fun x -> x.Properties.Zcta5ce10, lazy (
        x.Geometry.Coordinates |> coordinatesToCircle |> Option.map(fun y -> y, x.Properties.Zcta5ce10)
    ))
    |> Map.ofArray

let getZip x =
    zipcodes
    |> Map.tryFind x
    |> Option.bind(fun x -> x.Force())

let descriptions =
    descriptionArray
    |> Array.map(fun x -> x.Abbreviation, x.Description)
    |> Map.ofArray

let categories =
    categoryArray
    |> Array.groupBy(fun x -> x.CategoryName)

let licenseToCategory license =
    categoryArray
    |> Array.find(fun x -> x.Member = license)
    |> (fun x -> x.CategoryName)

module Map =
    let inline tryFindRev map x = Map.tryFind x map

let geoData =
    let licensesCoords =
        licenses.Rows
        |> Seq.filter(fun x -> (x.LicenseStatusDescription |> Option.defaultValue "") = "Active")
        |> Seq.filter(fun x -> (x.State |> Option.defaultValue "CO") = "CO")
        |> Seq.map(fun x -> monad {
            let! license = x.LicensePrefix
            let! zipCode = x.MailZipCode
            license, zipCode
        })
        |> Seq.choose id
        |> Seq.groupBy id
        |> Seq.map(fun (x, children) -> x, (length children))
        |> Seq.map(fun ((license, zipCode), count) -> monad {
            let geometry = lazy(getZip zipCode)
            (license, geometry), count
        })
        |> Seq.choose id

    let features =
        licensesCoords
        |> Seq.map (fun ((license, geometry), count) ->
            monad {
                let! (geo, radius), zipCode = geometry.Force()
                Feature(geo, {|
                    LicenseAbbrev = license
                    Radius = radius * 10.0
                    Count = count
                    ZipCode = zipCode
                |})
            }
        )
        |> Seq.choose id
        |> ResizeArray

    GC.Collect()

    JsonConvert.SerializeObject(FeatureCollection(features))

[<EntryPoint>]
let main argv =
    printfn "%s" geoData

    0 // return an integer exit code
