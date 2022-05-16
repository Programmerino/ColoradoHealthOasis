module App
#nowarn "3060" // Type erasure warning which at least is unimportant for browser execution

open Fable.Core
open Browser
open Elmish
open Elmish.React
open Zanaptak.TypedCssClasses
open Fable.Core.JsInterop
open Elmish.Debug
open Feliz
open Fss
open FSharpPlus

// Typed CSS classes for Semantic UI
type Semantic = CssClasses<"../deps/node_modules/fomantic-ui/dist/semantic.min.css">

// Styles
importSideEffects("mapbox-gl/dist/mapbox-gl.css")
importSideEffects("@mapbox/mapbox-gl-geocoder/dist/mapbox-gl-geocoder.css")
importSideEffects("${outDir}/../css/index.css")
importSideEffects ("fomantic-ui/dist/semantic.min.css")

let mapboxgl = MapboxGL.mapboxgl

// MAPBOX CONSTANTS
// Denver
let STARTLNG = -104.991531
let STARTLAT = 39.742043

let STARTABBREV = "PSY"
let STARTZOOM = 9

// Type generators for the data used
type OccDesc = Fable.JsonProvider.Generator<"./data/TypesOfOccupations.json">
type Namemap = Fable.JsonProvider.Generator<"./data/NameMapExample.json">

let occDescArray: OccDesc[] = importDefault "./data/TypesOfOccupations.json"
let namemapRaw: Namemap = importDefault "./data/namemap.json"

// The legend used for the three maps
let legend: string = importDefault "../img/legend.png"

let descriptionTuples =
    occDescArray
    |> Array.map(fun x -> x.Abbreviation, x.Description)

// descriptions is a map from license abbreviations to their full names/descriptions
let descriptions = descriptionTuples |> Map.ofArray

// namemap is a map from license-type/zipcode combinations to an array of licensee names
let namemap =
  namemapRaw.names
  |> Array.map(fun x -> (x.Abbrev, x.Zip), x.Names)
  |> Map.ofArray

type Model =
  {
    DropdownReady: bool // Whether the dropdown is initialized
    SliderReady: bool // Whether the slider is initialized
    ActiveTab: string
    DarkMode: bool
    heatmap: MapboxElmish.Model
    normalized: MapboxElmish.Model
    points: MapboxElmish.Model
    AllowedAbbrevs: string[]
  }

type Msg =
  | Reset
  | HeatMap of MapboxElmish.Msg
  | Normalized of MapboxElmish.Msg
  | Points of MapboxElmish.Msg
  | AddAbbrev of string
  | RemoveAbbrev of string
  | ActivateDropdown
  | ActivateTab of string
  | ToggleDark
  | Resized

// Helper function for adding dark mode in class strings where an empty string means no class is added
let condDark (x: Model) =
  if x.DarkMode then Semantic.inverted else ""

// Generates a Mapbox filter expression to include only the requested license types in the heat and indiv. provider maps
let generateFilter allowedAbbrevs =
  let conds: ResizeArray<obj option> =
    allowedAbbrevs
    |> Array.map(fun x -> Some([|"==" :> obj; [|"get"; "LicenseAbbrev"|]; x :> obj|] :> obj))
    |> ResizeArray
  ResizeArray [|Some("any" :> obj)|] ++ conds

// Generates a coloring expression for the relative map by taking the average of the normalized values of each requested license type
let generateCloroColor (allowedAbbrevs: string[]): MapboxElmish.ColorSetting =
    let dataVal = [|
      "/" :> obj
      [|
        "+" :> obj
        0
      |] ++ (allowedAbbrevs |> Array.map(fun x -> [|"get" :> obj; x|]))
      (max 1 (length allowedAbbrevs))
    |]
    {
      Expression = MapboxElmish.Interpolate (MapboxElmish.Linear, dataVal, [|(-1.0, MapboxElmish.CSS("royalblue")); (-0.5, MapboxElmish.CSS("cyan")); (0.0, MapboxElmish.CSS("lime")); (0.5, MapboxElmish.CSS("yellow")); (1.0, MapboxElmish.CSS("red"))|])
      Method = "fill-color"
    }

// Filters out features missing the requested license types (not currently used/redundant)
let generateCloroFilter (allowedAbbrevs: string[]) =
  [|
    Some("all" :> obj)
  |] ++ (allowedAbbrevs |> Array.map(fun x -> Some([|"has" :> obj; x|])))
  |> ResizeArray

