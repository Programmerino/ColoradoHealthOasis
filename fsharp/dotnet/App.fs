module App

open Fable.Core
open Browser
open Elmish
open Elmish.React
open Zanaptak.TypedCssClasses
open Fable.Core.JsInterop
open Elmish.Debug
open Feliz
open Elmish.HMR
open Fss
open FSharpPlus.Operators

type Semantic = CssClasses<"../deps/node_modules/semantic-ui-css/semantic.min.css">
importSideEffects("mapbox-gl/dist/mapbox-gl.css")
importSideEffects("@mapbox/mapbox-gl-geocoder/dist/mapbox-gl-geocoder.css")
importSideEffects("${outDir}/../css/index.css")
importSideEffects ("semantic-ui-css/semantic.min.css")

let accessToken = "pk.eyJ1IjoicHJvZ3JhbW1lcmlubyIsImEiOiJjbDE4NWl4Z2ozN2FyM2lxaGoxM3lhcG4xIn0.Lk7bkqzIC8gLllThJCgW9A";

let mapboxgl = MapboxGL.mapboxgl

// CONSTANTS
// Denver
let STARTLNG = -104.991531
let STARTLAT = 39.742043

let STARTABBREV = "PSY"
let STARTZOOM = 9

module MapboxElmish =
  type Model = {
    Map: MapboxGL.Mapboxgl.Map option
    Lng: float
    Lat: float
    Zoom: float
    AllowedAbbrevs: string[]
  }

  let generateFilter model =
    let conds: ResizeArray<obj option> =
      model.AllowedAbbrevs
      |> Array.map(fun x -> Some([|"==" :> obj; [|"get"; "LicenseAbbrev"|]; x|] :> obj))
      |> ResizeArray
    U2.Case1(ResizeArray [|Some("any" :> obj)|] ++ conds)
  
  let setFilter (map: MapboxGL.Mapboxgl.Map) model =
    map.setFilter("heatmap", generateFilter model) |> ignore

  let init() = { Map = None; Lng = STARTLNG; Lat = STARTLAT; Zoom = STARTZOOM; AllowedAbbrevs = [|STARTABBREV|] }, Cmd.none

  type Msg =
    | MountMap of MapboxGL.Mapboxgl.Map
    | SetLong of float
    | SetLat of float
    | SetZoom of float
    | SetAllowedAbbrevs of string[]

  let update msg model =
    match msg with
    | MountMap map -> { model with Map = Some map }, Cmd.none
    | SetLong lng -> { model with Lng = lng }, Cmd.none
    | SetLat lat -> { model with Lat = lat }, Cmd.none
    | SetZoom zoom -> { model with Zoom = zoom }, Cmd.none
    | SetAllowedAbbrevs abbrs ->
        let newModel = { model with AllowedAbbrevs = abbrs }
        match model.Map with
        | Some(x) -> setFilter x newModel
        | None -> ()
        
        newModel, Cmd.none

  let view' model dispatch =
    Html.div [  
        prop.id "mapid"
        prop.fss [
          Height.value (pct 100)
        ]
        prop.ref (fun x ->
          if x <> null then
            match model.Map with
            | None ->
                let opts = jsOptions<MapboxGL.Mapboxgl.MapboxOptions> (fun x ->
                  x.container <- U2.Case1 "mapid"
                  x.center <- Some (U4.Case1(model.Lng, model.Lat))
                  x.zoom <- Some model.Zoom
                  x.style <- Some(U2.Case2 "mapbox://styles/programmerino/cl185mrbw002a14lmslgwvtt6")
                  x.accessToken <- Some accessToken
                )
                let map = mapboxgl.Map.Create(opts)

                let geoOptions = jsOptions<MapboxGeocoder.MapboxGeocoder.GeocoderOptions> (fun x ->
                  x.accessToken <- accessToken
                  x.mapboxgl <- Some map
                )

                map.addControl(
                  U2.Case2(MapboxGeocoder.mapboxGeocoder.Create(geoOptions))
                ) |> ignore

                map.on("render", fun _ -> map.resize() |> ignore) |> ignore

                if map.isStyleLoaded()
                  then setFilter map model
                  else map.on("load", fun _ -> setFilter map model) |> ignore

                MountMap map |> dispatch
            | Some(x) ->
                if x.isStyleLoaded() then setFilter x model
        )
      ]
  let view = lazyView2With (fun _ _ -> true) view'

type OccDesc = Fable.JsonProvider.Generator<"./data/TypesOfOccupations.json">
type CatMembership = Fable.JsonProvider.Generator<"./data/Categories.json">

let occDescArray: OccDesc[] = importDefault "./data/TypesOfOccupations.json"
let catMembershipArray: CatMembership[] = importDefault "./data/Categories.json"

let legend: string = importDefault "../img/legend.png"

let descriptionTuples =
    occDescArray
    |> Array.map(fun x -> x.Abbreviation, x.Description)

let descriptions = descriptionTuples |> Map.ofArray

