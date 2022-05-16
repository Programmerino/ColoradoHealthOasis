module MapboxElmish

open Fable.Core
open FSharpPlus
open Elmish
open Browser
open Elmish.React
open Feliz
open Fss
open Fable.Core.JsInterop
open MapboxGL

// Will be passed as a parameter once converted into a library
let accessToken =
    "pk.eyJ1IjoicHJvZ3JhbW1lcmlubyIsImEiOiJjbDE4NWl4Z2ozN2FyM2lxaGoxM3lhcG4xIn0.Lk7bkqzIC8gLllThJCgW9A"


type Opacity = { Method: string; Opacity: float }

type InterpolateMethod = | Linear

let stringifyIntMethod (x: InterpolateMethod) =
    match x with
    | Linear -> "linear"

type Color =
    | HSL of int * int * int
    | CSS of string

let stringifyColor (x: Color) =
    match x with
    | HSL (h, s, l) -> $"hsl({h}, {s}%%, {l}%%)"
    | CSS (h) -> h

type Expression = obj []

type ColorExpression = Interpolate of InterpolateMethod * Expression * (float * Color) []

type ColorSetting =
    { Method: string
      Expression: ColorExpression }

type PopupSettings =
    { Layer: string // The layer clicks should be listened on
      Action: Model -> obj -> MapboxGL.Mapboxgl.Map -> Unit } // The action to perform when a click is received (obj is the event object returned by the Mapbox API)

and Model =
    { Map: MapboxGL.Mapboxgl.Map option
      Lng: float
      Lat: float
      Zoom: float
      Id: string // The HTML id of the map
      Style: string // The Mapbox style string for the map
      Filters: Map<string, ResizeArray<obj option>> // Applies filter expressions to layers in the map
      DarkMode: bool
      Opacities: Map<string, Opacity> // Applies opacity expressions to layers in the map
      Colors: Map<string, ColorSetting> // Applies color expressions to layers in the map
      PopupTarget: string option // The layer to listen for clicks on
      Intensity: Map<string, float> } // Applies intensity expressions to layers in the map

let setFilter (map: MapboxGL.Mapboxgl.Map) layer filter =
    map.setFilter (layer, U2.Case1(filter)) |> ignore

let setFilters (map: MapboxGL.Mapboxgl.Map) model =
    model.Filters
    |> Map.toArray
    |> Array.iter (fun (layer, filter) -> setFilter map layer filter)

let setColor (map: MapboxGL.Mapboxgl.Map) layer (color: ColorSetting) =
    let property =
        match color.Expression with
        | Interpolate (method, propName, pairs) ->
            ([| "interpolate" :> obj
                [| stringifyIntMethod method |]
                propName |]
             ++ (pairs
                 |> Array.collect (fun (x, y) -> [| x :> obj; stringifyColor y |])))

    map.setPaintProperty (layer, color.Method, Some(property))
    |> ignore

let setColors (map: MapboxGL.Mapboxgl.Map) model =
    model.Colors
    |> Map.toArray
    |> Array.iter (fun (name, color) -> setColor map name color)

// setOpacity sets the opacity of a layer with a float and opacityMethod (dependent on the layer type)
let setOpacity (map: MapboxGL.Mapboxgl.Map) layer opacityMethod (opacity: float) =
    map.setPaintProperty (layer, opacityMethod, Some(opacity))
    |> ignore

let setOpacities (map: MapboxGL.Mapboxgl.Map) model =
    model.Opacities
    |> Map.toArray
    |> Array.iter (fun (name, { Method = method; Opacity = opacity }) -> setOpacity map name method opacity)

let setIntensity (map: MapboxGL.Mapboxgl.Map) layer mult =
    let nums =
        [| 6.186
           0.3 * mult
           7.186
           0.5 * mult
           8.186
           1.5 * mult
           9.186
           1.5 * mult
           10.186
           1.4 * mult
           11.186
           1.5 * mult
           12.186
           1.5 * mult
           13.186
           1.5 * mult |]

    map.setPaintProperty (
        layer,
        "heatmap-intensity",
        Some(
            [| "interpolate" :> obj
               [| "linear" |]
               [| "zoom" |] |]
            ++ (nums |> Array.map (fun x -> x :> obj))
        )
    )
    |> ignore

let setIntensities (map: MapboxGL.Mapboxgl.Map) model =
    model.Intensity
    |> Map.toArray
    |> Array.iter (fun (name, mult) -> setIntensity map name mult)

let init startLng startLat startZoom =
    { Map = None
      Lng = startLng
      Lat = startLat
      Zoom = startZoom
      Id = ""
      Style = ""
      Filters = Map.empty
      Opacities = Map.empty
      Colors = Map.empty
      DarkMode = false
      PopupTarget = None
      Intensity = Map.empty },
    Cmd.none

