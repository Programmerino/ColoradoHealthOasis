// ts2fable 0.8.0-build.638
module rec MapboxGeocoder

#nowarn "3390" // disable warnings for invalid XML comments

open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
open JSExt
open MapboxGL
open Fable.Core.JsInterop

let mapboxGeocoder: MapboxGeocoderStatic = importAll "@mapbox/mapbox-gl-geocoder"

type [<AllowNullLiteral>] IExports =
    abstract MapboxGeocoder: MapboxGeocoderStatic

module MapboxGeocoder =

    type [<AllowNullLiteral>] LngLatLiteral =
        abstract latitude: float with get, set
        abstract longitude: float with get, set

    type [<AllowNullLiteral>] Results =
        inherit GeoJSON.FeatureCollection<GeoJSON.Point>
        abstract attribution: string with get, set
        abstract query: ResizeArray<string> with get, set

    type [<AllowNullLiteral>] Result =
        inherit GeoJSON.Feature<GeoJSON.Point>
        abstract bbox: float * float * float * float with get, set
        abstract center: ResizeArray<float> with get, set
        abstract place_name: string with get, set
        abstract place_type: ResizeArray<string> with get, set
        abstract relevance: float with get, set
        abstract text: string with get, set
        abstract address: string with get, set
        abstract context: ResizeArray<obj option> with get, set

    type Bbox =
        float * float * float * float

    type [<AllowNullLiteral>] GeocoderOptions =
        abstract accessToken: string with get, set
        /// <summary>Use to set a custom API origin. (optional, default "<see href="https://api.mapbox.com"" /></summary>
        abstract origin: string option with get, set
        /// <summary>A <see href="https://github.com/mapbox/mapbox-gl-js">mapbox-gl</see> instance to use when creating <see href="https://docs.mapbox.com/mapbox-gl-js/api/#marker">Markers</see>. Required if <c>options.marker</c> is <c>true</c>.</summary>
        abstract mapboxgl: Mapboxgl.Map option with get, set
        /// On geocoded result what zoom level should the map animate to when a bbox isn't found in the response. If a bbox is found the map will fit to the bbox. (optional, default 16)
        abstract zoom: float option with get, set
        /// Override the default placeholder attribute value. (optional, default "Search")
        abstract placeholder: string option with get, set
        /// <summary>
        /// If <c>false</c>, animating the map to a selected result is disabled. If <c>true</c>, animating the map will use the default animation parameters.
        /// If an object, it will be passed as <c>options</c> to the map <see href="https://docs.mapbox.com/mapbox-gl-js/api/#map#flyto"><c>flyTo</c></see>
        /// or <see href="https://docs.mapbox.com/mapbox-gl-js/api/#map#fitbounds"><c>fitBounds</c></see> method providing control over the animation of the transition. (optional, default true)
        /// </summary>
        abstract flyTo: U3<bool, Mapboxgl.FlyToOptions, Mapboxgl.FitBoundsOptions> option with get, set
        /// a proximity argument: this is a geographical point given as an object with latitude and longitude properties. Search results closer to this point will be given higher priority.
        abstract proximity: LngLatLiteral option with get, set
        /// <summary>If <c>true</c>, the geocoder proximity will automatically update based on the map view. (optional, default true)</summary>
        abstract trackProximity: bool option with get, set
        /// <summary>If <c>true</c>, the geocoder control will collapse until hovered or in focus. (optional, default false)</summary>
        abstract collapsed: bool option with get, set
        /// <summary>If <c>true</c>, the geocoder control will clear it's contents and blur when user presses the escape key. (optional, default false)</summary>
        abstract clearAndBlurOnEsc: bool option with get, set
        /// <summary>If <c>true</c>, the geocoder control will clear its value when the input blurs. (optional, default false)</summary>
        abstract clearOnBlur: bool option with get, set
        /// a bounding box argument: this is a bounding box given as an array in the format [minX, minY, maxX, maxY].
        /// Search results will be limited to the bounding box.
        abstract bbox: Bbox option with get, set
        /// <summary>a comma seperated list of types that filter results to match those specified. See <see href="https://www.mapbox.com/developers/api/geocoding/#filter-type" /> for available types.</summary>
        abstract types: string option with get, set
        /// a comma separated list of country codes to limit results to specified country or countries.
        abstract countries: string option with get, set
        /// Minimum number of characters to enter before results are shown. (optional, default 2)
        abstract minLength: float option with get, set
        /// Maximum number of results to show. (optional, default 5)
        abstract limit: float option with get, set
        /// Specify the language to use for response text and query result weighting.
        /// Options are IETF language tags comprised of a mandatory ISO 639-1 language code and optionally one or more IETF subtags for country or script.
        /// More than one value can also be specified, separated by commas. Defaults to the browser's language settings.
        abstract language: string option with get, set
        /// <summary>
        /// A function which accepts a Feature in the <see href="https://github.com/mapbox/carmen/blob/master/carmen-geojson.md">Carmen GeoJSON</see>
        /// format to filter out results from the Geocoding API response before they are included in the suggestions list.
        /// Return <c>true</c> to keep the item, <c>false</c> otherwise.
        /// </summary>
        abstract filter: (Result -> bool) option with get, set
        /// <summary>
        /// A function accepting the query string and current features list which performs geocoding to supplement results from the Mapbox Geocoding API.
        /// Expected to return a Promise which resolves to an Array of GeoJSON Features in the <see href="https://github.com/mapbox/carmen/blob/master/carmen-geojson.md">Carmen GeoJSON</see> format.
        /// </summary>
        abstract externalGeocoder: (string -> GeoJSON.FeatureCollection<GeoJSON.Geometry> -> Promise<GeoJSON.FeatureCollection>) option with get, set
        /// <summary>
        /// If <c>true</c>, enable reverse geocoding mode. In reverse geocoding, search input is expected to be coordinates in the form <c>lat, lon</c>, with suggestions being the reverse geocodes.
        /// (optional, default false)
        /// </summary>
        abstract reverseGeocode: bool option with get, set
        /// Allow Mapbox to collect anonymous usage statistics from the plugin. (optional, default true)
        abstract enableEventLogging: bool option with get, set
        /// <summary>
        /// If <c>true</c>, a <see href="https://docs.mapbox.com/mapbox-gl-js/api/#marker">Marker</see> will be added to the map at the location of the user-selected result using a default set of Marker options.
        /// If the value is an object, the marker will be constructed using these options. If <c>false</c>, no marker will be added to the map.
        /// Requires that <c>options.mapboxgl</c> also be set. (optional, default true)
        /// </summary>
        abstract marker: U2<bool, Mapboxgl.Marker> option with get, set
        /// <summary>
        /// A function that specifies how the results should be rendered in the dropdown menu.
        /// This function should accepts a single <see href="https://github.com/mapbox/carmen/blob/master/carmen-geojson.md">Carmen GeoJSON</see>
        /// object as input and return a string. Any HTML in the returned string will be rendered.
        /// </summary>
        abstract render: (Result -> string) option with get, set
        /// <summary>
        /// A function that specifies how the selected result should be rendered in the search bar.
        /// This function should accept a single <see href="https://github.com/mapbox/carmen/blob/master/carmen-geojson.md">Carmen GeoJSON</see> object as input and return a string.
        /// HTML tags in the output string will not be rendered. Defaults to <c>(item) =&gt; item.place_name</c>.
        /// </summary>
        abstract getItemValue: (Result -> string) option with get, set
        /// <summary>
        /// A string specifying the geocoding <see href="https://docs.mapbox.com/api/search/#endpoints">endpoint</see> to query.
        /// Options are <c>mapbox.places</c> and <c>mapbox.places</c>. The <c>mapbox.places-permanent</c> mode requires an enterprise license for permanent geocodes. (optional, default "mapbox.places")
        /// </summary>
        abstract mode: GeocoderOptionsMode option with get, set
        /// <summary>
        /// A function accepting the query string which performs local geocoding to supplement results from the Mapbox Geocoding API.
        /// Expected to return an Array of GeoJSON Features in the <see href="https://github.com/mapbox/carmen/blob/master/carmen-geojson.md">Carmen GeoJSON</see> format.
        /// </summary>
        abstract localGeocoder: (string -> ResizeArray<Result>) option with get, set
        /// <summary>
        /// If <c>true</c>, indicates that the <c>localGeocoder</c> results should be the only ones returned to the user.
        /// If <c>false</c>, indicates that the <c>localGeocoder</c> results should be combined with those from the Mapbox API with the <c>localGeocoder</c> results ranked higher. (optional, default false)
        /// </summary>
        abstract localGeocoderOnly: bool option with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] GeocoderOptionsMode =
        | [<CompiledName "mapbox.places">] Mapbox_places
        | [<CompiledName "mapbox.places-permanent">] Mapbox_placesPermanent