let mapboxMsg msg = Cmd.batch [Cmd.ofMsg (HeatMap (msg)); Cmd.ofMsg (Points (msg)); Cmd.ofMsg (Normalized (msg))]

let abbrevsCmd abbrevs = Cmd.batch [
  Cmd.ofMsg (HeatMap (MapboxElmish.SetFilter ("heatmap", generateFilter abbrevs)))
  Cmd.ofMsg (HeatMap (MapboxElmish.SetIntensity ("heatmap", (1.0/(max 1.0 (length abbrevs |> float)))))) // Effectively averages heatmap values for each license type with a multiplier
  Cmd.ofMsg (HeatMap (MapboxElmish.SetFilter ("points", generateFilter abbrevs)))
  Cmd.ofMsg (Normalized (MapboxElmish.SetFilter ("cloropleth", generateCloroFilter abbrevs)))
  Cmd.ofMsg (Normalized (MapboxElmish.SetColor ("cloropleth", generateCloroColor abbrevs)))
  Cmd.ofMsg (Points (MapboxElmish.SetFilter ("points", generateFilter abbrevs)))
  Cmd.ofMsg (Points (MapboxElmish.SetLayerOpacity ("points", {
    Method = "circle-opacity"
    Opacity = 1.0/(length abbrevs |> float)
  }))) // Effectively averages points values by setting each's opacity to 1/n
]

let tabMap (model: Model) x =
  match x with
  | "Heatmap" -> model.heatmap.Map
  | "Relative" -> model.normalized.Map
  | "Indiv. Providers" -> model.points.Map
  | _ -> None

// Prepares and creates the popup element for a specificed map. pModel is the model for the parent (root), and mModel is the model for the MapboxElmish instance.
// snapToPoint refers to whether the popup should snap to the feature on the map or use the cursor position (only used for the indiv. provider map as of now)
// cloropleth activates special behavior for maps where license types are stored in a single element (needed for the cloropleth/relative map)
let popupPrepare cloropleth (pModel: Model) (mModel: MapboxElmish.Model) snapToPoint =
  let map = mModel.Map.Value    
  map.once((MapboxGL.Key "click"), mModel.PopupTarget.Value, fun e ->
    let e = e :?> Geojson.FeatureCollection<Geojson.Point, obj>
    let props = e.features |> Array.map(fun x -> x.properties)
    let zipcodes = props |> Array.map(fun x -> x?ZipCode) |> String.concat ", "
    let licenses =
      (if cloropleth then 
        pModel.AllowedAbbrevs
      else
        props |> Array.map(fun x -> x?LicenseAbbrev) |> Array.distinct)
      |> Array.map(fun x -> descriptions[x]) |> String.concat ", "
    let names =
      (if cloropleth then
        pModel.AllowedAbbrevs |> Array.collect(fun x -> namemap |> Map.tryFind (x, props[0]?ZipCode) |> Option.defaultValue [||])
      else
        props |> Array.collect(fun x -> namemap |> Map.tryFind(x?LicenseAbbrev, x?ZipCode) |> Option.defaultValue [||]))
      |> Array.sort

    let darkStr = if mModel.DarkMode then Semantic.inverted else ""
    let elem = Html.div [
        prop.fssWithClass $"{Semantic.ui} {Semantic.card} {darkStr}" [
          Margin.value (px 0) |> important
          MaxHeight.value (px 200)
          Overflow.auto
        ]
        prop.children [
            Html.div [
                prop.className Semantic.content
                prop.children [
                    Html.div [
                        prop.fssWithClass Semantic.header [
                          TextOverflow.ellipsis
                          Overflow.hidden
                          WhiteSpace.nowrap
                        ]
                        prop.text zipcodes
                    ]
                    Html.div [
                        prop.fssWithClass Semantic.meta [
                          TextOverflow.ellipsis
                          Overflow.hidden
                          WhiteSpace.nowrap
                        ]
                        prop.text licenses
                    ]
                    Html.div [
                        prop.fssWithClass Semantic.description [
                          TextOverflow.ellipsis
                          Overflow.hidden
                          WhiteSpace.nowrap
                        ]
                        prop.children (
                          names |> Array.map(fun x ->
                            Html.p x
                          )
                        )
                    ]
                ]
            ]
        ]
    ]

    let lngLat =
      if snapToPoint then
        let coordinates = e.features[0].geometry.coordinates
        let mutable first = coordinates[0]
        while (abs (e?lngLat?lng - first) > 180.0) do
          first <- first + (if e?lngLat?lng > first then 360.0 else -360.0)
        U4.Case3 ({|lng = first; lat = coordinates[1]|})
      else
        e?lngLat
        
    mapboxgl.Popup.Create()
      .setLngLat(lngLat)
      .setHTML(ReactDOMServer.renderToString elem)
      .addTo(mModel.Map.Value)
    |> ignore    
  )
  |> ignore
  pModel, Cmd.none

