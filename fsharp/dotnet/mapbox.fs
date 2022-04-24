// ts2fable 0.8.0-build.638
module rec mapbox

#nowarn "3390" // disable warnings for invalid XML comments

open System
open Fable.Core
open Browser.Types

type Array<'T> = System.Collections.Generic.IList<'T>

let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/lib/classes/mapi-client``: mapbox_mapbox_sdk_lib_classes_mapi_client.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/datasets``: mapbox_mapbox_sdk_services_datasets.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/directions``: mapbox_mapbox_sdk_services_directions.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/geocoding``: mapbox_mapbox_sdk_services_geocoding.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/map-matching``: mapbox_mapbox_sdk_services_map_matching.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/matrix``: mapbox_mapbox_sdk_services_matrix.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/optimization``: mapbox_mapbox_sdk_services_optimization.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/static``: mapbox_mapbox_sdk_services_static.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/styles``: mapbox_mapbox_sdk_services_styles.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/tilequery``: mapbox_mapbox_sdk_services_tilequery.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/tilesets``: mapbox_mapbox_sdk_services_tilesets.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/tokens``: mapbox_mapbox_sdk_services_tokens.IExports = jsNative
let [<ImportAll("@mapbox/mapbox-sdk")>] ``mapbox/mapbox-sdk/services/uploads``: mapbox_mapbox_sdk_services_uploads.IExports = jsNative

module mapbox_mapbox_sdk_lib_classes_mapi_client =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type MapiRequestOptions = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequestOptions
    type DirectionsApproach = mapbox_mapbox_sdk_lib_classes_mapi_request.DirectionsApproach

    type [<AllowNullLiteral>] IExports =
        abstract MapiClient: MapiClientStatic

    type [<AllowNullLiteral>] MapiClient =
        abstract accessToken: string with get, set
        abstract origin: string option with get, set
        abstract createRequest: requestOptions: MapiRequestOptions -> MapiRequest

    type [<AllowNullLiteral>] MapiClientStatic =
        [<EmitConstructor>] abstract Create: config: SdkConfig -> MapiClient

    type [<AllowNullLiteral>] SdkConfig =
        abstract accessToken: string with get, set
        abstract origin: string option with get, set

module mapbox_mapbox_sdk_lib_classes_mapi_request =
    type MapiResponse = mapbox_mapbox_sdk_lib_classes_mapi_response.MapiResponse
    type MapiError = mapbox_mapbox_sdk_lib_classes_mapi_error.MapiError

    type [<AllowNullLiteral>] EventEmitter =
        abstract response: MapiResponse with get, set
        abstract error: MapiError with get, set
        abstract downloadProgress: ProgressEvent with get, set
        abstract uploadProgress: ProgressEvent with get, set

    type [<AllowNullLiteral>] MapiRequestOptions =
        /// The request's path, including colon-prefixed route parameters.
        abstract path: string with get, set
        /// The request's origin.
        abstract origin: string with get, set
        /// The request's HTTP method.
        abstract method: string with get, set
        /// A query object, which will be transformed into a URL query string.
        abstract query: obj option with get, set
        /// A route parameters object, whose values will be interpolated the path.
        abstract ``params``: obj option with get, set
        /// The request's headers.
        abstract headers: obj option with get, set
        /// Data to send with the request. If the request has a body, it will also be sent with the header 'Content-Type: application/json'.
        abstract body: obj option with get, set
        /// A file to send with the request. The browser client accepts Blobs and ArrayBuffers.
        abstract file: U4<Blob, JS.ArrayBuffer, string, Node.Fs.ReadStream<_>> with get, set
        /// The encoding of the response.
        abstract encoding: string with get, set
        /// <summary>The method to send the <c>file</c>. Options are <c>data</c> (x-www-form-urlencoded) or <c>form</c> (multipart/form-data)</summary>
        abstract sendFileAs: MapiRequestOptionsSendFileAs with get, set

    type [<AllowNullLiteral>] MapiRequest =
        interface end

    type [<AllowNullLiteral>] PageCallbackFunction =
        abstract error: MapiError with get, set
        abstract response: MapiResponse with get, set
        abstract next: (unit -> unit) with get, set

    type Coordinates =
        float * float

    type [<StringEnum>] [<RequireQualifiedAccess>] MapboxProfile =
        | Driving
        | Walking
        | Cycling
        | [<CompiledName "driving-traffic">] DrivingTraffic

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsApproach =
        | Unrestricted
        | Curb

    type [<StringEnum>] [<RequireQualifiedAccess>] MapiRequestOptionsSendFileAs =
        | Data
        | Form

module mapbox_mapbox_sdk_lib_classes_mapi_response =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest

    type [<AllowNullLiteral>] MapiResponse =
        /// The response body, parsed as JSON.
        abstract body: obj option with get, set
        /// The raw response body.
        abstract rawBody: string with get, set
        /// The response's status code.
        abstract statusCode: float with get, set
        /// The parsed response headers.
        abstract headers: obj option with get, set
        /// The parsed response links
        abstract links: obj option with get, set
        /// The response's originating MapiRequest.
        abstract request: MapiRequest with get, set
        abstract hasNextPage: unit -> bool
        abstract nextPage: unit -> MapiRequest option

module mapbox_mapbox_sdk_lib_classes_mapi_error =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest

    type [<AllowNullLiteral>] MapiError =
        /// The errored request.
        abstract request: MapiRequest with get, set
        /// The type of error. Usually this is 'HttpError'.
        /// If the request was aborted, so the error was not sent from the server, the type will be 'RequestAbortedError'.
        abstract ``type``: string with get, set
        /// The numeric status code of the HTTP response
        abstract statusCode: float option with get, set
        /// If the server sent a response body, this property exposes that response, parsed as JSON if possible.
        abstract body: obj option with get, set
        /// Whatever message could be derived from the call site and HTTP response.
        abstract message: string option with get, set

module mapbox_mapbox_sdk_services_datasets =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Datasets Types
        /// *******************************************************************************************************************
        abstract Datasets: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> DatasetsService

    type [<AllowNullLiteral>] DatasetsService =
        /// List datasets in your account.
        abstract listDatasets: ?config: {| sortby: DatasetsServiceListDatasetsSortby option |} -> MapiRequest
        /// <summary>Create a new, empty dataset.</summary>
        /// <param name="config">Object</param>
        abstract createDataset: config: {| name: string option; description: string option |} -> MapiRequest
        /// <summary>Get metadata about a dataset.</summary>
        /// <param name="config" />
        abstract getMetadata: config: {| datasetId: string |} -> MapiRequest
        /// <summary>Update user-defined properties of a dataset's metadata.</summary>
        /// <param name="config" />
        abstract updateMetadata: config: {| datasetId: string option; name: string option; description: string option |} -> MapiRequest
        /// <summary>Delete a dataset, including all features it contains.</summary>
        /// <param name="config" />
        abstract deleteDataset: config: {| datasetId: string |} -> MapiRequest
        /// <summary>
        /// List features in a dataset.
        /// This endpoint supports pagination. Use MapiRequest#eachPage or manually specify the limit and start options.
        /// </summary>
        /// <param name="config" />
        abstract listFeatures: config: {| datasetId: string; limit: float option; start: string option |} -> MapiRequest
        /// <summary>Add a feature to a dataset or update an existing one.</summary>
        /// <param name="config" />
        abstract putFeature: config: {| datasetId: string; featureId: string; feature: DataSetsFeature |} -> MapiRequest
        /// <summary>Get a feature in a dataset.</summary>
        /// <param name="config" />
        abstract getFeature: config: {| datasetId: string; featureId: string |} -> MapiRequest
        /// <summary>Delete a feature in a dataset.</summary>
        /// <param name="config" />
        abstract deleteFeature: config: {| datasetId: string; featureId: string |} -> MapiRequest

    /// All GeoJSON types except for FeatureCollection.
    type DataSetsFeature =
        U8<GeoJSON.Point, GeoJSON.MultiPoint, GeoJSON.LineString, GeoJSON.MultiLineString, GeoJSON.Polygon, GeoJSON.MultiPolygon, GeoJSON.GeometryCollection, GeoJSON.Feature<GeoJSON.Geometry, GeoJSON.GeoJsonProperties>>

    type [<AllowNullLiteral>] Dataset =
        /// The username of the dataset owner
        abstract owner: string with get, set
        /// Id for an existing dataset
        abstract id: string with get, set
        abstract created: string with get, set
        abstract modified: string with get, set
        /// The extent of features in the dataset as an array of west, south, east, north coordinates
        abstract bounds: ResizeArray<float> with get, set
        /// The number of features in the dataset
        abstract features: float with get, set
        /// The size of the dataset in bytes
        abstract size: float with get, set
        /// The name of the dataset
        abstract name: string with get, set
        /// The description of the dataset
        abstract description: string with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] DatasetsServiceListDatasetsSortby =
        | Created
        | Modified