type [<AllowNullLiteral>] MapboxGeocoder =
    inherit Mapboxgl.IControl
    abstract addTo: container: U3<string, HTMLElement, Mapboxgl.Map> -> MapboxGeocoder
    abstract onAdd: map: Mapboxgl.Map -> HTMLElement
    abstract createIcon: name: string * path: obj option -> SVGSVGElement
    abstract onRemove: unit -> MapboxGeocoder
    /// Clear and then focus the input.
    /// [ev] the event that triggered the clear, if available
    abstract clear: ?ev: Event -> unit
    /// Set & query the input
    abstract query: searchInput: string -> MapboxGeocoder
    /// Set input
    /// searchInput location name or other search input
    abstract setInput: searchInput: string -> MapboxGeocoder
    /// <summary>Set proximity The new <c>options.proximity</c> value. This is a geographical point given as an object with <c>latitude</c> and <c>longitude</c> properties.</summary>
    abstract setProximity: proximity: MapboxGeocoder.LngLatLiteral -> MapboxGeocoder
    /// Get the geocoder proximity
    abstract getProximity: unit -> MapboxGeocoder.LngLatLiteral
    /// <summary>
    /// Set the render function used in the results dropdown
    /// The function to use as a render function. This function accepts a single <see href="https://github.com/mapbox/carmen/blob/master/carmen-geojson.md">Carmen GeoJSON</see> object as input and returns a string.
    /// </summary>
    abstract setRenderFunction: fn: (MapboxGeocoder.Result -> string) -> MapboxGeocoder
    /// Get the function used to render the results dropdown
    abstract getRenderFunction: unit -> (MapboxGeocoder.Result -> string)
    /// Get the language to use in UI elements and when making search requests
    /// 
    /// Look first at the explicitly set options otherwise use the browser's language settings
    /// language Specify the language to use for response text and query result weighting.
    /// Options are IETF language tags comprised of a mandatory ISO 639-1 language code and optionally one or more IETF subtags for country or script.
    /// More than one value can also be specified, separated by commas.
    abstract setLanguage: language: string -> MapboxGeocoder
    /// Get the language to use in UI elements and when making search requests
    abstract getLanguage: unit -> string
    /// Get the zoom level the map will move to when there is no bounding box on the selected result
    abstract getZoom: unit -> float
    /// <summary>Set the zoom level that the map should animate to when a <c>bbox</c> isn't found in the response. If a <c>bbox</c> is found the map will fit to the <c>bbox</c>.</summary>
    abstract setZoom: zoom: float -> MapboxGeocoder
    /// <summary>
    /// Set the flyTo options
    /// If false, animating the map to a selected result is disabled. If true, animating the map will use the default animation parameters.
    /// If an object, it will be passed as <c>options</c> to the map <see href="https://docs.mapbox.com/mapbox-gl-js/api/#map#flyto"><c>flyTo</c></see> or <see href="https://docs.mapbox.com/mapbox-gl-js/api/#map#fitbounds"><c>fitBounds</c></see>
    /// method providing control over the animation of the transition.
    /// </summary>
    abstract setFlyTo: flyTo: U3<bool, Mapboxgl.FlyToOptions, Mapboxgl.FitBoundsOptions> -> MapboxGeocoder
    /// Get the parameters used to fly to the selected response, if any
    abstract getFlyTo: unit -> U3<bool, Mapboxgl.FlyToOptions, Mapboxgl.FitBoundsOptions>
    /// Get the value of the placeholder string
    abstract getPlaceholder: unit -> string
    /// Set the value of the input element's placeholder
    /// placeholder the text to use as the input element's placeholder
    abstract setPlaceholder: placeholder: string -> MapboxGeocoder
    abstract getBbox: unit -> MapboxGeocoder.Bbox
    abstract setBbox: bbox: MapboxGeocoder.Bbox -> MapboxGeocoder
    abstract getCountries: unit -> string
    abstract setCountries: countries: string -> MapboxGeocoder
    abstract getTypes: unit -> string
    abstract setTypes: types: string -> MapboxGeocoder
    abstract getMinLength: unit -> float
    abstract setMinLength: minLength: float -> MapboxGeocoder
    abstract getLimit: unit -> float
    abstract setLimit: limit: float -> MapboxGeocoder
    abstract getFilter: unit -> (MapboxGeocoder.Result -> bool)
    abstract setFilter: filter: (MapboxGeocoder.Result -> bool) -> MapboxGeocoder
    abstract setOrigin: origin: string -> MapboxGeocoder
    abstract getOrigin: unit -> string
    /// <summary>
    /// Subscribe to events that happen within the plugin.
    /// type name of event. Available events and the data passed into their respective event objects are:
    /// 
    /// - __clear__ <c>Emitted when the input is cleared</c>
    /// - __loading__ <c>{ query } Emitted when the geocoder is looking up a query</c>
    /// - __results__ <c>{ results } Fired when the geocoder returns a response</c>
    /// - __result__ <c>{ result } Fired when input is set</c>
    /// - __error__ <c>{ error } Error as string</c>
    /// </summary>
    abstract on: ``type``: string * fn: (ResizeArray<obj option> -> unit) -> MapboxGeocoder
    abstract off: ``type``: string * fn: (ResizeArray<obj option> -> unit) -> MapboxGeocoder

type [<AllowNullLiteral>] MapboxGeocoderStatic =
    [<EmitConstructor>] abstract Create: ?options: MapboxGeocoder.GeocoderOptions -> MapboxGeocoder