let initMap allowedAbbrevs setFilters layerName popupLayer style opacities =
  let map, cmd = MapboxElmish.init STARTLNG STARTLAT STARTZOOM
  let map =
    { map with
        Filters = if setFilters then Map.empty |> Map.add layerName (generateFilter allowedAbbrevs) else Map.empty
        Id = layerName
        Style = style
        Opacities = opacities
        PopupTarget = Some(popupLayer)
    }
  map, cmd

let init() =
  let allowedAbbrevs = [|STARTABBREV|]
  
  let heatmap, heatmapCmd =
    initMap
      allowedAbbrevs
      true
      "heatmap"
      "points"
      "mapbox://styles/programmerino/cl36gue9w001a14p2fo5ar2h1"
      Map.empty
  
  let heatmap = { heatmap with Intensity = Map.empty |> Map.add "heatmap" (1.0/(max 1.0 (length allowedAbbrevs |> float)))}

  let normalized, normalizedCmd =
    initMap
      allowedAbbrevs
      false
      "cloropleth"
      "cloropleth"
      "mapbox://styles/programmerino/cl33pt0ua000014mmvy1uqo0b"
      Map.empty

  let normalized = { normalized with Colors = Map.empty |> Map.add "cloropleth" (generateCloroColor allowedAbbrevs)}
  
  let points, pointsCmd =
    initMap
      allowedAbbrevs
      true
      "points"
      "points"
      "mapbox://styles/programmerino/cl2v688dx002515ld55au1j7x"
      (Map.empty |> Map.add "points" {
        Method = "circle-opacity"
        Opacity = 1.0/(length allowedAbbrevs |> float)
      })

  { DropdownReady = false; SliderReady = false; DarkMode = false; ActiveTab = "Heatmap"; heatmap = heatmap; points = points; normalized = normalized; AllowedAbbrevs = allowedAbbrevs}, Cmd.batch [ Cmd.map HeatMap heatmapCmd; Cmd.map Points pointsCmd; Cmd.map Normalized normalizedCmd ]

let update (msg: Msg) (model: Model) =
    match msg with
    | Reset -> init()
    // These catch MapboxElmish preclick events to prepare and add popup dialogues to the map while still being able to access parent model information
    | HeatMap (MapboxElmish.Preclick) -> popupPrepare false model model.heatmap false
    | Points (MapboxElmish.Preclick) -> popupPrepare false model model.points true
    | Normalized (MapboxElmish.Preclick) -> popupPrepare true model model.normalized false
    | HeatMap msg' ->
      let res, cmd = MapboxElmish.update msg' model.heatmap

      { model with
          heatmap = res
      }, Cmd.map HeatMap cmd
    | Points msg' ->
      let res, cmd = MapboxElmish.update msg' model.points

      { model with
          points = res
      }, Cmd.map Points cmd
    | Normalized msg' ->
      let res, cmd = MapboxElmish.update msg' model.normalized

      { model with
          normalized = res
      }, Cmd.map Normalized cmd
    | AddAbbrev abbr ->
      if (not (Array.contains abbr model.AllowedAbbrevs)) then
        let newAllowedAbbrevs = model.AllowedAbbrevs ++ [|abbr|]
        { model with
            AllowedAbbrevs = newAllowedAbbrevs
        }, abbrevsCmd newAllowedAbbrevs
      else
        model, Cmd.none
    | RemoveAbbrev abbr ->
      if (Array.contains abbr model.AllowedAbbrevs) then
        let newAllowedAbbrevs = Array.filter(fun x -> x <> abbr) model.AllowedAbbrevs
        { model with
            AllowedAbbrevs = newAllowedAbbrevs
        }, abbrevsCmd newAllowedAbbrevs
      else
        model, Cmd.none
    | ActivateDropdown ->
      { model with
          DropdownReady = true
      }, Cmd.none
    | ActivateTab x ->
      let cmd = match (tabMap model x) with
                | Some x -> Cmd.OfPromise.perform (fun _ -> Promise.sleep 50 |> Promise.map (fun _ -> x.resize() |> ignore)) () (fun _ -> Resized) // Used to resize the map after switching tabs
                | None -> Cmd.none
      { model with
          ActiveTab = x
      }, cmd
    | ToggleDark ->
        let model = { model with DarkMode = (not model.DarkMode) }
        model, mapboxMsg (MapboxElmish.SetDarkMode model.DarkMode)
    | Resized -> model, Cmd.none