module mapbox_mapbox_sdk_services_directions =
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type MapboxProfile = mapbox_mapbox_sdk_lib_classes_mapi_request.MapboxProfile
    type DirectionsApproach = mapbox_mapbox_sdk_lib_classes_mapi_request.DirectionsApproach
    type Coordinates = mapbox_mapbox_sdk_lib_classes_mapi_request.Coordinates

    type [<AllowNullLiteral>] IExports =
        abstract Directions: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> DirectionsService

    type [<AllowNullLiteral>] DirectionsService =
        abstract getDirections: request: DirectionsRequest -> MapiRequest

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsAnnotation =
        | Duration
        | Distance
        | Speed
        | Congestion

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsGeometry =
        | Geojson
        | Polyline
        | Polyline6

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsOverview =
        | Full
        | Simplified
        | False

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsUnits =
        | Imperial
        | Metric

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsSide =
        | Left
        | Right

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsMode =
        | Driving
        | Ferry
        | Unaccessible
        | Walking
        | Cycling
        | Train

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsClass =
        | Toll
        | Ferry
        | Restricted
        | Motorway
        | Tunnel

    type [<StringEnum>] [<RequireQualifiedAccess>] ManeuverModifier =
        | Uturn
        | [<CompiledName "sharp right">] ``Sharp right``
        | Right
        | [<CompiledName "slight right">] ``Slight right``
        | Straight
        | [<CompiledName "slight left">] ``Slight left``
        | Left
        | [<CompiledName "sharp left">] ``Sharp left``
        | Depart
        | Arrive

    type [<StringEnum>] [<RequireQualifiedAccess>] ManeuverType =
        | Turn
        | [<CompiledName "new name">] ``New name``
        | Depart
        | Arrive
        | Merge
        | [<CompiledName "on ramp">] ``On ramp``
        | [<CompiledName "off ramp">] ``Off ramp``
        | Fork
        | [<CompiledName "end of road">] ``End of road``
        | Continue
        | Roundabout
        | Rotary
        | [<CompiledName "roundabout turn">] ``Roundabout turn``
        | Notification
        | [<CompiledName "exit roundabout">] ``Exit roundabout``
        | [<CompiledName "exit rotary">] ``Exit rotary``

    type [<AllowNullLiteral>] CommonDirectionsRequest =
        abstract waypoints: ResizeArray<DirectionsWaypoint> with get, set
        /// Whether to try to return alternative routes. An alternative is classified as a route that is significantly
        /// different than the fastest route, but also still reasonably fast. Such a route does not exist in all circumstances.
        /// Currently up to two alternatives can be returned. Can be  true or  false (default).
        abstract alternatives: bool option with get, set
        /// Whether or not to return additional metadata along the route. Possible values are:  duration ,  distance ,  speed , and congestion .
        /// Several annotations can be used by including them as a comma-separated list. See the RouteLeg object for more details on
        /// what is included with annotations.
        abstract annotations: ResizeArray<DirectionsAnnotation> option with get, set
        /// Whether or not to return banner objects associated with the  routeSteps .
        /// Should be used in conjunction with  steps . Can be  true or  false . The default is  false .
        abstract bannerInstructions: bool option with get, set
        /// Sets the allowed direction of travel when departing intermediate waypoints. If  true , the route will continue in the same
        /// direction of travel. If  false , the route may continue in the opposite direction of travel. Defaults to  true for mapbox/driving and
        /// false for  mapbox/walking and  mapbox/cycling .
        abstract continueStraight: bool option with get, set
        /// Format of the returned geometry. Allowed values are:  geojson (as LineString ),
        /// polyline with precision 5,  polyline6 (a polyline with precision 6). The default value is  polyline .
        abstract geometries: DirectionsGeometry option with get, set
        /// Language of returned turn-by-turn text instructions. See supported languages . The default is  en for English.
        abstract language: string option with get, set
        /// Type of returned overview geometry. Can be  full (the most detailed geometry available),
        /// simplified (a simplified version of the full geometry), or  false (no overview geometry). The default is  simplified .
        abstract overview: DirectionsOverview option with get, set
        /// Emit instructions at roundabout exits. Can be  true or  false . The default is  false .
        abstract roundaboutExits: bool option with get, set
        /// Whether to return steps and turn-by-turn instructions. Can be  true or  false . The default is  false .
        abstract steps: bool option with get, set
        /// Whether or not to return SSML marked-up text for voice guidance along the route. Should be used in conjunction with steps .
        /// Can be  true or  false . The default is  false .
        abstract voiceInstructions: bool option with get, set
        /// Which type of units to return in the text for voice instructions. Can be  imperial or  metric . Default is  imperial .
        abstract voiceUnits: DirectionsUnits option with get, set

    type DirectionsProfileExclusion =
        U3<{| profile: string; exclude: obj option |}, {| profile: string; exclude: Array<string> option |}, {| profile: DirectionsProfileExclusionProfile; exclude: Array<DirectionsProfileExclusionExcludeArray> option |}>

    type [<AllowNullLiteral>] DirectionsRequest =
        interface end

    type [<AllowNullLiteral>] Waypoint =
        /// Semicolon-separated list of  {longitude},{latitude} coordinate pairs to visit in order. There can be between 2 and 25 coordinates.
        abstract coordinates: Coordinates with get, set
        /// <summary>
        /// Used to filter the road segment the waypoint will be placed on by direction and dicates the anlge of approach.
        /// This option should always be used in conjunction with a <c>radius</c>. The first values is angle clockwise from true
        /// north between 0 and 360, and the second is the range of degrees the angle can deviate by.
        /// </summary>
        abstract bearing: Coordinates option with get, set
        /// Used to indicate how requested routes consider from which side of the road to approach a waypoint.
        /// Accepts unrestricted (default) or  curb . If set to  unrestricted , the routes can approach waypoints from either side of the road.
        /// If set to  curb , the route will be returned so that on arrival, the waypoint will be found on the side that corresponds with the
        /// driving_side of the region in which the returned route is located. Note that the  approaches parameter influences how you arrive at a waypoint,
        /// while  bearings influences how you start from a waypoint. If provided, the list of approaches must be the same length as the list of waypoints.
        /// However, you can skip a coordinate and show its position in the list with the  ; separator.
        abstract approach: DirectionsApproach option with get, set
        /// Maximum distance in meters that each coordinate is allowed to move when snapped to a nearby road segment.
        /// There must be as many radiuses as there are coordinates in the request, each separated by ';'.
        /// Values can be any number greater than 0 or the string 'unlimited'.
        /// A  NoSegment error is returned if no routable road is found within the radius.
        abstract radius: U2<float, string> option with get, set

    type [<AllowNullLiteral>] DirectionsWaypoint =
        interface end

    type [<AllowNullLiteral>] DirectionsResponse =
        /// Array of Route objects ordered by descending recommendation rank. May contain at most two routes.
        abstract routes: ResizeArray<Route> with get, set
        /// Array of Waypoint objects. Each waypoints is an input coordinate snapped to the road and path network.
        /// The waypoints appear in the array in the order of the input coordinates.
        abstract waypoints: ResizeArray<DirectionsWaypoint> with get, set
        /// String indicating the state of the response. This is a separate code than the HTTP status code.
        /// On normal valid responses, the value will be Ok.
        abstract code: string with get, set
        abstract uuid: string with get, set

    type [<AllowNullLiteral>] Route =
        /// Depending on the geometries parameter this is a GeoJSON LineString or a Polyline string.
        /// Depending on the overview parameter this is the complete route geometry (full), a simplified geometry
        /// to the zoom level at which the route can be displayed in full (simplified), or is not included (false)
        abstract geometry: U2<GeoJSON.LineString, GeoJSON.MultiLineString> with get, set
        /// Array of RouteLeg objects.
        abstract legs: ResizeArray<Leg> with get, set
        /// String indicating which weight was used. The default is routability which is duration-based,
        /// with additional penalties for less desirable maneuvers.
        abstract weight_name: string with get, set
        /// Float indicating the weight in units described by weight_name
        abstract weight: float with get, set
        /// Float indicating the estimated travel time in seconds.
        abstract duration: float with get, set
        /// Float indicating the distance traveled in meters.
        abstract distance: float with get, set
        /// String of the locale used for voice instructions. Defaults to en, and can be any accepted instruction language.
        abstract voiceLocale: string option with get, set

    type [<AllowNullLiteral>] Leg =
        /// Depending on the summary parameter, either a String summarizing the route (true, default) or an empty String (false)
        abstract summary: string with get, set
        abstract weight: float with get, set
        /// Number indicating the estimated travel time in seconds
        abstract duration: float with get, set
        /// Depending on the steps parameter, either an Array of RouteStep objects (true, default) or an empty array (false)
        abstract steps: ResizeArray<Step> with get, set
        /// Number indicating the distance traveled in meters
        abstract distance: float with get, set
        /// An annotations object that contains additional details about each line segment along the route geometry.
        /// Each entry in an annotations field corresponds to a coordinate along the route geometry.
        abstract annotation: ResizeArray<DirectionsAnnotation> with get, set

    type [<AllowNullLiteral>] Step =
        /// Array of objects representing all intersections along the step.
        abstract intersections: ResizeArray<Intersection> with get, set
        /// The legal driving side at the location for this step. Either left or right.
        abstract driving_side: DirectionsSide with get, set
        /// Depending on the geometries parameter this is a GeoJSON LineString or a
        /// Polyline string representing the full route geometry from this RouteStep to the next RouteStep
        abstract geometry: U2<GeoJSON.LineString, GeoJSON.MultiLineString> with get, set
        /// String indicating the mode of transportation. Possible values:
        abstract mode: DirectionsMode with get, set
        /// One StepManeuver object
        abstract maneuver: Maneuver with get, set
        /// Any road designations associated with the road or path leading from this step’s maneuver to the next step’s maneuver.
        /// Optionally included, if data is available. If multiple road designations are associated with the road, they are separated by semicolons.
        /// A road designation typically consists of an alphabetic network code (identifying the road type or numbering system), a space or hyphen,
        /// and a route number. You should not assume that the network code is globally unique: for example, a network code of “NH” may appear on a
        /// “National Highway” or “New Hampshire”. Moreover, a route number may not even uniquely identify a road within a given network.
        abstract ref: string option with get, set
        abstract weight: float with get, set
        /// Number indicating the estimated time traveled time in seconds from the maneuver to the next RouteStep.
        abstract duration: float with get, set
        /// String with the name of the way along which the travel proceeds
        abstract name: string with get, set
        /// Number indicating the distance traveled in meters from the maneuver to the next RouteStep.
        abstract distance: float with get, set
        abstract voiceInstructions: ResizeArray<VoiceInstruction> with get, set
        abstract bannerInstructions: ResizeArray<BannerInstruction> with get, set
        /// String with the destinations of the way along which the travel proceeds. Optionally included, if data is available.
        abstract destinations: string option with get, set
        /// String with the exit numbers or names of the way. Optionally included, if data is available.
        abstract exits: string option with get, set
        /// A string containing an IPA phonetic transcription indicating how to pronounce the name in the name property.
        /// This property is omitted if pronunciation data is unavailable for the step.
        abstract pronunciation: string option with get, set

    type [<AllowNullLiteral>] Instruction =
        /// String that contains all the text that should be displayed.
        abstract text: string with get, set
        /// Objects that, together, make up what should be displayed in the banner.
        /// Includes additional information intended to be used to aid in visual layout
        abstract components: ResizeArray<Component> with get, set
        /// The type of maneuver. May be used in combination with the modifier (and, if it is a roundabout, the degrees) to for an icon to
        /// display. Possible values: 'turn', 'merge', 'depart', 'arrive', 'fork', 'off ramp', 'roundabout'
        abstract ``type``: string option with get, set
        /// The modifier for the maneuver. Can be used in combination with the type (and, if it is a roundabout, the degrees)
        /// to for an icon to display. Possible values: 'left', 'right', 'slight left', 'slight right', 'sharp left', 'sharp right', 'straight', 'uturn'
        abstract modifier: ManeuverModifier option with get, set
        /// The degrees at which you will be exiting a roundabout, assuming 180 indicates going straight through the roundabout.
        abstract degrees: float option with get, set
        /// A string representing which side the of the street people drive on in that location. Can be 'left' or 'right'.
        abstract driving_side: DirectionsSide with get, set

    type [<AllowNullLiteral>] BannerInstruction =
        /// Float indicating in meters, how far from the upcoming maneuver
        /// the banner instruction should begin being displayed. Only 1 banner should be displayed at a time.
        abstract distanceAlongGeometry: float with get, set
        /// Most important content to display to the user. Our SDK displays this text larger and at the top.
        abstract primary: Instruction with get, set
        /// Additional content useful for visual guidance. Our SDK displays this text slightly smaller and below the primary. Can be null.
        abstract secondary: ResizeArray<Instruction> option with get, set
        abstract ``then``: obj option with get, set
        /// Additional information that is included if we feel the driver needs a heads up about something.
        /// Can include information about the next maneuver (the one after the upcoming one) if the step is short -
        /// can be null, or can be lane information. If we have lane information, that trumps information about the next maneuver.
        abstract sub: Sub option with get, set

    type [<AllowNullLiteral>] Sub =
        /// String that contains all the text that should be displayed.
        abstract text: string with get, set
        /// Objects that, together, make up what should be displayed in the banner.
        /// Includes additional information intended to be used to aid in visual layout
        abstract components: ResizeArray<Component> with get, set

    type [<AllowNullLiteral>] Component =
        /// String giving you more context about the component which may help in visual markup/display choices.
        /// If the type of the components is unknown it should be treated as text. Note: Introduction of new types
        /// is not considered a breaking change. See the Types of Banner Components table below for more info on each type.
        abstract ``type``: string with get, set
        /// The sub-string of the parent object's text that may have additional context associated with it.
        abstract text: string with get, set
        /// The abbreviated form of text. If this is present, there will also be an abbr_priority value.
        /// See the Examples of Abbreviations table below for an example of using abbr and abbr_priority.
        abstract abbr: string option with get, set
        /// An integer indicating the order in which the abbreviation abbr should be used in place of text.
        /// The highest priority is 0 and a higher integer value means it should have a lower priority. There are no gaps in
        /// integer values. Multiple components can have the same abbr_priority and when this happens all components with the
        /// same abbr_priority should be abbreviated at the same time. Finding no larger values of abbr_priority means that the
        /// string is fully abbreviated.
        abstract abbr_priority: float option with get, set
        /// String pointing to a shield image to use instead of the text.
        abstract imageBaseURL: string option with get, set
        /// (present if component is lane): An array indicating which directions you can go from a lane (left, right, or straight).
        /// If the value is ['left', 'straight'], the driver can go straight or left from that lane
        abstract directions: ResizeArray<string> option with get, set
        /// (present if component is lane): A boolean telling you if that lane can be used to complete the upcoming maneuver.
        /// If multiple lanes are active, then they can all be used to complete the upcoming maneuver.
        abstract active: bool with get, set

    type [<AllowNullLiteral>] VoiceInstruction =
        /// Float indicating in meters, how far from the upcoming maneuver the voice instruction should begin.
        abstract distanceAlongGeometry: float with get, set
        /// String containing the text of the verbal instruction.
        abstract announcement: string with get, set
        /// String with SSML markup for proper text and pronunciation. Note: this property is designed for use with Amazon Polly.
        /// The SSML tags contained here may not work with other text-to-speech engines.
        abstract ssmlAnnouncement: string with get, set

    type [<AllowNullLiteral>] Maneuver =
        /// Number between 0 and 360 indicating the clockwise angle from true north to the direction of travel right after the maneuver
        abstract bearing_after: float with get, set
        /// Number between 0 and 360 indicating the clockwise angle from true north to the direction of travel right before the maneuver
        abstract bearing_before: float with get, set
        /// Array of [ longitude, latitude ] coordinates for the point of the maneuver
        abstract location: ResizeArray<float> with get, set
        /// Optional String indicating the direction change of the maneuver
        abstract modifier: ManeuverModifier option with get, set
        /// String indicating the type of maneuver
        abstract ``type``: ManeuverType with get, set
        /// A human-readable instruction of how to execute the returned maneuver
        abstract instruction: string with get, set

    type [<AllowNullLiteral>] Intersection =
        /// Index into the bearings/entry array. Used to extract the bearing after the turn. Namely, The clockwise angle from true north to
        /// the direction of travel after the maneuver/passing the intersection.
        /// The value is not supplied for arrive maneuvers.
        abstract out: float option with get, set
        /// A list of entry flags, corresponding in a 1:1 relationship to the bearings.
        /// A value of true indicates that the respective road could be entered on a valid route.
        /// false indicates that the turn onto the respective road would violate a restriction.
        abstract entry: ResizeArray<bool> with get, set
        /// A list of bearing values (for example [0,90,180,270]) that are available at the intersection.
        /// The bearings describe all available roads at the intersection.
        abstract bearings: ResizeArray<float> with get, set
        /// A [longitude, latitude] pair describing the location of the turn.
        abstract location: ResizeArray<float> with get, set
        /// Index into bearings/entry array. Used to calculate the bearing before the turn. Namely, the clockwise angle from true
        /// north to the direction of travel before the maneuver/passing the intersection. To get the bearing in the direction of driving,
        /// the bearing has to be rotated by a value of 180. The value is not supplied for departure maneuvers.
        abstract ``in``: float option with get, set
        /// An array of strings signifying the classes of the road exiting the intersection.
        abstract classes: ResizeArray<DirectionsClass> option with get, set
        /// Array of Lane objects that represent the available turn lanes at the intersection.
        /// If no lane information is available for an intersection, the lanes property will not be present.
        abstract lanes: ResizeArray<Lane> with get, set

    type [<AllowNullLiteral>] Lane =
        /// Boolean value for whether this lane can be taken to complete the maneuver. For instance, if the lane array has four objects and the
        /// first two are marked as valid, then the driver can take either of the left lanes and stay on the route.
        abstract valid: bool with get, set
        /// Array of signs for each turn lane. There can be multiple signs. For example, a turning lane can have a sign with an arrow pointing left and another sign with an arrow pointing straight.
        abstract indications: ResizeArray<string> with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsProfileExclusionProfile =
        | Driving
        | [<CompiledName "driving-traffic">] DrivingTraffic

    type [<StringEnum>] [<RequireQualifiedAccess>] DirectionsProfileExclusionExcludeArray =
        | Ferry
        | Toll
        | Motorway

