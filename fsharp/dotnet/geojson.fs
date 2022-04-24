// ts2fable 0.8.0-build.638
module rec GeoJSON

#nowarn "3390" // disable warnings for invalid XML comments

open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>


/// <summary>
/// The valid values for the "type" property of GeoJSON geometry objects.
/// <see href="https://tools.ietf.org/html/rfc7946#section-1.4" />
/// </summary>
type GeoJsonGeometryTypes =
    obj

/// <summary>
/// The value values for the "type" property of GeoJSON Objects.
/// <see href="https://tools.ietf.org/html/rfc7946#section-1.4" />
/// </summary>
type GeoJsonTypes =
    obj

/// <summary>
/// Bounding box
/// <see href="https://tools.ietf.org/html/rfc7946#section-5" />
/// </summary>
type BBox =
    U2<float * float * float * float, float * float * float * float * float * float>

/// <summary>
/// A Position is an array of coordinates.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.1" />
/// Array should contain between two and three elements.
/// The previous GeoJSON specification allowed more elements (e.g., which could be used to represent M values),
/// but the current specification only allows X, Y, and (optionally) Z to be defined.
/// </summary>
type Position =
    ResizeArray<float>

/// <summary>
/// The base GeoJSON object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3" />
/// The GeoJSON specification also allows foreign members
/// (<see href="https://tools.ietf.org/html/rfc7946#section-6.1)" />
/// Developers should use "&amp;" type in TypeScript or extend the interface
/// to add these foreign members.
/// </summary>
type [<AllowNullLiteral>] GeoJsonObject =
    /// Specifies the type of GeoJSON object.
    abstract ``type``: GeoJsonTypes with get, set
    /// <summary>
    /// Bounding box of the coordinate range of the object's Geometries, Features, or Feature Collections.
    /// The value of the bbox member is an array of length 2*n where n is the number of dimensions
    /// represented in the contained geometries, with all axes of the most southwesterly point
    /// followed by all axes of the more northeasterly point.
    /// The axes order of a bbox follows the axes order of geometries.
    /// <see href="https://tools.ietf.org/html/rfc7946#section-5" />
    /// </summary>
    abstract bbox: BBox option with get, set

/// Union of GeoJSON objects.
type GeoJSON =
    U3<Geometry, Feature, FeatureCollection>

/// <summary>
/// Geometry object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3" />
/// </summary>
type Geometry =
    U7<Point, MultiPoint, LineString, MultiLineString, Polygon, MultiPolygon, GeometryCollection>

type GeometryObject =
    Geometry

/// <summary>
/// Point geometry object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.2" />
/// </summary>
type [<AllowNullLiteral>] Point =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract coordinates: Position with get, set

/// <summary>
/// MultiPoint geometry object.
///   <see href="https://tools.ietf.org/html/rfc7946#section-3.1.3" />
/// </summary>
type [<AllowNullLiteral>] MultiPoint =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract coordinates: ResizeArray<Position> with get, set

/// <summary>
/// LineString geometry object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.4" />
/// </summary>
type [<AllowNullLiteral>] LineString =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract coordinates: ResizeArray<Position> with get, set

/// <summary>
/// MultiLineString geometry object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.5" />
/// </summary>
type [<AllowNullLiteral>] MultiLineString =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract coordinates: ResizeArray<ResizeArray<Position>> with get, set

/// <summary>
/// Polygon geometry object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.6" />
/// </summary>
type [<AllowNullLiteral>] Polygon =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract coordinates: ResizeArray<ResizeArray<Position>> with get, set

/// <summary>
/// MultiPolygon geometry object.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.7" />
/// </summary>
type [<AllowNullLiteral>] MultiPolygon =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract coordinates: ResizeArray<ResizeArray<ResizeArray<Position>>> with get, set

/// <summary>
/// Geometry Collection
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1.8" />
/// </summary>
type [<AllowNullLiteral>] GeometryCollection =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract geometries: ResizeArray<Geometry> with get, set

/// <summary>
/// A feature object which contains a geometry and associated properties.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.2" />
/// </summary>
type Feature =
    Feature<Geometry, GeoJsonProperties>

/// <summary>
/// A feature object which contains a geometry and associated properties.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.2" />
/// </summary>
type Feature<'G> =
    Feature<'G, GeoJsonProperties>

/// <summary>
/// A feature object which contains a geometry and associated properties.
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.2" />
/// </summary>
type [<AllowNullLiteral>] Feature<'G, 'P> =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    /// The feature's geometry
    abstract geometry: 'G with get, set
    /// <summary>
    /// A value that uniquely identifies this feature in a
    /// <see href="https://tools.ietf.org/html/rfc7946#section-3.2." />
    /// </summary>
    abstract id: U2<string, float> option with get, set
    /// Properties associated with this feature.
    abstract properties: 'P with get, set

/// <summary>
/// A collection of feature objects.
///   <see href="https://tools.ietf.org/html/rfc7946#section-3.3" />
/// </summary>
type FeatureCollection =
    FeatureCollection<Geometry, GeoJsonProperties>

/// <summary>
/// A collection of feature objects.
///   <see href="https://tools.ietf.org/html/rfc7946#section-3.3" />
/// </summary>
type FeatureCollection<'G> =
    FeatureCollection<'G, GeoJsonProperties>

/// <summary>
/// A collection of feature objects.
///   <see href="https://tools.ietf.org/html/rfc7946#section-3.3" />
/// </summary>
type [<AllowNullLiteral>] FeatureCollection<'G, 'P> =
    inherit GeoJsonObject
    /// Specifies the type of GeoJSON object.
    abstract ``type``: string with get, set
    abstract features: Array<Feature<'G, 'P>> with get, set

type [<AllowNullLiteral>] GeoJsonProperties =
    [<EmitIndexer>] abstract Item: name: string -> obj option with get, set