// descriptionToElement generates an element from abbreviation-fullname pairs (abbreviation is used as an internal attribute)
let descriptionToElement (x: string * string) =
  Html.div [
      prop.className Semantic.item
      Interop.mkAttr "data-value" (fst x)
      prop.children [
          Html.text (snd x)
      ]
  ]

let options =
  descriptionTuples
  |> Array.map(descriptionToElement)

let onChange dispatch msg newValue _ newText _ =
  match newValue with
  | Some(x) -> dispatch (msg(x |> string))
  | None -> printfn $"{newText} had no associated value!"

// Tooltips for each tab
let tabDescriptions =
  Map.empty
  |> Map.add
    "Heatmap"
    ("bottom center", "Once you have selected the type(s) of healthcare providers for your search,\n\
     a heat map representing 'hot' (red) and 'cold' (green) zones will\n\
     automatically be mapped. Red zones are desirable regions (health care oasis)\n\
     and green zones represent undesirable regions (health care deserts).")
  |> Map.add
     "Relative"
     ("bottom center", "The relative map takes into account the population density of the regions.\n\
      In other words, the relative map provides 'hot' and 'cold' regions that takes\n\
      into account the population density of the regions.\n")
  |> Map.add
     "Indiv. Providers"
     ("bottom right", "The Indiv. Providers map represents the geographical\n\
      location of the selected healthcare Providers")

let tabMenu dispatch model tabs =
  Html.div [
      prop.id "tabs"
      prop.children (
          Html.div [
              prop.classes [ Semantic.ui; condDark model; Semantic.secondary; Semantic.menu ]
              prop.children (
                tabs |> List.map(fun (name: string) ->
                  let position, tooltip = tabDescriptions[name]
                  Html.a [
                      prop.classes [ "item"; if name = model.ActiveTab then "active" ]
                      Interop.mkAttr "data-tab" name
                      Interop.mkAttr "data-tooltip" tooltip
                      Interop.mkAttr "data-position" position
                      if model.DarkMode then Interop.mkAttr "data-inverted" ""
                      prop.text name
                      prop.onClick (fun _ -> dispatch (ActivateTab name))
                  ]
                )
              )
          ]
      )
  ]

let tabContainer model tabs activeName =
  Html.div [
      prop.fss [
        Height.value (pct 100)
      ]
      prop.children (
        tabs |> List.map(fun (name, elem) ->
          let activeString = if name = activeName then Semantic.active else ""
          Html.div [
              prop.fssWithClass $"{Semantic.ui} {activeString} {condDark model} {Semantic.tab} {Semantic.segment}" [
                Height.value (pct 100)
                MarginBottom.value (px 0) |> important
                MarginTop.value (px 0) |> important
              ]
              Interop.mkAttr "data-tab" name
              prop.text $" {name} "
              prop.children [
                  elem
              ]
          ]
        )
      )
  ]