module mapbox_mapbox_sdk_services_geocoding =
    open Fable.Core.JS
    type LngLatLike = MapboxGL.Mapboxgl.LngLatLike
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type Coordinates = mapbox_mapbox_sdk_lib_classes_mapi_request.Coordinates
    type MapiResponse = mapbox_mapbox_sdk_lib_classes_mapi_response.MapiResponse
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Geocoder Types
        /// *******************************************************************************************************************
        abstract Geocoding: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> GeocodeService

    type [<AllowNullLiteral>] GeocodeService =
        abstract forwardGeocode: request: GeocodeRequest -> Promise<MapiResponse>
        abstract reverseGeocode: request: GeocodeRequest -> Promise<MapiResponse>

    type BoundingBox =
        float * float * float * float

    type [<StringEnum>] [<RequireQualifiedAccess>] GeocodeMode =
        | [<CompiledName "mapbox.places">] Mapbox_places
        | [<CompiledName "mapbox.places-permanent">] Mapbox_placesPermanent

    type [<StringEnum>] [<RequireQualifiedAccess>] GeocodeQueryType =
        | Country
        | Region
        | Postcode
        | District
        | Place
        | Locality
        | Neighborhood
        | Address
        | Poi
        | [<CompiledName "poi.landmark">] Poi_landmark

    type [<AllowNullLiteral>] GeocodeRequest =
        /// A location. This will be a place name for forward geocoding or a coordinate pair (longitude, latitude) for reverse geocoding.
        abstract query: U2<string, LngLatLike> with get, set
        /// Either  mapbox.places for ephemeral geocoding, or  mapbox.places-permanent for storing results and batch geocoding.
        abstract mode: GeocodeMode option with get, set
        /// Limit results to one or more countries. Options are ISO 3166 alpha 2 country codes
        abstract countries: ResizeArray<string> option with get, set
        /// Bias local results based on a provided location. Options are  longitude,latitude coordinates.
        abstract proximity: Coordinates option with get, set
        /// Filter results by one or more feature types
        abstract types: ResizeArray<GeocodeQueryType> option with get, set
        /// Forward geocoding only. Return autocomplete results or not. Options are  true or  false and the default is  true .
        abstract autocomplete: bool option with get, set
        /// Forward geocoding only. Limit results to a bounding box. Options are in the format  minLongitude,minLatitude,maxLongitude,maxLatitude.
        abstract bbox: BoundingBox option with get, set
        /// Limit the number of results returned. The default is  5 for forward geocoding and  1 for reverse geocoding.
        abstract limit: float option with get, set
        /// Specify the language to use for response text and, for forward geocoding, query result weighting.
        /// Options are IETF language tags comprised of a mandatory ISO 639-1 language code and optionally one or more
        /// IETF subtags for country or script.
        abstract language: ResizeArray<string> option with get, set
        /// Specify whether to request additional etadat about the recommended navigation destination. Only applicable for address features.
        abstract routing: bool option with get, set

    type [<AllowNullLiteral>] GeocodeResponse =
        /// "Feature Collection" , a GeoJSON type from the GeoJSON specification.
        abstract ``type``: string with get, set
        /// An array of space and punctuation-separated strings from the original query.
        abstract query: ResizeArray<string> with get, set
        /// An array of feature objects.
        abstract features: ResizeArray<GeocodeFeature> with get, set
        /// A string attributing the results of the Mapbox Geocoding API to Mapbox and links to Mapbox's terms of service and data sources.
        abstract attribution: string with get, set

    type [<AllowNullLiteral>] GeocodeFeature =
        /// A string feature id in the form  {type}.{id} where  {type} is the lowest hierarchy feature in the  place_type field.
        /// The  {id} suffix of the feature id is unstable and may change within versions.
        abstract id: string with get, set
        /// "Feature" , a GeoJSON type from the GeoJSON specification.
        abstract ``type``: string with get, set
        /// An array of feature types describing the feature. Options are  country ,  region ,  postcode ,  district ,  place , locality ,  neighborhood ,
        /// address ,  poi , and  poi.landmark . Most features have only one type, but if the feature has multiple types,
        /// all applicable types will be listed in the array. (For example, Vatican City is a  country , region , and  place .)
        abstract place_type: ResizeArray<string> with get, set
        /// A numerical score from 0 (least relevant) to 0.99 (most relevant) measuring how well each returned feature matches the query.
        /// You can use the  relevance property to remove results that don't fully match the query.
        abstract relevance: float with get, set
        /// A string of the house number for the returned  address feature. Note that unlike the
        /// address property for  poi features, this property is outside the  properties object.
        abstract address: string option with get, set
        /// An object describing the feature. The property object is unstable and only Carmen GeoJSON properties are guaranteed.
        /// Your implementation should check for the presence of these values in a response before it attempts to use them.
        abstract properties: GeocodeProperties with get, set
        /// A string representing the feature in the requested language, if specified.
        abstract text: string with get, set
        /// A string representing the feature in the requested language, if specified, and its full result hierarchy.
        abstract place_name: string with get, set
        /// A string analogous to the  text field that more closely matches the query than results in the specified language.
        /// For example, querying "Köln, Germany" with language set to English might return a feature with the
        /// text "Cologne" and the  matching_text "Köln".
        abstract matching_text: string with get, set
        /// A string analogous to the  place_name field that more closely matches the query than results in the specified language.
        /// For example, querying "Köln, Germany" with language set to English might return a feature with the place_name "Cologne, Germany"
        /// and a  matching_place_name of "Köln, North Rhine-Westphalia, Germany".
        abstract matching_place_name: string with get, set
        /// A string of the IETF language tag of the query's primary language.
        /// Can be used to identity text and place_name properties on this object
        /// in the format text_{language}, place_name_{language} and language_{language}
        abstract language: string with get, set
        /// An array bounding box in the form [ minX,minY,maxX,maxY ] .
        abstract bbox: ResizeArray<float> option with get, set
        /// An array in the form [ longitude,latitude ] at the center of the specified  bbox .
        abstract center: ResizeArray<float> with get, set
        /// An object describing the spatial geometry of the returned feature
        abstract geometry: Geometry with get, set
        /// An array representing the hierarchy of encompassing parent features. Each parent feature may include any of the above properties
        abstract context: ResizeArray<GeocodeFeature> with get, set

    type [<AllowNullLiteral>] Geometry =
        /// Point, a GeoJSON type from the GeoJSON specification .
        abstract ``type``: string with get, set
        /// An array in the format [ longitude,latitude ] at the center of the specified  bbox .
        abstract coordinates: ResizeArray<float> with get, set
        /// A boolean value indicating if an  address is interpolated along a road network. This field is only present when the feature is interpolated.
        abstract interpolated: bool with get, set

    type [<AllowNullLiteral>] GeocodeProperties =
        inherit GeocodeFeature
        /// The Wikidata identifier for the returned feature.
        abstract wikidata: string option with get, set
        /// A string of comma-separated categories for the returned  poi feature.
        abstract category: string option with get, set
        /// A formatted string of the telephone number for the returned  poi feature.
        abstract tel: string option with get, set
        /// The name of a suggested Maki icon to visualize a  poi feature based on its  category .
        abstract maki: string option with get, set
        /// A boolean value indicating whether a  poi feature is a landmark. Landmarks are
        /// particularly notable or long-lived features like schools, parks, museums and places of worship.
        abstract landmark: bool option with get, set
        /// The ISO 3166-1 country and ISO 3166-2 region code for the returned feature.
        abstract short_code: string with get, set