let categories =
    catMembershipArray
    |> Array.groupBy(fun x -> x.``Category Name``)
    |> Map.ofArray

let licenseToCategory license =
    catMembershipArray
    |> Array.find(fun x -> x.Member = license)
    |> (fun x -> x.``Category Name``)

type Model = 
  {
    DropdownReady: bool
    map: MapboxElmish.Model
    AllowedAbbrevs: string[]
  }

type Msg =
| Reset
| Map of MapboxElmish.Msg
| AddAbbrev of string
| RemoveAbbrev of string
| ActivateDropdown

let init() =
  let map, mapCmd = MapboxElmish.init()
  { DropdownReady = false; map = map; AllowedAbbrevs = [|STARTABBREV|]}, Cmd.batch [ Cmd.map Map mapCmd ]

let update (msg: Msg) (model: Model) =
    match msg with
    | Reset -> init()
    | Map msg' ->
      let res, cmd = MapboxElmish.update msg' model.map

      { model with
          map = res
      }, Cmd.map Map cmd
    | AddAbbrev abbr ->
      if (not (Array.contains abbr model.AllowedAbbrevs)) then
        let newAllowedAbbrevs = model.AllowedAbbrevs ++ [|abbr|]
        { model with
            AllowedAbbrevs = newAllowedAbbrevs
        }, Cmd.ofMsg (Map (MapboxElmish.SetAllowedAbbrevs newAllowedAbbrevs))
      else
        model, Cmd.none
    | RemoveAbbrev abbr ->
      if (Array.contains abbr model.AllowedAbbrevs) then
        let newAllowedAbbrevs = Array.filter(fun x -> x <> abbr) model.AllowedAbbrevs
        { model with
            AllowedAbbrevs = newAllowedAbbrevs
        }, Cmd.ofMsg (Map (MapboxElmish.SetAllowedAbbrevs newAllowedAbbrevs))
      else
        model, Cmd.none
    | ActivateDropdown ->
      { model with
          DropdownReady = true
      }, Cmd.none

let descriptionToElement (x: string * string) =
  Html.div [
      prop.className Semantic.item
      Interop.mkAttr "data-value" (fst x)
      prop.children [
          Html.text (snd x)
      ]
  ]

let generateOptions model dispatch =
  descriptionTuples
  |> Array.map(descriptionToElement)

let onChange dispatch msg newValue _ newText _ =
  match newValue with
  | Some(x) -> dispatch (msg(x |> string))
  | None -> printfn $"{newText} had no associated value!"


let view' (model: Model) dispatch =
    Html.main [
      prop.classes [
        Semantic.ui
        Semantic.container
        "main-container"
      ]
      prop.children [
        Html.div [
          prop.fss [
            Display.flex
            FlexDirection.column
            AlignItems.center
          ]
          prop.children [
            Html.h1 [
              prop.classes [
                Semantic.ui
                Semantic.header
                Semantic.huge
                "myHeader"
              ]
              prop.text "Colorado Health Oasis"
            ]
          ]
        ];
        Html.div [
            prop.classes [ Semantic.ui; Semantic.fluid; Semantic.search; Semantic.selection; Semantic.multiple; Semantic.dropdown]
            prop.ref (fun x ->
                      if x = null then
                        if (not model.DropdownReady) then
                          window?jQuery("#dropdown")?dropdown(!!{|
                            action = U2.Case2 "activate"
                            onAdd = onChange dispatch AddAbbrev
                            onRemove = onChange dispatch RemoveAbbrev
                          |})
                          window?jQuery("#dropdown")?dropdown("set selected", STARTABBREV);
                          dispatch (ActivateDropdown)
                      else
                        ()
                    )
            prop.id "dropdown"
            prop.children [
                Html.input [
                    prop.type' "hidden"
                    prop.name "filter"
                ]
                Html.i [
                    prop.classes [ Semantic.dropdown; Semantic.icon ]
                ]
                Html.div [
                    prop.classes [ Semantic.``default``; Semantic.text ]
                    prop.text "Filter by license type"
                ]
                Html.div [
                    prop.className Semantic.menu
                    prop.children (generateOptions model dispatch)
                ]
            ]
        ];
        Html.div [
          prop.classes [
            Semantic.ui;
            Semantic.divider;
          ]
        ];
        Html.div [
          prop.fss [
            FlexGrow.value 1
            FlexShrink.value 1
            FlexBasis.auto
            Position.relative
          ]
          prop.children [
            MapboxElmish.view model.map (Map >> dispatch)
            Html.div [
                prop.classes [
                  Semantic.ui;
                  Semantic.card;
                  "legend"
                ]
                prop.children [
                    Html.div [
                        prop.className "content"
                        prop.children [
                            Html.img [
                                prop.src legend
                            ]
                        ]
                    ]
                ]
            ]
          ]
        ];
      ]
    ]

let view = lazyView2 view'

let run () =
  Program.mkProgram init update view
  |> Program.withReactBatched "elmish-app"
  |> Program.withConsoleTrace
  |> Program.run

run()