type Msg =
    | MountMap of Mapboxgl.Map
    | SetLong of float
    | SetLat of float
    | SetZoom of float
    | SetFilter of string * ResizeArray<obj option>
    | SetLayerOpacity of string * Opacity
    | SetDarkMode of bool
    | SetColor of string * ColorSetting
    | SetIntensity of string * float
    | Preclick
    | Resize

let update msg model =
    match msg with
    | MountMap map -> { model with Map = Some map }, Cmd.none
    | SetLong lng -> { model with Lng = lng }, Cmd.none
    | SetLat lat -> { model with Lat = lat }, Cmd.none
    | SetZoom zoom -> { model with Zoom = zoom }, Cmd.none
    | SetFilter (layer, filter) ->
        let newModel = { model with Filters = Map.add layer filter model.Filters }

        match model.Map with
        | Some (x) ->
            setFilter x layer filter
            newModel, Cmd.none
        | None -> model, Cmd.none
    | Resize ->
        match model.Map with
        | Some (x) -> x.resize () |> ignore
        | None -> printfn "Map is not initialized -- cannot resize"

        model, Cmd.none
    | Preclick -> model, Cmd.none // Intended to be handled by the parent
    | SetDarkMode x ->
        if x <> model.DarkMode then
            JS.Constructors.Array.from (document.getElementsByClassName ("mapboxgl-popup-close-button"))
            |> Array.iter (fun x -> x?click ())

        { model with DarkMode = x }, Cmd.none
    | SetLayerOpacity (name, o) ->
        let newModel = { model with Opacities = Map.add name o model.Opacities }

        match model.Map with
        | Some (x) ->
            setOpacity x name o.Method o.Opacity
            newModel, Cmd.none
        | None -> model, Cmd.none
    | SetColor (name, col) ->
        let newModel = { model with Colors = Map.add name col model.Colors }

        match model.Map with
        | Some (x) ->
            setColor x name col
            newModel, Cmd.none
        | None -> model, Cmd.none
    | SetIntensity (name, intensity) ->
        let newModel = { model with Intensity = Map.add name intensity model.Intensity }

        match model.Map with
        | Some (x) ->
            setIntensity x name intensity
            newModel, Cmd.none
        | None -> model, Cmd.none


let view' model dispatch =
    Html.div [ prop.id model.Id
               prop.fss [ Height.value (pct 100) ]
               prop.ref (fun x ->
                   if x <> null then
                       match model.Map with
                       | None ->
                           printfn $"Recreating map {model.Id}! This should not happen more than once"

                           let opts =
                               jsOptions<MapboxGL.Mapboxgl.MapboxOptions> (fun x ->
                                   x.container <- U2.Case1 model.Id
                                   x.center <- Some(U4.Case1(model.Lng, model.Lat))
                                   x.zoom <- Some model.Zoom
                                   x.style <- Some(U2.Case2 model.Style)
                                   x.accessToken <- Some accessToken)

                           let map = mapboxgl.Map.Create(opts)

                           let geoOptions =
                               jsOptions<MapboxGeocoder.MapboxGeocoder.GeocoderOptions> (fun x ->
                                   x.accessToken <- accessToken
                                   x.mapboxgl <- Some map)

                           map.addControl (U2.Case2(MapboxGeocoder.mapboxGeocoder.Create(geoOptions)))
                           |> ignore

                           map.on ("render", (fun _ -> map.resize () |> ignore))
                           |> ignore

                           let onLoad () =
                               setFilters map model
                               setOpacities map model
                               setColors map model

                           if map.isStyleLoaded () then
                               onLoad ()
                           else
                               map.on ("load", (fun _ -> onLoad ())) |> ignore

                           match model.PopupTarget with
                           | Some x ->
                               map.on ((MapboxGL.Key "preclick"), (U2.Case1 x), (fun e -> dispatch Preclick))
                               |> ignore

                               map.on (
                                   (MapboxGL.Key "mouseenter"),
                                   (U2.Case1 x),
                                   fun _ -> map.getCanvas()?style?cursor <- "pointer"
                               )
                               |> ignore

                               map.on (
                                   (MapboxGL.Key "mouseleave"),
                                   (U2.Case1 x),
                                   fun _ -> map.getCanvas()?style?cursor <- ""
                               )
                               |> ignore
                           | None -> ()

                           MountMap map |> dispatch
                       | Some (x) ->
                           if x.isStyleLoaded () then
                               setFilters x model) ]

let view = lazyView2With (fun _ _ -> true) view'