module mapbox_mapbox_sdk_services_map_matching =
    type LngLatLike = MapboxGL.Mapboxgl.LngLatLike
    type DirectionsAnnotation = mapbox_mapbox_sdk_services_directions.DirectionsAnnotation
    type DirectionsGeometry = mapbox_mapbox_sdk_services_directions.DirectionsGeometry
    type DirectionsOverview = mapbox_mapbox_sdk_services_directions.DirectionsOverview
    type Leg = mapbox_mapbox_sdk_services_directions.Leg
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type MapboxProfile = mapbox_mapbox_sdk_lib_classes_mapi_request.MapboxProfile
    type DirectionsApproach = mapbox_mapbox_sdk_lib_classes_mapi_request.DirectionsApproach
    type Coordinates = mapbox_mapbox_sdk_lib_classes_mapi_request.Coordinates
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Map Matching Types
        /// *******************************************************************************************************************
        abstract MapMatching: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> MapMatchingService

    type [<AllowNullLiteral>] MapMatchingService =
        abstract getMatch: request: MapMatchingRequest -> MapiRequest

    type [<AllowNullLiteral>] MapMatchingRequest =
        /// An ordered array of MapMatchingPoints, between 2 and 100 (inclusive).
        abstract points: ResizeArray<MapMatchingPoint> with get, set
        /// A directions profile ID. (optional, default driving)
        abstract profile: MapboxProfile option with get, set
        /// Specify additional metadata that should be returned.
        abstract annotations: DirectionsAnnotation option with get, set
        /// Format of the returned geometry. (optional, default "polyline")
        abstract geometries: DirectionsGeometry option with get, set
        /// Language of returned turn-by-turn text instructions. See supported languages. (optional, default "en")
        abstract language: string option with get, set
        /// Type of returned overview geometry. (optional, default "simplified"
        abstract overview: DirectionsOverview option with get, set
        /// Whether to return steps and turn-by-turn instructions. (optional, default false)
        abstract steps: bool option with get, set
        /// Whether or not to transparently remove clusters and re-sample traces for improved map matching results. (optional, default false)
        abstract tidy: bool option with get, set

    type [<AllowNullLiteral>] Point =
        abstract coordinates: Coordinates with get, set
        /// Used to indicate how requested routes consider from which side of the road to approach a waypoint.
        abstract approach: DirectionsApproach option with get, set

    type [<AllowNullLiteral>] MapMatchingPoint =
        inherit Point
        /// A number in meters indicating the assumed precision of the used tracking device.
        abstract radius: float option with get, set
        /// Whether this coordinate is waypoint or not. The first and last coordinates will always be waypoints.
        abstract isWaypoint: bool option with get, set
        /// Custom name for the waypoint used for the arrival instruction in banners and voice instructions.
        /// Will be ignored unless isWaypoint is true.
        abstract waypointName: bool option with get, set
        /// Datetime corresponding to the coordinate.
        abstract timestamp: U3<string, float, DateTime> option with get, set

    type [<AllowNullLiteral>] MapMatchingResponse =
        /// An array of Match objects.
        abstract matchings: ResizeArray<Matching> with get, set
        /// An array of Tracepoint objects representing the location an input point was matched with.
        /// Array of Waypoint objects representing all input points of the trace in the order they were matched.
        /// If a trace point is omitted by map matching because it is an outlier, the entry will be null.
        abstract tracepoints: ResizeArray<Tracepoint> with get, set
        /// A string depicting the state of the response; see below for options
        abstract code: string with get, set

    type [<AllowNullLiteral>] Tracepoint =
        /// Number of probable alternative matchings for this trace point. A value of zero indicates that this point was matched unambiguously.
        /// Split the trace at these points for incremental map matching.
        abstract alternatives_count: float with get, set
        /// Index of the waypoint inside the matched route.
        abstract waypoint_index: float with get, set
        abstract location: ResizeArray<float> with get, set
        abstract name: string with get, set
        /// Index to the match object in matchings the sub-trace was matched to.
        abstract matchings_index: float with get, set

    type [<AllowNullLiteral>] Matching =
        /// a number between 0 (low) and 1 (high) indicating level of confidence in the returned match
        abstract confidence: float with get, set
        abstract geometry: string with get, set
        abstract legs: ResizeArray<Leg> with get, set
        abstract distance: float with get, set
        abstract duration: float with get, set
        abstract weight_name: string with get, set
        abstract weight: float with get, set