// Contains the title and dark mode toggle
let topBar model dispatch =
  Html.div [
      prop.classes [ Semantic.ui; Semantic.top; Semantic.menu; condDark model ]
      prop.children [
        Html.h1 [
          prop.fssWithClass $"{Semantic.ui} {Semantic.middle} {Semantic.header} {Semantic.item} {Semantic.huge} myHeader" [
            PaddingBottom.value (px 20) |> important
            FontFamily.value "Noto Serif Display, ui-serif, Georgia" |> important
          ]
          prop.text "Colorado Health Oasis"
        ]
        Html.div [
            prop.classes [ Semantic.ui; Semantic.right; Semantic.item; Semantic.animated; Semantic.labeled; Semantic.icon; Semantic.button ]
            prop.id "theme-chooser"
            prop.onClick (fun _ -> dispatch ToggleDark)
            prop.children [
                Html.div [
                    prop.classes [
                      if model.DarkMode then Semantic.hidden else Semantic.visible
                      Semantic.content
                    ]
                    prop.children [
                        Html.i [
                            prop.classes [ Semantic.sun; Semantic.icon ]
                        ]
                        Html.text " Light"
                    ]
                ]
                Html.div [
                    prop.classes [
                      if model.DarkMode then Semantic.visible else Semantic.hidden
                      Semantic.content
                    ]
                    prop.children [
                        Html.i [
                            prop.classes [ Semantic.moon; Semantic.icon ]
                        ]
                        Html.text " Dark"
                    ]
                ]
            ]
        ]
    ]
]

let mapboxContainer legendsrc map msg dispatch =
  let legend =
    match legendsrc with
    | Some x ->
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
                          prop.src x
                      ]
                  ]
              ]
          ]
      ]
    | None -> Html.div []
  Html.div [
    prop.fss [
      Height.value (pct 100)
      FlexGrow.value 1
      FlexShrink.value 1
      FlexBasis.auto
      Position.relative
    ]
    prop.children [
      MapboxElmish.view map (msg >> dispatch)
      legend
    ]
  ]

let view_ (model: Model) dispatch =
    Html.main [
      prop.fssWithClass $"{Semantic.ui} {Semantic.container} {Semantic.fluid} main-container {condDark model}" [
        if model.DarkMode then BackgroundColor.hex "#232B32"
      ]
      prop.children [
        topBar model dispatch;
        Html.div [
          prop.fss [
            Display.flex
            FlexDirection.row
            FlexWrap.wrap
            JustifyContent.spaceEvenly
            AlignContent.normal
            AlignItems.center
            // MarginLeft.value (px 20)
            // MarginRight.value (px 20)
            Custom "column-gap" "20px"
          ]
          prop.children [
            Html.div [
                prop.fssWithClass $"{Semantic.ui} {Semantic.fluid} {condDark model} {Semantic.search} {Semantic.selection} {Semantic.multiple} {Semantic.dropdown}" [
                  Display.block
                  Order.value 0
                  FlexGrow.value 1
                  FlexShrink.value 1
                  FlexBasis.maxContent
                ];
                prop.ref (fun x ->
                          if (not model.DropdownReady) then
                            window?jQuery("#dropdown")?dropdown(!!{|
                              action = U2.Case2 "activate"
                              onAdd = onChange dispatch AddAbbrev
                              onRemove = onChange dispatch RemoveAbbrev
                            |})
                            window?jQuery("#dropdown")?dropdown("set selected", STARTABBREV);
                            printfn "Activate"
                            dispatch (ActivateDropdown)
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
                        prop.children options
                    ]
                ]
            ];
            Html.div [
              prop.fss [
                BorderWidth.value (px 1)
                BorderStyle.solid
                BorderColor.rgba 34 36 38 0.15
                BorderRadius.value (rem 0.28571429)
                Padding.value (px 3)
                Display.block
                Order.value 0
                FlexGrow.value 0
                FlexShrink.value 1
                FlexBasis.auto
              ]
              prop.children [
                tabMenu dispatch model ["Heatmap"; "Relative"; "Indiv. Providers"]
              ]
            ];
          ]
        ]
        Html.div [
          prop.classes [
            Semantic.ui;
            Semantic.divider;
          ]
        ];
        tabContainer model [
          ("Heatmap", mapboxContainer (Some legend) model.heatmap HeatMap dispatch)
          ("Relative", mapboxContainer (Some legend) model.normalized Normalized dispatch)
          ("Indiv. Providers", mapboxContainer (Some legend)  model.points Points dispatch)
          ] model.ActiveTab
      ]
    ]

let eqModel (x: Model) = (x.DropdownReady, x.ActiveTab, x.DarkMode, x.AllowedAbbrevs)

let view = lazyView2With (fun x y -> eqModel x = eqModel y) view_

let run () =
  Program.mkProgram init update view
  |> Program.withReactBatched "elmish-app"
  |> Program.withConsoleTrace
  |> Program.run

run()