module mapbox_mapbox_sdk_services_matrix =
    type DirectionsAnnotation = mapbox_mapbox_sdk_services_directions.DirectionsAnnotation
    type Point = mapbox_mapbox_sdk_services_map_matching.Point
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type MapboxProfile = mapbox_mapbox_sdk_lib_classes_mapi_request.MapboxProfile
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Matrix Types
        /// *******************************************************************************************************************
        abstract Matrix: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> MatrixService

    type [<AllowNullLiteral>] MatrixService =
        /// <summary>Get a duration and/or distance matrix showing travel times and distances between coordinates.</summary>
        /// <param name="request" />
        abstract getMatrix: request: MatrixRequest -> MapiRequest

    type [<AllowNullLiteral>] MatrixRequest =
        abstract points: ResizeArray<Point> with get, set
        abstract profile: MapboxProfile option with get, set
        abstract sources: U2<ResizeArray<float>, string> option with get, set
        abstract destinations: U2<ResizeArray<float>, string> option with get, set
        abstract annotations: ResizeArray<DirectionsAnnotation> option with get, set

    type [<AllowNullLiteral>] MatrixResponse =
        abstract code: string with get, set
        abstract durations: ResizeArray<ResizeArray<float>> option with get, set
        abstract distances: ResizeArray<ResizeArray<float>> option with get, set
        abstract destinations: ResizeArray<Destination> with get, set
        abstract sources: ResizeArray<Destination> with get, set

    type [<AllowNullLiteral>] Destination =
        abstract location: ResizeArray<float> with get, set
        abstract name: string with get, set

module mapbox_mapbox_sdk_services_optimization =
    type Waypoint = mapbox_mapbox_sdk_services_directions.Waypoint
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type MapboxProfile = mapbox_mapbox_sdk_lib_classes_mapi_request.MapboxProfile
    type DirectionsApproach = mapbox_mapbox_sdk_lib_classes_mapi_request.DirectionsApproach
    type MapiResponse = mapbox_mapbox_sdk_lib_classes_mapi_response.MapiResponse
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Optimization Types
        /// *******************************************************************************************************************
        abstract Optimization: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> OptimizationService

    type [<AllowNullLiteral>] OptimizationService =
        abstract getOptimization: config: OptimizationRequest -> MapiRequest

    type [<AllowNullLiteral>] OptimizationRequest =
        /// A Mapbox Directions routing profile ID.
        abstract profile: MapboxProfile with get, set
        /// A semicolon-separated list of {longitude},{latitude} coordinates. There must be between 2 and 12 coordinates. The first coordinate is the start and end point of the trip.
        abstract waypoints: ResizeArray<Waypoint> with get, set
        /// Return additional metadata along the route. You can include several annotations as a comma-separated list. Possible values are:
        abstract annotations: ResizeArray<OptimizationAnnotation> option with get, set
        /// Specify the destination coordinate of the returned route. Accepts  any (default) or  last .
        abstract destination: OptimizationRequestDestination option with get, set
        /// Specify pick-up and drop-off locations for a trip by providing a ; delimited list of number pairs that correspond with the coordinates list.
        /// The first number of a pair indicates the index to the coordinate of the pick-up location in the coordinates list,
        /// and the second number indicates the index to the coordinate of the drop-off location in the coordinates list.
        /// Each pair must contain exactly 2 numbers, which cannot be the same.
        /// The returned solution will visit pick-up locations before visiting drop-off locations. The first location can only be a pick-up location, not a drop-off location.
        abstract distributions: ResizeArray<Distribution> option with get, set
        /// The format of the returned geometry. Allowed values are:  geojson (as LineString ),  polyline (default, a polyline with precision 5),  polyline6 (a polyline with precision 6).
        abstract geometries: OptimizationRequestGeometries option with get, set
        /// The language of returned turn-by-turn text instructions. See supported languages . The default is  en (English).
        abstract language: string option with get, set
        /// The type of the returned overview geometry.
        /// Can be 'full' (the most detailed geometry available), 'simplified' (default, a simplified version of the full geometry), or 'false' (no overview geometry).
        abstract overview: OptimizationRequestOverview option with get, set
        /// The coordinate at which to start the returned route. Accepts  any (default) or  first .
        abstract source: OptimizationRequestSource option with get, set
        /// Whether to return steps and turn-by-turn instructions ( true ) or not ( false , default).
        abstract steps: bool option with get, set
        /// Indicates whether the returned route is roundtrip, meaning the route returns to the first location ( true , default) or not ( false ).
        /// If roundtrip=false , the  source and  destination parameters are required but not all combinations will be possible.
        /// See the Fixing Start and End Points section below for additional notes.
        abstract roundtrip: bool option with get, set

    type [<AllowNullLiteral>] Distribution =
        /// Array index of the item containing coordinates for the pick-up location in the waypoints array
        abstract pickup: float with get, set
        /// Array index of the item containing coordinates for the drop-off location in the waypoints array
        abstract dropoff: float with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] OptimizationAnnotation =
        | Duration
        | Speed
        | Distance

    type [<StringEnum>] [<RequireQualifiedAccess>] OptimizationRequestDestination =
        | Any
        | Last

    type [<StringEnum>] [<RequireQualifiedAccess>] OptimizationRequestGeometries =
        | Geojson
        | Polyline
        | Polyline6

    type [<StringEnum>] [<RequireQualifiedAccess>] OptimizationRequestOverview =
        | Full
        | Simplified
        | False

    type [<StringEnum>] [<RequireQualifiedAccess>] OptimizationRequestSource =
        | Any
        | First

module mapbox_mapbox_sdk_services_static =
    type LngLatLike = MapboxGL.Mapboxgl.LngLatLike
    type LngLatBoundsLike = MapboxGL.Mapboxgl.LngLatBoundsLike
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Static Map Types
        /// *******************************************************************************************************************
        abstract StaticMap: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> StaticMapService

    type [<AllowNullLiteral>] StaticMapService =
        /// <summary>Get a static map image..</summary>
        /// <param name="request" />
        abstract getStaticImage: request: StaticMapRequest -> MapiRequest

    type [<AllowNullLiteral>] StaticMapRequest =
        abstract ownerId: string with get, set
        abstract styleId: string with get, set
        abstract width: float with get, set
        abstract height: float with get, set
        abstract position: U2<{| coordinates: U2<LngLatLike, string>; zoom: float; bearing: float option; pitch: float option |}, string> with get, set
        abstract padding: string option with get, set
        abstract overlays: Array<U4<CustomMarkerOverlay, SimpleMarkerOverlay, PathOverlay, GeoJsonOverlay>> option with get, set
        abstract highRes: bool option with get, set
        abstract insertOverlayBeforeLayer: string option with get, set
        abstract attribution: bool option with get, set
        abstract logo: bool option with get, set

    type [<AllowNullLiteral>] CustomMarkerOverlay =
        abstract marker: CustomMarker with get, set

    type [<AllowNullLiteral>] CustomMarker =
        abstract coordinates: LngLatLike with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] SimpleMarkerOverlay =
        abstract marker: SimpleMarker with get, set

    type [<AllowNullLiteral>] SimpleMarker =
        abstract coordinates: LngLatLike with get, set
        abstract label: string option with get, set
        abstract color: string option with get, set
        abstract size: SimpleMarkerSize option with get, set

    type [<AllowNullLiteral>] PathOverlay =
        abstract path: Path with get, set

    type [<AllowNullLiteral>] Path =
        /// An array of coordinates describing the path.
        abstract coordinates: ResizeArray<LngLatBoundsLike> with get, set
        abstract strokeWidth: float option with get, set
        abstract strokeColor: string option with get, set
        /// Must be paired with strokeColor.
        abstract strokeOpacity: float option with get, set
        /// Must be paired with strokeColor.
        abstract fillColor: string option with get, set
        /// Must be paired with strokeColor.
        abstract fillOpacity: float option with get, set

    type [<AllowNullLiteral>] GeoJsonOverlay =
        abstract geoJson: GeoJSON.GeoJSON with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] SimpleMarkerSize =
        | Large
        | Small

module mapbox_mapbox_sdk_services_styles =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Style Types
        /// *******************************************************************************************************************
        abstract Styles: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> StylesService

    type [<AllowNullLiteral>] StylesService =
        /// <summary>Get a style.</summary>
        /// <param name="styleId" />
        /// <param name="ownerId" />
        abstract getStyle: config: StylesServiceGetStyleConfig -> MapiRequest
        /// <summary>Create a style.</summary>
        /// <param name="style" />
        /// <param name="ownerId" />
        abstract createStyle: config: {| style: Style; ownerId: string option |} -> MapiRequest
        /// <summary>Update a style.</summary>
        /// <param name="styleId" />
        /// <param name="style" />
        /// <param name="lastKnownModification" />
        /// <param name="ownerId" />
        abstract updateStyle: config: {| styleId: string; style: Style; lastKnownModification: U3<string, float, DateTime> option; ownerId: string option |} -> unit
        /// <summary>Delete a style.</summary>
        /// <param name="style" />
        /// <param name="ownerId" />
        abstract deleteStyle: config: {| style: Style; ownerId: string option |} -> MapiRequest
        /// <summary>List styles in your account.</summary>
        /// <param name="start" />
        /// <param name="ownerId" />
        abstract listStyles: config: {| start: string option; ownerId: string option; fresh: bool option |} -> MapiRequest
        /// <summary>Add an icon to a style, or update an existing one.</summary>
        /// <param name="styleId" />
        /// <param name="iconId" />
        /// <param name="file" />
        /// <param name="ownerId" />
        abstract putStyleIcon: config: {| styleId: string; iconId: string; file: U3<Blob, JS.ArrayBuffer, string>; ownerId: string option |} -> MapiRequest
        /// <summary>Remove an icon from a style.</summary>
        /// <param name="styleId" />
        /// <param name="iconId" />
        /// <param name="ownerId" />
        abstract deleteStyleIcon: config: {| styleId: string; iconId: string; ownerId: string option; draft: bool option |} -> unit
        /// <summary>Get a style sprite's image or JSON document.</summary>
        /// <param name="styleId" />
        /// <param name="format" />
        /// <param name="highRes" />
        /// <param name="ownerId" />
        abstract getStyleSprite: config: StylesServiceGetStyleSpriteConfig -> MapiRequest
        /// <summary>Get a font glyph range.</summary>
        /// <param name="fonts" />
        /// <param name="start" />
        /// <param name="end" />
        /// <param name="ownerId" />
        abstract getFontGlyphRange: config: {| fonts: ResizeArray<string>; start: float; ``end``: float; ownerId: string option |} -> MapiRequest
        /// <summary>Get embeddable HTML displaying a map.</summary>
        /// <param name="config" />
        /// <param name="styleId" />
        /// <param name="scrollZoom" />
        /// <param name="title" />
        /// <param name="ownerId" />
        abstract getEmbeddableHtml: config: StylesServiceGetEmbeddableHtmlConfig -> MapiRequest

    type [<AllowNullLiteral>] StylesServiceGetStyleConfig =
        abstract styleId: string with get, set
        abstract ownerId: string option with get, set
        abstract metadata: bool option with get, set
        abstract draft: bool option with get, set
        abstract fresh: bool option with get, set

    type [<AllowNullLiteral>] StylesServiceGetStyleSpriteConfig =
        abstract styleId: string with get, set
        abstract format: StylesServiceGetStyleSpriteConfigFormat option with get, set
        abstract highRes: bool option with get, set
        abstract ownerId: string option with get, set
        abstract draft: bool option with get, set
        abstract fresh: bool option with get, set

    type [<AllowNullLiteral>] StylesServiceGetEmbeddableHtmlConfig =
        abstract config: obj option with get, set
        abstract styleId: string with get, set
        abstract scrollZoom: bool option with get, set
        abstract title: bool option with get, set
        abstract fallback: bool option with get, set
        abstract mapboxGLVersion: string option with get, set
        abstract mapboxGLGeocoderVersion: string option with get, set
        abstract ownerId: string option with get, set
        abstract draft: string option with get, set

    type [<AllowNullLiteral>] Style =
        abstract version: float with get, set
        abstract name: string with get, set
        /// Information about the style that is used in Mapbox Studio.
        abstract metadata: string with get, set
        abstract sources: obj option with get, set
        abstract sprite: string with get, set
        abstract glyphs: string with get, set
        abstract layers: ResizeArray<string> with get, set
        /// Date and time the style was created.
        abstract created: string with get, set
        /// The ID of the style.
        abstract id: string with get, set
        /// Date and time the style was last modified.
        abstract modified: string with get, set
        /// The username of the style owner.
        abstract owner: string with get, set
        /// Access control for the style, either  public or  private . Private styles require an access token belonging to the owner,
        /// while public styles may be requested with an access token belonging to any user.
        abstract visibility: string with get, set
        /// Whether the style is a draft or has been published.
        abstract draft: bool with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] StylesServiceGetStyleSpriteConfigFormat =
        | Json
        | Png

module mapbox_mapbox_sdk_services_tilequery =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type Coordinates = mapbox_mapbox_sdk_lib_classes_mapi_request.Coordinates
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Tile Query (Places) Types
        /// *******************************************************************************************************************
        abstract TileQuery: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> TileQueryService

    type [<AllowNullLiteral>] TileQueryService =
        /// <summary>Get a static map image..</summary>
        /// <param name="request" />
        abstract listFeatures: request: TileQueryRequest -> MapiRequest

    type [<AllowNullLiteral>] TileQueryRequest =
        /// The maps being queried. If you need to composite multiple layers, provide multiple map IDs.
        abstract mapIds: ResizeArray<string> with get, set
        /// The longitude and latitude to be queried.
        abstract coordinates: Coordinates with get, set
        /// The approximate distance in meters to query for features. (optional, default 0)
        abstract radius: float option with get, set
        /// The number of features to return, between 1 and 50. (optional, default 5)
        abstract limit: float option with get, set
        /// Whether or not to deduplicate results. (optional, default true)
        abstract dedupe: bool option with get, set
        /// Queries for a specific geometry type.
        abstract geometry: GeometryType option with get, set
        abstract layers: ResizeArray<string> option with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] GeometryType =
        | Polygon
        | Linestring
        | Point

module mapbox_mapbox_sdk_services_tilesets =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Tileset Types
        /// *******************************************************************************************************************
        abstract Tilesets: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> TilesetsService

    type [<AllowNullLiteral>] TilesetsService =
        abstract listTilesets: config: TilesetsServiceListTilesetsConfig -> MapiRequest
        abstract deleteTileset: config: {| tilesetId: string |} -> MapiRequest
        abstract tileJSONMetadata: config: {| tilesetId: string |} -> MapiRequest
        abstract createTilesetSource: config: {| id: string; file: U4<Blob, JS.ArrayBuffer, string, JSExt.ReadStream>; ownerId: string option |} -> MapiRequest
        abstract getTilesetSource: config: {| id: string; ownerId: string option |} -> MapiRequest
        abstract listTilesetSources: config: {| ownerId: string option; limit: float option; start: string option |} -> MapiRequest
        abstract deleteTilesetSource: config: {| id: string; ownerId: string option |} -> MapiRequest
        abstract createTileset: config: TilesetsServiceCreateTilesetConfig -> MapiRequest
        abstract publishTileset: config: {| tilesetId: string |} -> MapiRequest
        abstract updateTileset: config: TilesetsServiceUpdateTilesetConfig -> MapiRequest
        abstract tilesetStatus: config: {| tilesetId: string |} -> MapiRequest
        abstract tilesetJob: config: {| tilesetId: string; jobId: string |} -> MapiRequest
        abstract listTilesetJobs: config: {| tilesetId: string; stage: TilesetsServiceListTilesetJobsStage option; limit: float option; start: string option |} -> MapiRequest
        abstract getTilesetsQueue: unit -> MapiRequest
        abstract validateRecipe: config: {| recipe: obj option |} -> MapiRequest
        abstract getRecipe: config: {| tilesetId: string |} -> MapiRequest
        abstract updateRecipe: config: {| tilesetId: string; recipe: obj option |} -> MapiRequest

    type [<AllowNullLiteral>] TilesetsServiceListTilesetsConfig =
        abstract ownerId: string with get, set
        abstract ``type``: TilesetsServiceListTilesetsConfigType option with get, set
        abstract limit: float option with get, set
        abstract sortBy: TilesetsServiceListTilesetsConfigSortBy option with get, set
        abstract start: string option with get, set
        abstract visibility: TilesetsServiceListTilesetsConfigVisibility option with get, set

    type [<AllowNullLiteral>] TilesetsServiceCreateTilesetConfig =
        abstract tilesetId: string with get, set
        abstract recipe: obj option with get, set
        abstract name: string with get, set
        abstract ``private``: bool option with get, set
        abstract description: string option with get, set

    type [<AllowNullLiteral>] TilesetsServiceUpdateTilesetConfig =
        abstract tilesetId: string with get, set
        abstract name: string option with get, set
        abstract description: string option with get, set
        abstract ``private``: bool option with get, set
        abstract attribution: Array<{| text: string option; link: string option |}> option with get, set

    type [<AllowNullLiteral>] Tileset =
        abstract ``type``: string with get, set
        abstract center: ResizeArray<float> with get, set
        abstract created: string with get, set
        abstract description: string with get, set
        abstract filesize: float with get, set
        abstract id: string with get, set
        abstract modified: string with get, set
        abstract name: string with get, set
        abstract visibility: string with get, set
        abstract status: string with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] TilesetsServiceListTilesetJobsStage =
        | Processing
        | Queued
        | Success
        | Failed

    type [<StringEnum>] [<RequireQualifiedAccess>] TilesetsServiceListTilesetsConfigType =
        | Raster
        | Vector

    type [<StringEnum>] [<RequireQualifiedAccess>] TilesetsServiceListTilesetsConfigSortBy =
        | Created
        | Modified

    type [<StringEnum>] [<RequireQualifiedAccess>] TilesetsServiceListTilesetsConfigVisibility =
        | Public
        | Private

module mapbox_mapbox_sdk_services_tokens =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type MapiResponse = mapbox_mapbox_sdk_lib_classes_mapi_response.MapiResponse
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Token Types
        /// *******************************************************************************************************************
        abstract Tokens: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> TokensService

    type [<AllowNullLiteral>] TokensService =
        /// List your access tokens.
        abstract listTokens: unit -> MapiRequest
        /// <summary>Create a new access token.</summary>
        /// <param name="request" />
        abstract createToken: request: CreateTokenRequest -> MapiRequest
        /// <summary>Create a new temporary access token.</summary>
        /// <param name="request" />
        abstract createTemporaryToken: request: TemporaryTokenRequest -> MapiRequest
        /// <summary>Update an access token.</summary>
        /// <param name="request" />
        abstract updateToken: request: UpdateTokenRequest -> MapiRequest
        /// Get data about the client's access token.
        abstract getToken: unit -> MapiRequest
        /// <summary>Delete an access token.</summary>
        /// <param name="request" />
        abstract deleteToken: request: {| tokenId: string |} -> MapiRequest
        /// List your available scopes. Each item is a metadata object about the scope, not just the string scope.
        abstract listScopes: unit -> MapiRequest

    type [<AllowNullLiteral>] Token =
        /// the identifier for the token
        abstract id: string with get, set
        /// the type of token
        abstract usage: string with get, set
        /// the client for the token, always 'api'
        abstract client: string with get, set
        /// if the token is a default token
        abstract ``default``: bool with get, set
        /// human friendly description of the token
        abstract note: string with get, set
        /// array of scopes granted to the token
        abstract scopes: ResizeArray<string> with get, set
        /// date and time the token was created
        abstract created: string with get, set
        /// date and time the token was last modified
        abstract modified: string with get, set
        /// the token itself
        abstract token: string with get, set

    type [<AllowNullLiteral>] CreateTokenRequest =
        abstract note: string option with get, set
        abstract scopes: ResizeArray<string> option with get, set
        abstract resources: ResizeArray<string> option with get, set
        abstract allowedUrls: ResizeArray<string> option with get, set

    type [<AllowNullLiteral>] TemporaryTokenRequest =
        abstract expires: string with get, set
        abstract scopes: ResizeArray<string> with get, set

    type [<AllowNullLiteral>] UpdateTokenRequest =
        inherit CreateTokenRequest
        abstract tokenId: string with get, set

    type [<AllowNullLiteral>] TokenDetail =
        abstract code: string with get, set
        abstract token: Token with get, set

    type [<AllowNullLiteral>] Scope =
        abstract id: string with get, set
        abstract ``public``: bool with get, set
        abstract description: string with get, set

module mapbox_mapbox_sdk_services_uploads =
    type MapiRequest = mapbox_mapbox_sdk_lib_classes_mapi_request.MapiRequest
    type SdkConfig = mapbox_mapbox_sdk_lib_classes_mapi_client.SdkConfig

    type [<AllowNullLiteral>] IExports =
        /// *******************************************************************************************************************
        /// Uploads Types
        /// *******************************************************************************************************************
        abstract Uploads: config: U2<SdkConfig, mapbox_mapbox_sdk_lib_classes_mapi_client.MapiClient> -> UploadsService

    type [<AllowNullLiteral>] UploadsService =
        /// <summary>List the statuses of all recent uploads.</summary>
        /// <param name="config" />
        abstract listUploads: ?config: {| reverse: bool option |} -> MapiRequest
        /// Create S3 credentials.
        abstract createUploadCredentials: unit -> MapiRequest
        /// <summary>Create an upload.</summary>
        /// <param name="config" />
        abstract createUpload: config: {| tileset: string; url: string; name: string option |} -> MapiRequest
        /// <summary>Get an upload's status.</summary>
        /// <param name="config" />
        abstract getUpload: config: {| uploadId: string |} -> obj option
        /// <summary>Delete an upload.</summary>
        /// <param name="config" />
        abstract deleteUpload: config: {| uploadId: string |} -> obj option

    type [<AllowNullLiteral>] S3Credentials =
        abstract accessKeyId: string with get, set
        abstract bucket: string with get, set
        abstract key: string with get, set
        abstract secretAccessKey: string with get, set
        abstract sessionToken: string with get, set
        abstract url: string with get, set

    type [<AllowNullLiteral>] UploadResponse =
        abstract complete: bool with get, set
        abstract tileset: string with get, set
        abstract error: obj option with get, set
        abstract id: string with get, set
        abstract name: string with get, set
        abstract modified: string with get, set
        abstract created: string with get, set
        abstract owner: string with get, set
        abstract progress: float with get, set
