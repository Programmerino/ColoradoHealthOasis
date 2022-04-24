module rec JSExt

open System
open Browser.Types
open Fable.Core
open Fable.Core.JS
open Fable.React
open Fable
open JS

type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>

module PropTypes =
    type [<AllowNullLiteral>] ValidationMap<'T> =
        interface end

module Fable =
    module React =

        /// <seealso href="https://reactjs.org/docs/hooks-intro.html">React Hooks</seealso>
        [<Obsolete("as of recent React versions, function components can no
    longer be considered 'stateless'. Please use `FunctionComponent` instead.")>]
        type StatelessComponent = FunctionComponent

        type Ref<'T> = IRefValue<'T>

        type NativeMouseEvent =
            Browser.Types.MouseEvent

        type NativeUIEvent =
            Browser.Types.UIEvent
    
        type MouseEvent =
            MouseEvent<Element, NativeMouseEvent>

        type Component =
            Component<obj, obj>

        type Component<'P> = Component<'P, obj>

        type MouseEvent<'T> =
            MouseEvent<'T, NativeMouseEvent>

        type UIEvent =
            UIEvent<Element, NativeUIEvent>

        type UIEvent<'T> =
            UIEvent<'T, NativeUIEvent>

        /// <summary>
        /// currentTarget - a reference to the element on which the event listener is registered.
        /// 
        /// target - a reference to the element from which the event was originally dispatched.
        /// This might be a child element to the element on which the event listener is registered.
        /// If you thought this should be <c>EventTarget &amp; T</c>, see <see href="https://github.com/DefinitelyTyped/DefinitelyTyped/issues/11508#issuecomment-256045682" />
        /// </summary>
        type SyntheticEvent =
            SyntheticEvent<Element, Event>

        /// <summary>
        /// currentTarget - a reference to the element on which the event listener is registered.
        /// 
        /// target - a reference to the element from which the event was originally dispatched.
        /// This might be a child element to the element on which the event listener is registered.
        /// If you thought this should be <c>EventTarget &amp; T</c>, see <see href="https://github.com/DefinitelyTyped/DefinitelyTyped/issues/11508#issuecomment-256045682" />
        /// </summary>
        type SyntheticEvent<'T> =
            SyntheticEvent<'T, Event>

        type BaseSyntheticEvent =
            BaseSyntheticEvent<obj, obj option, obj option>

        type BaseSyntheticEvent<'E> =
            BaseSyntheticEvent<'E, obj option, obj option>

        type BaseSyntheticEvent<'E, 'C> =
            BaseSyntheticEvent<'E, 'C, obj option>

        type [<AllowNullLiteral>] BaseSyntheticEvent<'E, 'C, 'T> =
            abstract nativeEvent: 'E with get, set
            abstract currentTarget: 'C with get, set
            abstract target: 'T with get, set
            abstract bubbles: bool with get, set
            abstract cancelable: bool with get, set
            abstract defaultPrevented: bool with get, set
            abstract eventPhase: float with get, set
            abstract isTrusted: bool with get, set
            abstract preventDefault: unit -> unit
            abstract isDefaultPrevented: unit -> bool
            abstract stopPropagation: unit -> unit
            abstract isPropagationStopped: unit -> bool
            abstract persist: unit -> unit
            abstract timeStamp: float with get, set
            abstract ``type``: string with get, set

        /// <summary>
        /// currentTarget - a reference to the element on which the event listener is registered.
        /// 
        /// target - a reference to the element from which the event was originally dispatched.
        /// This might be a child element to the element on which the event listener is registered.
        /// If you thought this should be <c>EventTarget &amp; T</c>, see <see href="https://github.com/DefinitelyTyped/DefinitelyTyped/issues/11508#issuecomment-256045682" />
        /// </summary>
        type [<AllowNullLiteral>] SyntheticEvent<'T, 'E> =
            inherit BaseSyntheticEvent<'E, obj, EventTarget>

        type [<AllowNullLiteral>] StyleMedia =
            interface end

        type [<AllowNullLiteral>] AbstractView =
            abstract styleMedia: StyleMedia with get, set
            abstract document: Document with get, set

        type [<AllowNullLiteral>] UIEvent<'T, 'E> =
            inherit SyntheticEvent<'T, 'E>
            abstract detail: float with get, set
            abstract view: AbstractView with get, set

        type [<AllowNullLiteral>] MouseEvent<'T, 'E> =
            inherit UIEvent<'T, 'E>
            abstract altKey: bool with get, set
            abstract button: float with get, set
            abstract buttons: float with get, set
            abstract clientX: float with get, set
            abstract clientY: float with get, set
            abstract ctrlKey: bool with get, set
            /// <summary>See <see href="https://www.w3.org/TR/uievents-key/#keys-modifier">DOM Level 3 Events spec</see>. for a list of valid (case-sensitive) arguments to this method.</summary>
            abstract getModifierState: key: string -> bool
            abstract metaKey: bool with get, set
            abstract movementX: float with get, set
            abstract movementY: float with get, set
            abstract pageX: float with get, set
            abstract pageY: float with get, set
            abstract relatedTarget: EventTarget option with get, set
            abstract screenX: float with get, set
            abstract screenY: float with get, set
            abstract shiftKey: bool with get, set

        type ReactNode = Fable.React.ReactElement
        type ElementType = ElementType<obj option>
        type ElementType<'T> = Fable.React.ReactElementType<'T>
        [<Obsolete("Use either `ReactNode[]` if you need an array or `Iterable<ReactNode>` if its passed to a host component.")>]
        type [<AllowNullLiteral>] ReactNodeArray =
            inherit ReadonlyArray<ReactNode>
        
        type ComponentState =
            obj option        
        
        type ComponentClass<'P> =
            ComponentClass<'P, ComponentState>

        type [<AllowNullLiteral>] GetDerivedStateFromProps<'P, 'S> =
            [<Emit "$0($1...)">] abstract Invoke: nextProps: obj * prevState: 'S -> obj option

        type [<AllowNullLiteral>] GetDerivedStateFromError<'P, 'S> =
            [<Emit "$0($1...)">] abstract Invoke: error: obj option -> obj option

        type [<AllowNullLiteral>] StaticLifecycle<'P, 'S> =
            abstract getDerivedStateFromProps: GetDerivedStateFromProps<'P, 'S> option with get, set
            abstract getDerivedStateFromError: GetDerivedStateFromError<'P, 'S> option with get, set

        type [<AllowNullLiteral>] WeakValidationMap<'T> =
            interface end

        type [<AllowNullLiteral>] ExoticComponent<'P> =
            /// **NOTE**: Exotic components are not callable.
            [<Emit "$0($1...)">] abstract Invoke: props: 'P -> ReactElement option
            abstract ``$$typeof``: Symbol

        type [<AllowNullLiteral>] ProviderExoticComponent<'P> =
            inherit ExoticComponent<'P>
            abstract propTypes: WeakValidationMap<'P> option with get, set

        type [<AllowNullLiteral>] ProviderProps<'T> =
            abstract value: 'T with get, set
            abstract children: ReactNode option with get, set

        type Provider<'T> =
            ProviderExoticComponent<ProviderProps<'T>>

        type [<AllowNullLiteral>] ConsumerProps<'T> =
            abstract children: ('T -> ReactNode) with get, set

        type Consumer<'T> =
            ExoticComponent<ConsumerProps<'T>>

        type [<AllowNullLiteral>] Context<'T> =
            abstract Provider: Provider<'T> with get, set
            abstract Consumer: Consumer<'T> with get, set
            abstract displayName: string option with get, set

        type ValidationMap<'T> =
            PropTypes.ValidationMap<'T>

        type [<AllowNullLiteral>] ComponentClass<'P, 'S> =
            inherit StaticLifecycle<'P, 'S>
            abstract propTypes: WeakValidationMap<'P> option with get, set
            abstract contextType: Context<obj option> option with get, set
            abstract contextTypes: ValidationMap<obj option> option with get, set
            abstract childContextTypes: ValidationMap<obj option> option with get, set
            abstract defaultProps: obj option with get, set
            abstract displayName: string option with get, set

[<Erase>] type KeyOf<'T> = Key of string
type Error = Exception
type Symbol = obj

type [<AllowNullLiteral>] Record<'K, 'T> =
    interface end

type [<AllowNullLiteral>] ImageBitmap =
    /// Returns the intrinsic height of the image, in CSS pixels.
    /// Returns the intrinsic height of the image, in CSS pixels.
    abstract height: float
    /// Returns the intrinsic width of the image, in CSS pixels.
    /// Returns the intrinsic width of the image, in CSS pixels.
    abstract width: float
    /// Releases imageBitmap's underlying bitmap data.
    abstract close: unit -> unit

/// The WebContextEvent interface is part of the WebGL API and is an interface for an event that is generated in response to a status change to the WebGL rendering context.
type [<AllowNullLiteral>] WebGLContextEvent =
    inherit Event
    abstract statusMessage: string

type [<AllowNullLiteral>] ImageEncodeOptions =
    abstract quality: float option with get, set
    abstract ``type``: string option with get, set

type [<AllowNullLiteral>] CanvasRenderingContext2DSettings =
    abstract alpha: bool option with get, set
    abstract desynchronized: bool option with get, set

type [<AllowNullLiteral>] CanvasCompositing =
    abstract globalAlpha: float with get, set
    abstract globalCompositeOperation: string with get, set

type [<AllowNullLiteral>] DocumentAndElementEventHandlersEventMap =
    abstract copy: ClipboardEvent with get, set
    abstract cut: ClipboardEvent with get, set
    abstract paste: ClipboardEvent with get, set

type [<AllowNullLiteral>] EventListener =
    [<Emit "$0($1...)">] abstract Invoke: evt: Event -> unit

type [<AllowNullLiteral>] EventListenerObject = abstract handleEvent: evt: Event -> unit

type EventListenerOrEventListenerObject = U2<EventListener, EventListenerObject>

type [<AllowNullLiteral>] EventListenerOptions =
    abstract capture: bool option with get, set

type [<AllowNullLiteral>] DocumentAndElementEventHandlers =
    abstract oncopy: (DocumentAndElementEventHandlers -> ClipboardEvent -> obj option) option with get, set
    abstract oncut: (DocumentAndElementEventHandlers -> ClipboardEvent -> obj option) option with get, set
    abstract onpaste: (DocumentAndElementEventHandlers -> ClipboardEvent -> obj option) option with get, set
    abstract addEventListener: ``type``: KeyOf<DocumentAndElementEventHandlersEventMap> * listener: (DocumentAndElementEventHandlers -> obj -> obj option) * ?options: U2<bool, AddEventListenerOptions> -> unit
    abstract addEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, AddEventListenerOptions> -> unit
    abstract removeEventListener: ``type``: KeyOf<DocumentAndElementEventHandlersEventMap> * listener: (DocumentAndElementEventHandlers -> obj -> obj option) * ?options: U2<bool, EventListenerOptions> -> unit
    abstract removeEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, EventListenerOptions> -> unit


type [<AllowNullLiteral>] CSSRule =
    abstract prototype: CSSRule with get, set
    [<EmitConstructor>] abstract Create: unit -> obj
    abstract CHARSET_RULE: float
    abstract FONT_FACE_RULE: float
    abstract IMPORT_RULE: float
    abstract KEYFRAMES_RULE: float
    abstract KEYFRAME_RULE: float
    abstract MEDIA_RULE: float
    abstract NAMESPACE_RULE: float
    abstract PAGE_RULE: float
    abstract STYLE_RULE: float
    abstract SUPPORTS_RULE: float
    abstract UNKNOWN_RULE: float
    abstract VIEWPORT_RULE: float

/// An object that is a CSS declaration block, and exposes style information and various style-related methods and properties.
type [<AllowNullLiteral>] CSSStyleDeclaration =
    abstract alignContent: string with get, set
    abstract alignItems: string with get, set
    abstract alignSelf: string with get, set
    abstract alignmentBaseline: string with get, set
    abstract animation: string with get, set
    abstract animationDelay: string with get, set
    abstract animationDirection: string with get, set
    abstract animationDuration: string with get, set
    abstract animationFillMode: string with get, set
    abstract animationIterationCount: string with get, set
    abstract animationName: string with get, set
    abstract animationPlayState: string with get, set
    abstract animationTimingFunction: string with get, set
    abstract backfaceVisibility: string with get, set
    abstract background: string with get, set
    abstract backgroundAttachment: string with get, set
    abstract backgroundClip: string with get, set
    abstract backgroundColor: string with get, set
    abstract backgroundImage: string with get, set
    abstract backgroundOrigin: string with get, set
    abstract backgroundPosition: string with get, set
    abstract backgroundPositionX: string with get, set
    abstract backgroundPositionY: string with get, set
    abstract backgroundRepeat: string with get, set
    abstract backgroundSize: string with get, set
    abstract baselineShift: string with get, set
    abstract blockSize: string with get, set
    abstract border: string with get, set
    abstract borderBlockEnd: string with get, set
    abstract borderBlockEndColor: string with get, set
    abstract borderBlockEndStyle: string with get, set
    abstract borderBlockEndWidth: string with get, set
    abstract borderBlockStart: string with get, set
    abstract borderBlockStartColor: string with get, set
    abstract borderBlockStartStyle: string with get, set
    abstract borderBlockStartWidth: string with get, set
    abstract borderBottom: string with get, set
    abstract borderBottomColor: string with get, set
    abstract borderBottomLeftRadius: string with get, set
    abstract borderBottomRightRadius: string with get, set
    abstract borderBottomStyle: string with get, set
    abstract borderBottomWidth: string with get, set
    abstract borderCollapse: string with get, set
    abstract borderColor: string with get, set
    abstract borderImage: string with get, set
    abstract borderImageOutset: string with get, set
    abstract borderImageRepeat: string with get, set
    abstract borderImageSlice: string with get, set
    abstract borderImageSource: string with get, set
    abstract borderImageWidth: string with get, set
    abstract borderInlineEnd: string with get, set
    abstract borderInlineEndColor: string with get, set
    abstract borderInlineEndStyle: string with get, set
    abstract borderInlineEndWidth: string with get, set
    abstract borderInlineStart: string with get, set
    abstract borderInlineStartColor: string with get, set
    abstract borderInlineStartStyle: string with get, set
    abstract borderInlineStartWidth: string with get, set
    abstract borderLeft: string with get, set
    abstract borderLeftColor: string with get, set
    abstract borderLeftStyle: string with get, set
    abstract borderLeftWidth: string with get, set
    abstract borderRadius: string with get, set
    abstract borderRight: string with get, set
    abstract borderRightColor: string with get, set
    abstract borderRightStyle: string with get, set
    abstract borderRightWidth: string with get, set
    abstract borderSpacing: string with get, set
    abstract borderStyle: string with get, set
    abstract borderTop: string with get, set
    abstract borderTopColor: string with get, set
    abstract borderTopLeftRadius: string with get, set
    abstract borderTopRightRadius: string with get, set
    abstract borderTopStyle: string with get, set
    abstract borderTopWidth: string with get, set
    abstract borderWidth: string with get, set
    abstract bottom: string with get, set
    abstract boxShadow: string with get, set
    abstract boxSizing: string with get, set
    abstract breakAfter: string with get, set
    abstract breakBefore: string with get, set
    abstract breakInside: string with get, set
    abstract captionSide: string with get, set
    abstract caretColor: string with get, set
    abstract clear: string with get, set
    abstract clip: string with get, set
    abstract clipPath: string with get, set
    abstract clipRule: string with get, set
    abstract color: string option with get, set
    abstract colorInterpolation: string with get, set
    abstract colorInterpolationFilters: string with get, set
    abstract columnCount: string with get, set
    abstract columnFill: string with get, set
    abstract columnGap: string with get, set
    abstract columnRule: string with get, set
    abstract columnRuleColor: string with get, set
    abstract columnRuleStyle: string with get, set
    abstract columnRuleWidth: string with get, set
    abstract columnSpan: string with get, set
    abstract columnWidth: string with get, set
    abstract columns: string with get, set
    abstract content: string with get, set
    abstract counterIncrement: string with get, set
    abstract counterReset: string with get, set
    abstract cssFloat: string option with get, set
    abstract cssText: string with get, set
    abstract cursor: string with get, set
    abstract direction: string with get, set
    abstract display: string with get, set
    abstract dominantBaseline: string with get, set
    abstract emptyCells: string with get, set
    abstract enableBackground: string option with get, set
    abstract fill: string with get, set
    abstract fillOpacity: string with get, set
    abstract fillRule: string with get, set
    abstract filter: string with get, set
    abstract flex: string with get, set
    abstract flexBasis: string with get, set
    abstract flexDirection: string with get, set
    abstract flexFlow: string with get, set
    abstract flexGrow: string with get, set
    abstract flexShrink: string with get, set
    abstract flexWrap: string with get, set
    abstract float: string with get, set
    abstract floodColor: string with get, set
    abstract floodOpacity: string with get, set
    abstract font: string with get, set
    abstract fontFamily: string with get, set
    abstract fontFeatureSettings: string with get, set
    abstract fontKerning: string with get, set
    abstract fontSize: string with get, set
    abstract fontSizeAdjust: string with get, set
    abstract fontStretch: string with get, set
    abstract fontStyle: string with get, set
    abstract fontSynthesis: string with get, set
    abstract fontVariant: string with get, set
    abstract fontVariantCaps: string with get, set
    abstract fontVariantEastAsian: string with get, set
    abstract fontVariantLigatures: string with get, set
    abstract fontVariantNumeric: string with get, set
    abstract fontVariantPosition: string with get, set
    abstract fontWeight: string with get, set
    abstract gap: string with get, set
    abstract glyphOrientationHorizontal: string option with get, set
    abstract glyphOrientationVertical: string with get, set
    abstract grid: string with get, set
    abstract gridArea: string with get, set
    abstract gridAutoColumns: string with get, set
    abstract gridAutoFlow: string with get, set
    abstract gridAutoRows: string with get, set
    abstract gridColumn: string with get, set
    abstract gridColumnEnd: string with get, set
    abstract gridColumnGap: string with get, set
    abstract gridColumnStart: string with get, set
    abstract gridGap: string with get, set
    abstract gridRow: string with get, set
    abstract gridRowEnd: string with get, set
    abstract gridRowGap: string with get, set
    abstract gridRowStart: string with get, set
    abstract gridTemplate: string with get, set
    abstract gridTemplateAreas: string with get, set
    abstract gridTemplateColumns: string with get, set
    abstract gridTemplateRows: string with get, set
    abstract height: string with get, set
    abstract hyphens: string with get, set
    abstract imageOrientation: string with get, set
    abstract imageRendering: string with get, set
    abstract imeMode: string option with get, set
    abstract inlineSize: string with get, set
    abstract justifyContent: string with get, set
    abstract justifyItems: string with get, set
    abstract justifySelf: string with get, set
    abstract kerning: string option with get, set
    abstract layoutGrid: string option with get, set
    abstract layoutGridChar: string option with get, set
    abstract layoutGridLine: string option with get, set
    abstract layoutGridMode: string option with get, set
    abstract layoutGridType: string option with get, set
    abstract left: string with get, set
    abstract length: float
    abstract letterSpacing: string with get, set
    abstract lightingColor: string with get, set
    abstract lineBreak: string with get, set
    abstract lineHeight: string with get, set
    abstract listStyle: string with get, set
    abstract listStyleImage: string with get, set
    abstract listStylePosition: string with get, set
    abstract listStyleType: string with get, set
    abstract margin: string with get, set
    abstract marginBlockEnd: string with get, set
    abstract marginBlockStart: string with get, set
    abstract marginBottom: string with get, set
    abstract marginInlineEnd: string with get, set
    abstract marginInlineStart: string with get, set
    abstract marginLeft: string with get, set
    abstract marginRight: string with get, set
    abstract marginTop: string with get, set
    abstract marker: string with get, set
    abstract markerEnd: string with get, set
    abstract markerMid: string with get, set
    abstract markerStart: string with get, set
    abstract mask: string with get, set
    abstract maskComposite: string with get, set
    abstract maskImage: string with get, set
    abstract maskPosition: string with get, set
    abstract maskRepeat: string with get, set
    abstract maskSize: string with get, set
    abstract maskType: string with get, set
    abstract maxBlockSize: string with get, set
    abstract maxHeight: string with get, set
    abstract maxInlineSize: string with get, set
    abstract maxWidth: string with get, set
    abstract minBlockSize: string with get, set
    abstract minHeight: string with get, set
    abstract minInlineSize: string with get, set
    abstract minWidth: string with get, set
    abstract msContentZoomChaining: string option with get, set
    abstract msContentZoomLimit: string option with get, set
    abstract msContentZoomLimitMax: obj option with get, set
    abstract msContentZoomLimitMin: obj option with get, set
    abstract msContentZoomSnap: string option with get, set
    abstract msContentZoomSnapPoints: string option with get, set
    abstract msContentZoomSnapType: string option with get, set
    abstract msContentZooming: string option with get, set
    abstract msFlowFrom: string option with get, set
    abstract msFlowInto: string option with get, set
    abstract msFontFeatureSettings: string option with get, set
    abstract msGridColumn: obj option with get, set
    abstract msGridColumnAlign: string option with get, set
    abstract msGridColumnSpan: obj option with get, set
    abstract msGridColumns: string option with get, set
    abstract msGridRow: obj option with get, set
    abstract msGridRowAlign: string option with get, set
    abstract msGridRowSpan: obj option with get, set
    abstract msGridRows: string option with get, set
    abstract msHighContrastAdjust: string option with get, set
    abstract msHyphenateLimitChars: string option with get, set
    abstract msHyphenateLimitLines: obj option with get, set
    abstract msHyphenateLimitZone: obj option with get, set
    abstract msHyphens: string option with get, set
    abstract msImeAlign: string option with get, set
    abstract msOverflowStyle: string option with get, set
    abstract msScrollChaining: string option with get, set
    abstract msScrollLimit: string option with get, set
    abstract msScrollLimitXMax: obj option with get, set
    abstract msScrollLimitXMin: obj option with get, set
    abstract msScrollLimitYMax: obj option with get, set
    abstract msScrollLimitYMin: obj option with get, set
    abstract msScrollRails: string option with get, set
    abstract msScrollSnapPointsX: string option with get, set
    abstract msScrollSnapPointsY: string option with get, set
    abstract msScrollSnapType: string option with get, set
    abstract msScrollSnapX: string option with get, set
    abstract msScrollSnapY: string option with get, set
    abstract msScrollTranslation: string option with get, set
    abstract msTextCombineHorizontal: string option with get, set
    abstract msTextSizeAdjust: obj option with get, set
    abstract msTouchAction: string option with get, set
    abstract msTouchSelect: string option with get, set
    abstract msUserSelect: string option with get, set
    abstract msWrapFlow: string with get, set
    abstract msWrapMargin: obj option with get, set
    abstract msWrapThrough: string with get, set
    abstract objectFit: string with get, set
    abstract objectPosition: string with get, set
    abstract opacity: string option with get, set
    abstract order: string with get, set
    abstract orphans: string with get, set
    abstract outline: string with get, set
    abstract outlineColor: string with get, set
    abstract outlineOffset: string with get, set
    abstract outlineStyle: string with get, set
    abstract outlineWidth: string with get, set
    abstract overflow: string with get, set
    abstract overflowAnchor: string with get, set
    abstract overflowWrap: string with get, set
    abstract overflowX: string with get, set
    abstract overflowY: string with get, set
    abstract padding: string with get, set
    abstract paddingBlockEnd: string with get, set
    abstract paddingBlockStart: string with get, set
    abstract paddingBottom: string with get, set
    abstract paddingInlineEnd: string with get, set
    abstract paddingInlineStart: string with get, set
    abstract paddingLeft: string with get, set
    abstract paddingRight: string with get, set
    abstract paddingTop: string with get, set
    abstract pageBreakAfter: string with get, set
    abstract pageBreakBefore: string with get, set
    abstract pageBreakInside: string with get, set
    abstract paintOrder: string with get, set
    abstract parentRule: CSSRule
    abstract penAction: string option with get, set
    abstract perspective: string with get, set
    abstract perspectiveOrigin: string with get, set
    abstract placeContent: string with get, set
    abstract placeItems: string with get, set
    abstract placeSelf: string with get, set
    abstract pointerEvents: string option with get, set
    abstract position: string with get, set
    abstract quotes: string with get, set
    abstract resize: string with get, set
    abstract right: string with get, set
    abstract rotate: string with get, set
    abstract rowGap: string with get, set
    abstract rubyAlign: string option with get, set
    abstract rubyOverhang: string option with get, set
    abstract rubyPosition: string option with get, set
    abstract scale: string with get, set
    abstract scrollBehavior: string with get, set
    abstract shapeRendering: string with get, set
    abstract stopColor: string option with get, set
    abstract stopOpacity: string option with get, set
    abstract stroke: string with get, set
    abstract strokeDasharray: string with get, set
    abstract strokeDashoffset: string with get, set
    abstract strokeLinecap: string with get, set
    abstract strokeLinejoin: string with get, set
    abstract strokeMiterlimit: string with get, set
    abstract strokeOpacity: string with get, set
    abstract strokeWidth: string with get, set
    abstract tabSize: string with get, set
    abstract tableLayout: string with get, set
    abstract textAlign: string with get, set
    abstract textAlignLast: string with get, set
    abstract textAnchor: string option with get, set
    abstract textCombineUpright: string with get, set
    abstract textDecoration: string with get, set
    abstract textDecorationColor: string with get, set
    abstract textDecorationLine: string with get, set
    abstract textDecorationStyle: string with get, set
    abstract textEmphasis: string with get, set
    abstract textEmphasisColor: string with get, set
    abstract textEmphasisPosition: string with get, set
    abstract textEmphasisStyle: string with get, set
    abstract textIndent: string with get, set
    abstract textJustify: string with get, set
    abstract textKashida: string option with get, set
    abstract textKashidaSpace: string option with get, set
    abstract textOrientation: string with get, set
    abstract textOverflow: string with get, set
    abstract textRendering: string with get, set
    abstract textShadow: string with get, set
    abstract textTransform: string with get, set
    abstract textUnderlinePosition: string with get, set
    abstract top: string with get, set
    abstract touchAction: string with get, set
    abstract transform: string with get, set
    abstract transformBox: string with get, set
    abstract transformOrigin: string with get, set
    abstract transformStyle: string with get, set
    abstract transition: string with get, set
    abstract transitionDelay: string with get, set
    abstract transitionDuration: string with get, set
    abstract transitionProperty: string with get, set
    abstract transitionTimingFunction: string with get, set
    abstract translate: string with get, set
    abstract unicodeBidi: string with get, set
    abstract userSelect: string with get, set
    abstract verticalAlign: string with get, set
    abstract visibility: string with get, set
    [<Obsolete("")>]
    abstract webkitAlignContent: string with get, set
    [<Obsolete("")>]
    abstract webkitAlignItems: string with get, set
    [<Obsolete("")>]
    abstract webkitAlignSelf: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimation: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationDelay: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationDirection: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationDuration: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationFillMode: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationIterationCount: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationName: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationPlayState: string with get, set
    [<Obsolete("")>]
    abstract webkitAnimationTimingFunction: string with get, set
    [<Obsolete("")>]
    abstract webkitAppearance: string with get, set
    [<Obsolete("")>]
    abstract webkitBackfaceVisibility: string with get, set
    [<Obsolete("")>]
    abstract webkitBackgroundClip: string with get, set
    [<Obsolete("")>]
    abstract webkitBackgroundOrigin: string with get, set
    [<Obsolete("")>]
    abstract webkitBackgroundSize: string with get, set
    [<Obsolete("")>]
    abstract webkitBorderBottomLeftRadius: string with get, set
    [<Obsolete("")>]
    abstract webkitBorderBottomRightRadius: string with get, set
    abstract webkitBorderImage: string option with get, set
    [<Obsolete("")>]
    abstract webkitBorderRadius: string with get, set
    [<Obsolete("")>]
    abstract webkitBorderTopLeftRadius: string with get, set
    [<Obsolete("")>]
    abstract webkitBorderTopRightRadius: string with get, set
    [<Obsolete("")>]
    abstract webkitBoxAlign: string with get, set
    abstract webkitBoxDirection: string option with get, set
    [<Obsolete("")>]
    abstract webkitBoxFlex: string with get, set
    [<Obsolete("")>]
    abstract webkitBoxOrdinalGroup: string with get, set
    abstract webkitBoxOrient: string option with get, set
    [<Obsolete("")>]
    abstract webkitBoxPack: string with get, set
    [<Obsolete("")>]
    abstract webkitBoxShadow: string with get, set
    [<Obsolete("")>]
    abstract webkitBoxSizing: string with get, set
    abstract webkitColumnBreakAfter: string option with get, set
    abstract webkitColumnBreakBefore: string option with get, set
    abstract webkitColumnBreakInside: string option with get, set
    abstract webkitColumnCount: obj option with get, set
    abstract webkitColumnGap: obj option with get, set
    abstract webkitColumnRule: string option with get, set
    abstract webkitColumnRuleColor: obj option with get, set
    abstract webkitColumnRuleStyle: string option with get, set
    abstract webkitColumnRuleWidth: obj option with get, set
    abstract webkitColumnSpan: string option with get, set
    abstract webkitColumnWidth: obj option with get, set
    abstract webkitColumns: string option with get, set
    [<Obsolete("")>]
    abstract webkitFilter: string with get, set
    [<Obsolete("")>]
    abstract webkitFlex: string with get, set
    [<Obsolete("")>]
    abstract webkitFlexBasis: string with get, set
    [<Obsolete("")>]
    abstract webkitFlexDirection: string with get, set
    [<Obsolete("")>]
    abstract webkitFlexFlow: string with get, set
    [<Obsolete("")>]
    abstract webkitFlexGrow: string with get, set
    [<Obsolete("")>]
    abstract webkitFlexShrink: string with get, set
    [<Obsolete("")>]
    abstract webkitFlexWrap: string with get, set
    [<Obsolete("")>]
    abstract webkitJustifyContent: string with get, set
    abstract webkitLineClamp: string with get, set
    [<Obsolete("")>]
    abstract webkitMask: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskBoxImage: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskBoxImageOutset: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskBoxImageRepeat: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskBoxImageSlice: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskBoxImageSource: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskBoxImageWidth: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskClip: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskComposite: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskImage: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskOrigin: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskPosition: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskRepeat: string with get, set
    [<Obsolete("")>]
    abstract webkitMaskSize: string with get, set
    [<Obsolete("")>]
    abstract webkitOrder: string with get, set
    [<Obsolete("")>]
    abstract webkitPerspective: string with get, set
    [<Obsolete("")>]
    abstract webkitPerspectiveOrigin: string with get, set
    abstract webkitTapHighlightColor: string option with get, set
    [<Obsolete("")>]
    abstract webkitTextFillColor: string with get, set
    [<Obsolete("")>]
    abstract webkitTextSizeAdjust: string with get, set
    [<Obsolete("")>]
    abstract webkitTextStroke: string with get, set
    [<Obsolete("")>]
    abstract webkitTextStrokeColor: string with get, set
    [<Obsolete("")>]
    abstract webkitTextStrokeWidth: string with get, set
    [<Obsolete("")>]
    abstract webkitTransform: string with get, set
    [<Obsolete("")>]
    abstract webkitTransformOrigin: string with get, set
    [<Obsolete("")>]
    abstract webkitTransformStyle: string with get, set
    [<Obsolete("")>]
    abstract webkitTransition: string with get, set
    [<Obsolete("")>]
    abstract webkitTransitionDelay: string with get, set
    [<Obsolete("")>]
    abstract webkitTransitionDuration: string with get, set
    [<Obsolete("")>]
    abstract webkitTransitionProperty: string with get, set
    [<Obsolete("")>]
    abstract webkitTransitionTimingFunction: string with get, set
    abstract webkitUserModify: string option with get, set
    abstract webkitUserSelect: string option with get, set
    abstract webkitWritingMode: string option with get, set
    abstract whiteSpace: string with get, set
    abstract widows: string with get, set
    abstract width: string with get, set
    abstract willChange: string with get, set
    abstract wordBreak: string with get, set
    abstract wordSpacing: string with get, set
    abstract wordWrap: string with get, set
    abstract writingMode: string with get, set
    abstract zIndex: string with get, set
    abstract zoom: string option with get, set
    abstract getPropertyPriority: propertyName: string -> string
    abstract getPropertyValue: propertyName: string -> string
    abstract item: index: float -> string
    abstract removeProperty: propertyName: string -> string
    abstract setProperty: propertyName: string * value: string option * ?priority: string -> unit
    [<EmitIndexer>] abstract Item: index: float -> string with get, set

type [<AllowNullLiteral>] ElementCSSInlineStyle =
    abstract style: CSSStyleDeclaration

type [<AllowNullLiteral>] FocusOptions =
    abstract preventScroll: bool option with get, set

type [<AllowNullLiteral>] HTMLOrSVGElement =
    abstract dataset: DOMStringMap
    abstract nonce: string option with get, set
    abstract tabIndex: float with get, set
    abstract blur: unit -> unit
    abstract focus: ?options: FocusOptions -> unit

/// Corresponds to the preserveAspectRatio attribute, which is available for some of SVG's elements.
type [<AllowNullLiteral>] SVGPreserveAspectRatio =
    abstract align: float with get, set
    abstract meetOrSlice: float with get, set
    abstract SVG_MEETORSLICE_MEET: float
    abstract SVG_MEETORSLICE_SLICE: float
    abstract SVG_MEETORSLICE_UNKNOWN: float
    abstract SVG_PRESERVEASPECTRATIO_NONE: float
    abstract SVG_PRESERVEASPECTRATIO_UNKNOWN: float
    abstract SVG_PRESERVEASPECTRATIO_XMAXYMAX: float
    abstract SVG_PRESERVEASPECTRATIO_XMAXYMID: float
    abstract SVG_PRESERVEASPECTRATIO_XMAXYMIN: float
    abstract SVG_PRESERVEASPECTRATIO_XMIDYMAX: float
    abstract SVG_PRESERVEASPECTRATIO_XMIDYMID: float
    abstract SVG_PRESERVEASPECTRATIO_XMIDYMIN: float
    abstract SVG_PRESERVEASPECTRATIO_XMINYMAX: float
    abstract SVG_PRESERVEASPECTRATIO_XMINYMID: float
    abstract SVG_PRESERVEASPECTRATIO_XMINYMIN: float

/// Used for attributes of type SVGPreserveAspectRatio which can be animated.
type [<AllowNullLiteral>] SVGAnimatedPreserveAspectRatio =
    abstract animVal: SVGPreserveAspectRatio
    abstract baseVal: SVGPreserveAspectRatio

type [<AllowNullLiteral>] DOMRectReadOnly =
    abstract bottom: float
    abstract height: float
    abstract left: float
    abstract right: float
    abstract top: float
    abstract width: float
    abstract x: float
    abstract y: float
    abstract toJSON: unit -> obj option

type [<AllowNullLiteral>] DOMRect =
    inherit DOMRectReadOnly
    abstract height: float with get, set
    abstract width: float with get, set
    abstract x: float with get, set
    abstract y: float with get, set

/// Used for attributes of basic SVGRect which can be animated.
type [<AllowNullLiteral>] SVGAnimatedRect =
    abstract animVal: DOMRectReadOnly
    abstract baseVal: DOMRect

type [<AllowNullLiteral>] SVGFitToViewBox =
    abstract preserveAspectRatio: SVGAnimatedPreserveAspectRatio
    abstract viewBox: SVGAnimatedRect

/// Used to reflect the zoomAndPan attribute, and is mixed in to other interfaces for elements that support this attribute.
type [<AllowNullLiteral>] SVGZoomAndPan =
    abstract zoomAndPan: float

type SVGPoint =
    DOMPoint

/// Correspond to the <length> basic data type.
type [<AllowNullLiteral>] SVGLength =
    abstract unitType: float
    abstract value: float with get, set
    abstract valueAsString: string with get, set
    abstract valueInSpecifiedUnits: float with get, set
    abstract convertToSpecifiedUnits: unitType: float -> unit
    abstract newValueSpecifiedUnits: unitType: float * valueInSpecifiedUnits: float -> unit
    abstract SVG_LENGTHTYPE_CM: float
    abstract SVG_LENGTHTYPE_EMS: float
    abstract SVG_LENGTHTYPE_EXS: float
    abstract SVG_LENGTHTYPE_IN: float
    abstract SVG_LENGTHTYPE_MM: float
    abstract SVG_LENGTHTYPE_NUMBER: float
    abstract SVG_LENGTHTYPE_PC: float
    abstract SVG_LENGTHTYPE_PERCENTAGE: float
    abstract SVG_LENGTHTYPE_PT: float
    abstract SVG_LENGTHTYPE_PX: float
    abstract SVG_LENGTHTYPE_UNKNOWN: float

/// Used for attributes of basic type <length> which can be animated.
type [<AllowNullLiteral>] SVGAnimatedLength =
    abstract animVal: SVGLength
    abstract baseVal: SVGLength

type SVGRect =
    DOMRect

type [<AllowNullLiteral>] SVGZoomEvent =
    inherit UIEvent
    abstract newScale: float
    abstract newTranslate: SVGPoint
    abstract previousScale: float
    abstract previousTranslate: SVGPoint
    abstract zoomRectScreen: SVGRect

/// Used to represent a value that can be an <angle> or <number> value. An SVGAngle reflected through the animVal attribute is always read only.
type [<AllowNullLiteral>] SVGAngle =
    abstract unitType: float
    abstract value: float with get, set
    abstract valueAsString: string with get, set
    abstract valueInSpecifiedUnits: float with get, set
    abstract convertToSpecifiedUnits: unitType: float -> unit
    abstract newValueSpecifiedUnits: unitType: float * valueInSpecifiedUnits: float -> unit
    abstract SVG_ANGLETYPE_DEG: float
    abstract SVG_ANGLETYPE_GRAD: float
    abstract SVG_ANGLETYPE_RAD: float
    abstract SVG_ANGLETYPE_UNKNOWN: float
    abstract SVG_ANGLETYPE_UNSPECIFIED: float

type SVGMatrix =
    DOMMatrix

/// Corresponds to the <number> basic data type.
type [<AllowNullLiteral>] SVGNumber =
    abstract value: float with get, set

/// SVGTransform is the interface for one of the component transformations within an SVGTransformList; thus, an SVGTransform object corresponds to a single component (e.g., scale(…) or matrix(…)) within a transform attribute.
type [<AllowNullLiteral>] SVGTransform =
    abstract angle: float
    abstract matrix: SVGMatrix
    abstract ``type``: float
    abstract setMatrix: matrix: SVGMatrix -> unit
    abstract setRotate: angle: float * cx: float * cy: float -> unit
    abstract setScale: sx: float * sy: float -> unit
    abstract setSkewX: angle: float -> unit
    abstract setSkewY: angle: float -> unit
    abstract setTranslate: tx: float * ty: float -> unit
    abstract SVG_TRANSFORM_MATRIX: float
    abstract SVG_TRANSFORM_ROTATE: float
    abstract SVG_TRANSFORM_SCALE: float
    abstract SVG_TRANSFORM_SKEWX: float
    abstract SVG_TRANSFORM_SKEWY: float
    abstract SVG_TRANSFORM_TRANSLATE: float
    abstract SVG_TRANSFORM_UNKNOWN: float

type [<AllowNullLiteral>] ElementEventMap =
    abstract fullscreenchange: Event with get, set
    abstract fullscreenerror: Event with get, set

/// Inherits from Event, and represents the event object of an event sent on a document or worker when its content security policy is violated.
type [<AllowNullLiteral>] SecurityPolicyViolationEvent =
    inherit Event
    abstract blockedURI: string
    abstract columnNumber: float
    abstract documentURI: string
    abstract effectiveDirective: string
    abstract lineNumber: float
    abstract originalPolicy: string
    abstract referrer: string
    abstract sourceFile: string
    abstract statusCode: float
    abstract violatedDirective: string

type [<AllowNullLiteral>] GlobalEventHandlersEventMap =
    abstract abort: UIEvent with get, set
    abstract animationcancel: AnimationEvent with get, set
    abstract animationend: AnimationEvent with get, set
    abstract animationiteration: AnimationEvent with get, set
    abstract animationstart: AnimationEvent with get, set
    abstract auxclick: MouseEvent with get, set
    abstract blur: FocusEvent with get, set
    abstract cancel: Event with get, set
    abstract canplay: Event with get, set
    abstract canplaythrough: Event with get, set
    abstract change: Event with get, set
    abstract click: MouseEvent with get, set
    abstract close: Event with get, set
    abstract contextmenu: MouseEvent with get, set
    abstract cuechange: Event with get, set
    abstract dblclick: MouseEvent with get, set
    abstract drag: DragEvent with get, set
    abstract dragend: DragEvent with get, set
    abstract dragenter: DragEvent with get, set
    abstract dragexit: Event with get, set
    abstract dragleave: DragEvent with get, set
    abstract dragover: DragEvent with get, set
    abstract dragstart: DragEvent with get, set
    abstract drop: DragEvent with get, set
    abstract durationchange: Event with get, set
    abstract emptied: Event with get, set
    abstract ended: Event with get, set
    abstract error: ErrorEvent with get, set
    abstract focus: FocusEvent with get, set
    abstract focusin: FocusEvent with get, set
    abstract focusout: FocusEvent with get, set
    abstract gotpointercapture: PointerEvent with get, set
    abstract input: Event with get, set
    abstract invalid: Event with get, set
    abstract keydown: KeyboardEvent with get, set
    abstract keypress: KeyboardEvent with get, set
    abstract keyup: KeyboardEvent with get, set
    abstract load: Event with get, set
    abstract loadeddata: Event with get, set
    abstract loadedmetadata: Event with get, set
    abstract loadend: ProgressEvent with get, set
    abstract loadstart: Event with get, set
    abstract lostpointercapture: PointerEvent with get, set
    abstract mousedown: MouseEvent with get, set
    abstract mouseenter: MouseEvent with get, set
    abstract mouseleave: MouseEvent with get, set
    abstract mousemove: MouseEvent with get, set
    abstract mouseout: MouseEvent with get, set
    abstract mouseover: MouseEvent with get, set
    abstract mouseup: MouseEvent with get, set
    abstract pause: Event with get, set
    abstract play: Event with get, set
    abstract playing: Event with get, set
    abstract pointercancel: PointerEvent with get, set
    abstract pointerdown: PointerEvent with get, set
    abstract pointerenter: PointerEvent with get, set
    abstract pointerleave: PointerEvent with get, set
    abstract pointermove: PointerEvent with get, set
    abstract pointerout: PointerEvent with get, set
    abstract pointerover: PointerEvent with get, set
    abstract pointerup: PointerEvent with get, set
    abstract progress: ProgressEvent with get, set
    abstract ratechange: Event with get, set
    abstract reset: Event with get, set
    abstract resize: UIEvent with get, set
    abstract scroll: Event with get, set
    abstract securitypolicyviolation: SecurityPolicyViolationEvent with get, set
    abstract seeked: Event with get, set
    abstract seeking: Event with get, set
    abstract select: Event with get, set
    abstract selectionchange: Event with get, set
    abstract selectstart: Event with get, set
    abstract stalled: Event with get, set
    abstract submit: Event with get, set
    abstract suspend: Event with get, set
    abstract timeupdate: Event with get, set
    abstract toggle: Event with get, set
    abstract touchcancel: TouchEvent with get, set
    abstract touchend: TouchEvent with get, set
    abstract touchmove: TouchEvent with get, set
    abstract touchstart: TouchEvent with get, set
    abstract transitioncancel: TransitionEvent with get, set
    abstract transitionend: TransitionEvent with get, set
    abstract transitionrun: TransitionEvent with get, set
    abstract transitionstart: TransitionEvent with get, set
    abstract volumechange: Event with get, set
    abstract waiting: Event with get, set
    abstract wheel: WheelEvent with get, set

type [<AllowNullLiteral>] SVGElementEventMap =
    inherit ElementEventMap
    inherit GlobalEventHandlersEventMap
    inherit DocumentAndElementEventHandlersEventMap

type [<AllowNullLiteral>] SVGSVGElementEventMap =
    inherit SVGElementEventMap
    abstract SVGUnload: Event with get, set
    abstract SVGZoom: SVGZoomEvent with get, set

/// Provides access to the properties of <svg> elements, as well as methods to manipulate them. This interface contains also various miscellaneous commonly-used utility methods, such as matrix operations and the ability to control the time of redraw on visual rendering devices.
type [<AllowNullLiteral>] SVGSVGElement =
    inherit SVGGraphicsElement
    inherit DocumentEvent
    inherit SVGFitToViewBox
    inherit SVGZoomAndPan
    [<Obsolete("")>]
    abstract contentScriptType: string with get, set
    [<Obsolete("")>]
    abstract contentStyleType: string with get, set
    abstract currentScale: float with get, set
    abstract currentTranslate: SVGPoint
    abstract height: SVGAnimatedLength
    abstract onunload: (SVGSVGElement -> Event -> obj option) option with get, set
    abstract onzoom: (SVGSVGElement -> SVGZoomEvent -> obj option) option with get, set
    [<Obsolete("")>]
    abstract pixelUnitToMillimeterX: float
    [<Obsolete("")>]
    abstract pixelUnitToMillimeterY: float
    [<Obsolete("")>]
    abstract screenPixelToMillimeterX: float
    [<Obsolete("")>]
    abstract screenPixelToMillimeterY: float
    [<Obsolete("")>]
    abstract viewport: SVGRect
    abstract width: SVGAnimatedLength
    abstract x: SVGAnimatedLength
    abstract y: SVGAnimatedLength
    abstract animationsPaused: unit -> bool
    abstract checkEnclosure: element: SVGElement * rect: SVGRect -> bool
    abstract checkIntersection: element: SVGElement * rect: SVGRect -> bool
    abstract createSVGAngle: unit -> SVGAngle
    abstract createSVGLength: unit -> SVGLength
    abstract createSVGMatrix: unit -> SVGMatrix
    abstract createSVGNumber: unit -> SVGNumber
    abstract createSVGPoint: unit -> SVGPoint
    abstract createSVGRect: unit -> SVGRect
    abstract createSVGTransform: unit -> SVGTransform
    abstract createSVGTransformFromMatrix: matrix: SVGMatrix -> SVGTransform
    abstract deselectAll: unit -> unit
    [<Obsolete("")>]
    abstract forceRedraw: unit -> unit
    abstract getComputedStyle: elt: Element * ?pseudoElt: string -> CSSStyleDeclaration
    abstract getCurrentTime: unit -> float
    abstract getElementById: elementId: string -> Element
    abstract getEnclosureList: rect: SVGRect * referenceElement: SVGElement -> NodeListOf<obj>
    abstract getIntersectionList: rect: SVGRect * referenceElement: SVGElement -> NodeListOf<obj>
    abstract pauseAnimations: unit -> unit
    abstract setCurrentTime: seconds: float -> unit
    [<Obsolete("")>]
    abstract suspendRedraw: maxWaitMilliseconds: float -> float
    abstract unpauseAnimations: unit -> unit
    [<Obsolete("")>]
    abstract unsuspendRedraw: suspendHandleID: float -> unit
    [<Obsolete("")>]
    abstract unsuspendRedrawAll: unit -> unit
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: KeyOf<SVGSVGElementEventMap> * listener: (SVGSVGElement -> obj -> obj option) * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: KeyOf<SVGSVGElementEventMap> * listener: (SVGSVGElement -> obj -> obj option) * ?options: U2<bool, EventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, EventListenerOptions> -> unit


/// All of the SVG DOM interfaces that correspond directly to elements in the SVG language derive from the SVGElement interface.
type [<AllowNullLiteral>] SVGElement =
    inherit Element
    inherit DocumentAndElementEventHandlers
    inherit ElementCSSInlineStyle
    inherit GlobalEventHandlers
    inherit HTMLOrSVGElement
    inherit SVGElementInstance
    /// Returns the value of element's class content attribute. Can be set to change it.
    [<Obsolete("")>]
    abstract className: obj option
    abstract ownerSVGElement: SVGSVGElement option
    abstract viewportElement: SVGElement option
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGElement -> obj -> obj option) * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGElement -> obj -> obj option) * ?options: U2<bool, EventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, EventListenerOptions> -> unit

/// The SVGAnimatedString interface represents string attributes which can be animated from each SVG declaration. You need to create SVG attribute before doing anything else, everything should be declared inside this.
type [<AllowNullLiteral>] SVGAnimatedString =
    abstract animVal: string
    abstract baseVal: string with get, set

type [<AllowNullLiteral>] SVGURIReference =
    abstract href: SVGAnimatedString

/// Corresponds to the <use> element.
type [<AllowNullLiteral>] SVGUseElement =
    inherit SVGGraphicsElement
    inherit SVGURIReference
    abstract animatedInstanceRoot: SVGElementInstance option
    abstract height: SVGAnimatedLength
    abstract instanceRoot: SVGElementInstance option
    abstract width: SVGAnimatedLength
    abstract x: SVGAnimatedLength
    abstract y: SVGAnimatedLength
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGUseElement -> obj -> obj option) * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGUseElement -> obj -> obj option) * ?options: U2<bool, EventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, EventListenerOptions> -> unit

type [<AllowNullLiteral>] SVGElementInstance =
    inherit EventTarget
    abstract correspondingElement: SVGElement
    abstract correspondingUseElement: SVGUseElement

/// The SVGStringList defines a list of DOMString objects.
type [<AllowNullLiteral>] SVGStringList =
    abstract length: float
    abstract numberOfItems: float
    abstract appendItem: newItem: string -> string
    abstract clear: unit -> unit
    abstract getItem: index: float -> string
    abstract initialize: newItem: string -> string
    abstract insertItemBefore: newItem: string * index: float -> string
    abstract removeItem: index: float -> string
    abstract replaceItem: newItem: string * index: float -> string
    [<EmitIndexer>] abstract Item: index: float -> string with get, set

type [<AllowNullLiteral>] SVGTests =
    abstract requiredExtensions: SVGStringList
    abstract systemLanguage: SVGStringList

/// The SVGTransformList defines a list of SVGTransform objects.
type [<AllowNullLiteral>] SVGTransformList =
    abstract numberOfItems: float
    abstract appendItem: newItem: SVGTransform -> SVGTransform
    abstract clear: unit -> unit
    abstract consolidate: unit -> SVGTransform
    abstract createSVGTransformFromMatrix: matrix: SVGMatrix -> SVGTransform
    abstract getItem: index: float -> SVGTransform
    abstract initialize: newItem: SVGTransform -> SVGTransform
    abstract insertItemBefore: newItem: SVGTransform * index: float -> SVGTransform
    abstract removeItem: index: float -> SVGTransform
    abstract replaceItem: newItem: SVGTransform * index: float -> SVGTransform

/// Used for attributes which take a list of numbers and which can be animated.
type [<AllowNullLiteral>] SVGAnimatedTransformList =
    abstract animVal: SVGTransformList
    abstract baseVal: SVGTransformList

type [<AllowNullLiteral>] SVGBoundingBoxOptions =
    abstract clipped: bool option with get, set
    abstract fill: bool option with get, set
    abstract markers: bool option with get, set
    abstract stroke: bool option with get, set

type [<AllowNullLiteral>] DOMMatrix2DInit =
    abstract a: float option with get, set
    abstract b: float option with get, set
    abstract c: float option with get, set
    abstract d: float option with get, set
    abstract e: float option with get, set
    abstract f: float option with get, set
    abstract m11: float option with get, set
    abstract m12: float option with get, set
    abstract m21: float option with get, set
    abstract m22: float option with get, set
    abstract m41: float option with get, set
    abstract m42: float option with get, set

type [<AllowNullLiteral>] DOMMatrixInit =
    inherit DOMMatrix2DInit
    abstract is2D: bool option with get, set
    abstract m13: float option with get, set
    abstract m14: float option with get, set
    abstract m23: float option with get, set
    abstract m24: float option with get, set
    abstract m31: float option with get, set
    abstract m32: float option with get, set
    abstract m33: float option with get, set
    abstract m34: float option with get, set
    abstract m43: float option with get, set
    abstract m44: float option with get, set

type [<AllowNullLiteral>] DOMPointInit =
    abstract w: float option with get, set
    abstract x: float option with get, set
    abstract y: float option with get, set
    abstract z: float option with get, set

type [<AllowNullLiteral>] DOMPointReadOnly =
    abstract w: float
    abstract x: float
    abstract y: float
    abstract z: float
    abstract matrixTransform: ?matrix: DOMMatrixInit -> DOMPoint
    abstract toJSON: unit -> obj option

type [<AllowNullLiteral>] DOMPoint =
    inherit DOMPointReadOnly
    abstract w: float with get, set
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set

type [<AllowNullLiteral>] DOMMatrixReadOnly =
    abstract a: float
    abstract b: float
    abstract c: float
    abstract d: float
    abstract e: float
    abstract f: float
    abstract is2D: bool
    abstract isIdentity: bool
    abstract m11: float
    abstract m12: float
    abstract m13: float
    abstract m14: float
    abstract m21: float
    abstract m22: float
    abstract m23: float
    abstract m24: float
    abstract m31: float
    abstract m32: float
    abstract m33: float
    abstract m34: float
    abstract m41: float
    abstract m42: float
    abstract m43: float
    abstract m44: float
    abstract flipX: unit -> DOMMatrix
    abstract flipY: unit -> DOMMatrix
    abstract inverse: unit -> DOMMatrix
    abstract multiply: ?other: DOMMatrixInit -> DOMMatrix
    abstract rotate: ?rotX: float * ?rotY: float * ?rotZ: float -> DOMMatrix
    abstract rotateAxisAngle: ?x: float * ?y: float * ?z: float * ?angle: float -> DOMMatrix
    abstract rotateFromVector: ?x: float * ?y: float -> DOMMatrix
    abstract scale: ?scaleX: float * ?scaleY: float * ?scaleZ: float * ?originX: float * ?originY: float * ?originZ: float -> DOMMatrix
    abstract scale3d: ?scale: float * ?originX: float * ?originY: float * ?originZ: float -> DOMMatrix
    [<Obsolete("")>]
    abstract scaleNonUniform: ?scaleX: float * ?scaleY: float -> DOMMatrix
    abstract skewX: ?sx: float -> DOMMatrix
    abstract skewY: ?sy: float -> DOMMatrix
    abstract toFloat32Array: unit -> Float32Array
    abstract toFloat64Array: unit -> Float64Array
    abstract toJSON: unit -> obj option
    abstract transformPoint: ?point: DOMPointInit -> DOMPoint
    abstract translate: ?tx: float * ?ty: float * ?tz: float -> DOMMatrix

type [<AllowNullLiteral>] DOMMatrix =
    inherit DOMMatrixReadOnly
    abstract a: float with get, set
    abstract b: float with get, set
    abstract c: float with get, set
    abstract d: float with get, set
    abstract e: float with get, set
    abstract f: float with get, set
    abstract m11: float with get, set
    abstract m12: float with get, set
    abstract m13: float with get, set
    abstract m14: float with get, set
    abstract m21: float with get, set
    abstract m22: float with get, set
    abstract m23: float with get, set
    abstract m24: float with get, set
    abstract m31: float with get, set
    abstract m32: float with get, set
    abstract m33: float with get, set
    abstract m34: float with get, set
    abstract m41: float with get, set
    abstract m42: float with get, set
    abstract m43: float with get, set
    abstract m44: float with get, set
    abstract invertSelf: unit -> DOMMatrix
    abstract multiplySelf: ?other: DOMMatrixInit -> DOMMatrix
    abstract preMultiplySelf: ?other: DOMMatrixInit -> DOMMatrix
    abstract rotateAxisAngleSelf: ?x: float * ?y: float * ?z: float * ?angle: float -> DOMMatrix
    abstract rotateFromVectorSelf: ?x: float * ?y: float -> DOMMatrix
    abstract rotateSelf: ?rotX: float * ?rotY: float * ?rotZ: float -> DOMMatrix
    abstract scale3dSelf: ?scale: float * ?originX: float * ?originY: float * ?originZ: float -> DOMMatrix
    abstract scaleSelf: ?scaleX: float * ?scaleY: float * ?scaleZ: float * ?originX: float * ?originY: float * ?originZ: float -> DOMMatrix
    abstract setMatrixValue: transformList: string -> DOMMatrix
    abstract skewXSelf: ?sx: float -> DOMMatrix
    abstract skewYSelf: ?sy: float -> DOMMatrix
    abstract translateSelf: ?tx: float * ?ty: float * ?tz: float -> DOMMatrix

/// SVG elements whose primary purpose is to directly render graphics into a group.
type [<AllowNullLiteral>] SVGGraphicsElement =
    inherit SVGElement
    inherit SVGTests
    abstract transform: SVGAnimatedTransformList
    abstract getBBox: ?options: SVGBoundingBoxOptions -> DOMRect
    abstract getCTM: unit -> DOMMatrix option
    abstract getScreenCTM: unit -> DOMMatrix option
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGGraphicsElement -> obj -> obj option) * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGGraphicsElement -> obj -> obj option) * ?options: U2<bool, EventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, EventListenerOptions> -> unit

/// Corresponds to the <image> element.
type [<AllowNullLiteral>] SVGImageElement =
    inherit SVGGraphicsElement
    inherit SVGURIReference
    abstract height: SVGAnimatedLength
    abstract preserveAspectRatio: SVGAnimatedPreserveAspectRatio
    abstract width: SVGAnimatedLength
    abstract x: SVGAnimatedLength
    abstract y: SVGAnimatedLength
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGImageElement -> obj -> obj option) * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    /// Appends an event listener for events whose type attribute value is type. The callback argument sets the callback that will be invoked when the event is dispatched.
    /// 
    /// The options argument sets listener-specific options. For compatibility this can be a boolean, in which case the method behaves exactly as if the value was specified as options's capture.
    /// 
    /// When set to true, options's capture prevents callback from being invoked when the event's eventPhase attribute value is BUBBLING_PHASE. When false (or not present), callback will not be invoked when event's eventPhase attribute value is CAPTURING_PHASE. Either way, callback will be invoked if event's eventPhase attribute value is AT_TARGET.
    /// 
    /// When set to true, options's passive indicates that the callback will not cancel the event by invoking preventDefault(). This is used to enable performance optimizations described in §2.8 Observing event listeners.
    /// 
    /// When set to true, options's once indicates that the callback will only be invoked once after which the event listener will be removed.
    /// 
    /// The event listener is appended to target's event listener list and is not appended if it has the same type, callback, and capture.
    abstract addEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, AddEventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: KeyOf<SVGElementEventMap> * listener: (SVGImageElement -> obj -> obj option) * ?options: U2<bool, EventListenerOptions> -> unit
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    /// Removes the event listener in target's event listener list with the same type, callback, and options.
    abstract removeEventListener: ``type``: string * listener: EventListenerOrEventListenerObject * ?options: U2<bool, EventListenerOptions> -> unit

type HTMLOrSVGImageElement =
    U2<HTMLImageElement, SVGImageElement>

type CanvasImageSource =
    U5<HTMLOrSVGImageElement, HTMLVideoElement, HTMLCanvasElement, ImageBitmap, OffscreenCanvas>

type [<AllowNullLiteral>] CanvasDrawImage =
    abstract drawImage: image: CanvasImageSource * dx: float * dy: float -> unit
    abstract drawImage: image: CanvasImageSource * dx: float * dy: float * dw: float * dh: float -> unit
    abstract drawImage: image: CanvasImageSource * sx: float * sy: float * sw: float * sh: float * dx: float * dy: float * dw: float * dh: float -> unit

type [<StringEnum>] [<RequireQualifiedAccess>] CanvasFillRule =
    | Nonzero
    | Evenodd

type [<AllowNullLiteral>] CanvasPath =
    abstract arc: x: float * y: float * radius: float * startAngle: float * endAngle: float * ?anticlockwise: bool -> unit
    abstract arcTo: x1: float * y1: float * x2: float * y2: float * radius: float -> unit
    abstract bezierCurveTo: cp1x: float * cp1y: float * cp2x: float * cp2y: float * x: float * y: float -> unit
    abstract closePath: unit -> unit
    abstract ellipse: x: float * y: float * radiusX: float * radiusY: float * rotation: float * startAngle: float * endAngle: float * ?anticlockwise: bool -> unit
    abstract lineTo: x: float * y: float -> unit
    abstract moveTo: x: float * y: float -> unit
    abstract quadraticCurveTo: cpx: float * cpy: float * x: float * y: float -> unit
    abstract rect: x: float * y: float * w: float * h: float -> unit

/// This Canvas 2D API interface is used to declare a path that can then be used on a CanvasRenderingContext2D object. The path methods of the CanvasRenderingContext2D interface are also present on this interface, which gives you the convenience of being able to retain and replay your path whenever desired.
type [<AllowNullLiteral>] Path2D =
    inherit CanvasPath
    /// Adds to the path the path given by the argument.
    abstract addPath: path: Path2D * ?transform: DOMMatrix2DInit -> unit

type [<AllowNullLiteral>] CanvasDrawPath =
    abstract beginPath: unit -> unit
    abstract clip: ?fillRule: CanvasFillRule -> unit
    abstract clip: path: Path2D * ?fillRule: CanvasFillRule -> unit
    abstract fill: ?fillRule: CanvasFillRule -> unit
    abstract fill: path: Path2D * ?fillRule: CanvasFillRule -> unit
    abstract isPointInPath: x: float * y: float * ?fillRule: CanvasFillRule -> bool
    abstract isPointInPath: path: Path2D * x: float * y: float * ?fillRule: CanvasFillRule -> bool
    abstract isPointInStroke: x: float * y: float -> bool
    abstract isPointInStroke: path: Path2D * x: float * y: float -> bool
    abstract stroke: unit -> unit
    abstract stroke: path: Path2D -> unit

type [<AllowNullLiteral>] CanvasFillStrokeStyles =
    abstract fillStyle: U3<string, CanvasGradient, CanvasPattern> with get, set
    abstract strokeStyle: U3<string, CanvasGradient, CanvasPattern> with get, set
    abstract createLinearGradient: x0: float * y0: float * x1: float * y1: float -> CanvasGradient
    abstract createPattern: image: CanvasImageSource * repetition: string -> CanvasPattern option
    abstract createRadialGradient: x0: float * y0: float * r0: float * x1: float * y1: float * r1: float -> CanvasGradient

type [<AllowNullLiteral>] CanvasFilters =
    abstract filter: string with get, set

type [<AllowNullLiteral>] CanvasImageData =
    abstract createImageData: sw: float * sh: float -> ImageData
    abstract createImageData: imagedata: ImageData -> ImageData
    abstract getImageData: sx: float * sy: float * sw: float * sh: float -> ImageData
    abstract putImageData: imagedata: ImageData * dx: float * dy: float -> unit
    abstract putImageData: imagedata: ImageData * dx: float * dy: float * dirtyX: float * dirtyY: float * dirtyWidth: float * dirtyHeight: float -> unit

type [<StringEnum>] [<RequireQualifiedAccess>] ImageSmoothingQuality =
    | Low
    | Medium
    | High

type [<AllowNullLiteral>] CanvasImageSmoothing =
    abstract imageSmoothingEnabled: bool with get, set
    abstract imageSmoothingQuality: ImageSmoothingQuality with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] CanvasLineCap =
    | Butt
    | Round
    | Square

type [<StringEnum>] [<RequireQualifiedAccess>] CanvasLineJoin =
    | Round
    | Bevel
    | Miter

type [<AllowNullLiteral>] CanvasPathDrawingStyles =
    abstract lineCap: CanvasLineCap with get, set
    abstract lineDashOffset: float with get, set
    abstract lineJoin: CanvasLineJoin with get, set
    abstract lineWidth: float with get, set
    abstract miterLimit: float with get, set
    abstract getLineDash: unit -> ResizeArray<float>
    abstract setLineDash: segments: ResizeArray<float> -> unit

type [<AllowNullLiteral>] CanvasRect =
    abstract clearRect: x: float * y: float * w: float * h: float -> unit
    abstract fillRect: x: float * y: float * w: float * h: float -> unit
    abstract strokeRect: x: float * y: float * w: float * h: float -> unit

type [<AllowNullLiteral>] CanvasShadowStyles =
    abstract shadowBlur: float with get, set
    abstract shadowColor: string with get, set
    abstract shadowOffsetX: float with get, set
    abstract shadowOffsetY: float with get, set

type [<AllowNullLiteral>] CanvasState =
    abstract restore: unit -> unit
    abstract save: unit -> unit

type [<AllowNullLiteral>] CanvasText =
    abstract fillText: text: string * x: float * y: float * ?maxWidth: float -> unit
    abstract measureText: text: string -> TextMetrics
    abstract strokeText: text: string * x: float * y: float * ?maxWidth: float -> unit

type [<StringEnum>] [<RequireQualifiedAccess>] CanvasDirection =
    | Ltr
    | Rtl
    | Inherit

type [<StringEnum>] [<RequireQualifiedAccess>] CanvasTextAlign =
    | Start
    | End
    | Left
    | Right
    | Center

type [<StringEnum>] [<RequireQualifiedAccess>] CanvasTextBaseline =
    | Top
    | Hanging
    | Middle
    | Alphabetic
    | Ideographic
    | Bottom

type [<AllowNullLiteral>] CanvasTextDrawingStyles =
    abstract direction: CanvasDirection with get, set
    abstract font: string with get, set
    abstract textAlign: CanvasTextAlign with get, set
    abstract textBaseline: CanvasTextBaseline with get, set

type [<AllowNullLiteral>] CanvasTransform =
    abstract getTransform: unit -> DOMMatrix
    abstract resetTransform: unit -> unit
    abstract rotate: angle: float -> unit
    abstract scale: x: float * y: float -> unit
    abstract setTransform: a: float * b: float * c: float * d: float * e: float * f: float -> unit
    abstract setTransform: ?transform: DOMMatrix2DInit -> unit
    abstract transform: a: float * b: float * c: float * d: float * e: float * f: float -> unit
    abstract translate: x: float * y: float -> unit

type [<AllowNullLiteral>] OffscreenCanvasRenderingContext2D =
    inherit CanvasCompositing
    inherit CanvasDrawImage
    inherit CanvasDrawPath
    inherit CanvasFillStrokeStyles
    inherit CanvasFilters
    inherit CanvasImageData
    inherit CanvasImageSmoothing
    inherit CanvasPath
    inherit CanvasPathDrawingStyles
    inherit CanvasRect
    inherit CanvasShadowStyles
    inherit CanvasState
    inherit CanvasText
    inherit CanvasTextDrawingStyles
    inherit CanvasTransform
    abstract canvas: OffscreenCanvas
    abstract commit: unit -> unit

type [<AllowNullLiteral>] ImageBitmapRenderingContextSettings =
    abstract alpha: bool option with get, set

type [<AllowNullLiteral>] ImageBitmapRenderingContext =
    /// Returns the canvas element that the context is bound to.
    /// Returns the canvas element that the context is bound to.
    abstract canvas: U2<HTMLCanvasElement, OffscreenCanvas>
    /// Transfers the underlying bitmap data from imageBitmap to context, and the bitmap becomes the contents of the canvas element to which context is bound.
    abstract transferFromImageBitmap: bitmap: ImageBitmap option -> unit

type [<StringEnum>] [<RequireQualifiedAccess>] WebGLPowerPreference =
    | Default
    | [<CompiledName "low-power">] LowPower
    | [<CompiledName "high-performance">] HighPerformance

type [<AllowNullLiteral>] WebGLContextAttributes =
    abstract alpha: bool option with get, set
    abstract antialias: bool option with get, set
    abstract depth: bool option with get, set
    abstract desynchronized: bool option with get, set
    abstract failIfMajorPerformanceCaveat: bool option with get, set
    abstract powerPreference: WebGLPowerPreference option with get, set
    abstract premultipliedAlpha: bool option with get, set
    abstract preserveDrawingBuffer: bool option with get, set
    abstract stencil: bool option with get, set

type GLenum =
    float

type GLint64 =
    float

type [<AllowNullLiteral>] WebGL2RenderingContext =
    abstract prototype: WebGL2RenderingContext with get, set
    [<EmitConstructor>] abstract Create: unit -> obj
    abstract ACTIVE_ATTRIBUTES: GLenum
    abstract ACTIVE_TEXTURE: GLenum
    abstract ACTIVE_UNIFORMS: GLenum
    abstract ALIASED_LINE_WIDTH_RANGE: GLenum
    abstract ALIASED_POINT_SIZE_RANGE: GLenum
    abstract ALPHA: GLenum
    abstract ALPHA_BITS: GLenum
    abstract ALWAYS: GLenum
    abstract ARRAY_BUFFER: GLenum
    abstract ARRAY_BUFFER_BINDING: GLenum
    abstract ATTACHED_SHADERS: GLenum
    abstract BACK: GLenum
    abstract BLEND: GLenum
    abstract BLEND_COLOR: GLenum
    abstract BLEND_DST_ALPHA: GLenum
    abstract BLEND_DST_RGB: GLenum
    abstract BLEND_EQUATION: GLenum
    abstract BLEND_EQUATION_ALPHA: GLenum
    abstract BLEND_EQUATION_RGB: GLenum
    abstract BLEND_SRC_ALPHA: GLenum
    abstract BLEND_SRC_RGB: GLenum
    abstract BLUE_BITS: GLenum
    abstract BOOL: GLenum
    abstract BOOL_VEC2: GLenum
    abstract BOOL_VEC3: GLenum
    abstract BOOL_VEC4: GLenum
    abstract BROWSER_DEFAULT_WEBGL: GLenum
    abstract BUFFER_SIZE: GLenum
    abstract BUFFER_USAGE: GLenum
    abstract BYTE: GLenum
    abstract CCW: GLenum
    abstract CLAMP_TO_EDGE: GLenum
    abstract COLOR_ATTACHMENT0: GLenum
    abstract COLOR_BUFFER_BIT: GLenum
    abstract COLOR_CLEAR_VALUE: GLenum
    abstract COLOR_WRITEMASK: GLenum
    abstract COMPILE_STATUS: GLenum
    abstract COMPRESSED_TEXTURE_FORMATS: GLenum
    abstract CONSTANT_ALPHA: GLenum
    abstract CONSTANT_COLOR: GLenum
    abstract CONTEXT_LOST_WEBGL: GLenum
    abstract CULL_FACE: GLenum
    abstract CULL_FACE_MODE: GLenum
    abstract CURRENT_PROGRAM: GLenum
    abstract CURRENT_VERTEX_ATTRIB: GLenum
    abstract CW: GLenum
    abstract DECR: GLenum
    abstract DECR_WRAP: GLenum
    abstract DELETE_STATUS: GLenum
    abstract DEPTH_ATTACHMENT: GLenum
    abstract DEPTH_BITS: GLenum
    abstract DEPTH_BUFFER_BIT: GLenum
    abstract DEPTH_CLEAR_VALUE: GLenum
    abstract DEPTH_COMPONENT: GLenum
    abstract DEPTH_COMPONENT16: GLenum
    abstract DEPTH_FUNC: GLenum
    abstract DEPTH_RANGE: GLenum
    abstract DEPTH_STENCIL: GLenum
    abstract DEPTH_STENCIL_ATTACHMENT: GLenum
    abstract DEPTH_TEST: GLenum
    abstract DEPTH_WRITEMASK: GLenum
    abstract DITHER: GLenum
    abstract DONT_CARE: GLenum
    abstract DST_ALPHA: GLenum
    abstract DST_COLOR: GLenum
    abstract DYNAMIC_DRAW: GLenum
    abstract ELEMENT_ARRAY_BUFFER: GLenum
    abstract ELEMENT_ARRAY_BUFFER_BINDING: GLenum
    abstract EQUAL: GLenum
    abstract FASTEST: GLenum
    abstract FLOAT: GLenum
    abstract FLOAT_MAT2: GLenum
    abstract FLOAT_MAT3: GLenum
    abstract FLOAT_MAT4: GLenum
    abstract FLOAT_VEC2: GLenum
    abstract FLOAT_VEC3: GLenum
    abstract FLOAT_VEC4: GLenum
    abstract FRAGMENT_SHADER: GLenum
    abstract FRAMEBUFFER: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_OBJECT_NAME: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL: GLenum
    abstract FRAMEBUFFER_BINDING: GLenum
    abstract FRAMEBUFFER_COMPLETE: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_ATTACHMENT: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_DIMENSIONS: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT: GLenum
    abstract FRAMEBUFFER_UNSUPPORTED: GLenum
    abstract FRONT: GLenum
    abstract FRONT_AND_BACK: GLenum
    abstract FRONT_FACE: GLenum
    abstract FUNC_ADD: GLenum
    abstract FUNC_REVERSE_SUBTRACT: GLenum
    abstract FUNC_SUBTRACT: GLenum
    abstract GENERATE_MIPMAP_HINT: GLenum
    abstract GEQUAL: GLenum
    abstract GREATER: GLenum
    abstract GREEN_BITS: GLenum
    abstract HIGH_FLOAT: GLenum
    abstract HIGH_INT: GLenum
    abstract IMPLEMENTATION_COLOR_READ_FORMAT: GLenum
    abstract IMPLEMENTATION_COLOR_READ_TYPE: GLenum
    abstract INCR: GLenum
    abstract INCR_WRAP: GLenum
    abstract INT: GLenum
    abstract INT_VEC2: GLenum
    abstract INT_VEC3: GLenum
    abstract INT_VEC4: GLenum
    abstract INVALID_ENUM: GLenum
    abstract INVALID_FRAMEBUFFER_OPERATION: GLenum
    abstract INVALID_OPERATION: GLenum
    abstract INVALID_VALUE: GLenum
    abstract INVERT: GLenum
    abstract KEEP: GLenum
    abstract LEQUAL: GLenum
    abstract LESS: GLenum
    abstract LINEAR: GLenum
    abstract LINEAR_MIPMAP_LINEAR: GLenum
    abstract LINEAR_MIPMAP_NEAREST: GLenum
    abstract LINES: GLenum
    abstract LINE_LOOP: GLenum
    abstract LINE_STRIP: GLenum
    abstract LINE_WIDTH: GLenum
    abstract LINK_STATUS: GLenum
    abstract LOW_FLOAT: GLenum
    abstract LOW_INT: GLenum
    abstract LUMINANCE: GLenum
    abstract LUMINANCE_ALPHA: GLenum
    abstract MAX_COMBINED_TEXTURE_IMAGE_UNITS: GLenum
    abstract MAX_CUBE_MAP_TEXTURE_SIZE: GLenum
    abstract MAX_FRAGMENT_UNIFORM_VECTORS: GLenum
    abstract MAX_RENDERBUFFER_SIZE: GLenum
    abstract MAX_TEXTURE_IMAGE_UNITS: GLenum
    abstract MAX_TEXTURE_SIZE: GLenum
    abstract MAX_VARYING_VECTORS: GLenum
    abstract MAX_VERTEX_ATTRIBS: GLenum
    abstract MAX_VERTEX_TEXTURE_IMAGE_UNITS: GLenum
    abstract MAX_VERTEX_UNIFORM_VECTORS: GLenum
    abstract MAX_VIEWPORT_DIMS: GLenum
    abstract MEDIUM_FLOAT: GLenum
    abstract MEDIUM_INT: GLenum
    abstract MIRRORED_REPEAT: GLenum
    abstract NEAREST: GLenum
    abstract NEAREST_MIPMAP_LINEAR: GLenum
    abstract NEAREST_MIPMAP_NEAREST: GLenum
    abstract NEVER: GLenum
    abstract NICEST: GLenum
    abstract NONE: GLenum
    abstract NOTEQUAL: GLenum
    abstract NO_ERROR: GLenum
    abstract ONE: GLenum
    abstract ONE_MINUS_CONSTANT_ALPHA: GLenum
    abstract ONE_MINUS_CONSTANT_COLOR: GLenum
    abstract ONE_MINUS_DST_ALPHA: GLenum
    abstract ONE_MINUS_DST_COLOR: GLenum
    abstract ONE_MINUS_SRC_ALPHA: GLenum
    abstract ONE_MINUS_SRC_COLOR: GLenum
    abstract OUT_OF_MEMORY: GLenum
    abstract PACK_ALIGNMENT: GLenum
    abstract POINTS: GLenum
    abstract POLYGON_OFFSET_FACTOR: GLenum
    abstract POLYGON_OFFSET_FILL: GLenum
    abstract POLYGON_OFFSET_UNITS: GLenum
    abstract RED_BITS: GLenum
    abstract RENDERBUFFER: GLenum
    abstract RENDERBUFFER_ALPHA_SIZE: GLenum
    abstract RENDERBUFFER_BINDING: GLenum
    abstract RENDERBUFFER_BLUE_SIZE: GLenum
    abstract RENDERBUFFER_DEPTH_SIZE: GLenum
    abstract RENDERBUFFER_GREEN_SIZE: GLenum
    abstract RENDERBUFFER_HEIGHT: GLenum
    abstract RENDERBUFFER_INTERNAL_FORMAT: GLenum
    abstract RENDERBUFFER_RED_SIZE: GLenum
    abstract RENDERBUFFER_STENCIL_SIZE: GLenum
    abstract RENDERBUFFER_WIDTH: GLenum
    abstract RENDERER: GLenum
    abstract REPEAT: GLenum
    abstract REPLACE: GLenum
    abstract RGB: GLenum
    abstract RGB565: GLenum
    abstract RGB5_A1: GLenum
    abstract RGBA: GLenum
    abstract RGBA4: GLenum
    abstract SAMPLER_2D: GLenum
    abstract SAMPLER_CUBE: GLenum
    abstract SAMPLES: GLenum
    abstract SAMPLE_ALPHA_TO_COVERAGE: GLenum
    abstract SAMPLE_BUFFERS: GLenum
    abstract SAMPLE_COVERAGE: GLenum
    abstract SAMPLE_COVERAGE_INVERT: GLenum
    abstract SAMPLE_COVERAGE_VALUE: GLenum
    abstract SCISSOR_BOX: GLenum
    abstract SCISSOR_TEST: GLenum
    abstract SHADER_TYPE: GLenum
    abstract SHADING_LANGUAGE_VERSION: GLenum
    abstract SHORT: GLenum
    abstract SRC_ALPHA: GLenum
    abstract SRC_ALPHA_SATURATE: GLenum
    abstract SRC_COLOR: GLenum
    abstract STATIC_DRAW: GLenum
    abstract STENCIL_ATTACHMENT: GLenum
    abstract STENCIL_BACK_FAIL: GLenum
    abstract STENCIL_BACK_FUNC: GLenum
    abstract STENCIL_BACK_PASS_DEPTH_FAIL: GLenum
    abstract STENCIL_BACK_PASS_DEPTH_PASS: GLenum
    abstract STENCIL_BACK_REF: GLenum
    abstract STENCIL_BACK_VALUE_MASK: GLenum
    abstract STENCIL_BACK_WRITEMASK: GLenum
    abstract STENCIL_BITS: GLenum
    abstract STENCIL_BUFFER_BIT: GLenum
    abstract STENCIL_CLEAR_VALUE: GLenum
    abstract STENCIL_FAIL: GLenum
    abstract STENCIL_FUNC: GLenum
    abstract STENCIL_INDEX8: GLenum
    abstract STENCIL_PASS_DEPTH_FAIL: GLenum
    abstract STENCIL_PASS_DEPTH_PASS: GLenum
    abstract STENCIL_REF: GLenum
    abstract STENCIL_TEST: GLenum
    abstract STENCIL_VALUE_MASK: GLenum
    abstract STENCIL_WRITEMASK: GLenum
    abstract STREAM_DRAW: GLenum
    abstract SUBPIXEL_BITS: GLenum
    abstract TEXTURE: GLenum
    abstract TEXTURE0: GLenum
    abstract TEXTURE1: GLenum
    abstract TEXTURE10: GLenum
    abstract TEXTURE11: GLenum
    abstract TEXTURE12: GLenum
    abstract TEXTURE13: GLenum
    abstract TEXTURE14: GLenum
    abstract TEXTURE15: GLenum
    abstract TEXTURE16: GLenum
    abstract TEXTURE17: GLenum
    abstract TEXTURE18: GLenum
    abstract TEXTURE19: GLenum
    abstract TEXTURE2: GLenum
    abstract TEXTURE20: GLenum
    abstract TEXTURE21: GLenum
    abstract TEXTURE22: GLenum
    abstract TEXTURE23: GLenum
    abstract TEXTURE24: GLenum
    abstract TEXTURE25: GLenum
    abstract TEXTURE26: GLenum
    abstract TEXTURE27: GLenum
    abstract TEXTURE28: GLenum
    abstract TEXTURE29: GLenum
    abstract TEXTURE3: GLenum
    abstract TEXTURE30: GLenum
    abstract TEXTURE31: GLenum
    abstract TEXTURE4: GLenum
    abstract TEXTURE5: GLenum
    abstract TEXTURE6: GLenum
    abstract TEXTURE7: GLenum
    abstract TEXTURE8: GLenum
    abstract TEXTURE9: GLenum
    abstract TEXTURE_2D: GLenum
    abstract TEXTURE_BINDING_2D: GLenum
    abstract TEXTURE_BINDING_CUBE_MAP: GLenum
    abstract TEXTURE_CUBE_MAP: GLenum
    abstract TEXTURE_CUBE_MAP_NEGATIVE_X: GLenum
    abstract TEXTURE_CUBE_MAP_NEGATIVE_Y: GLenum
    abstract TEXTURE_CUBE_MAP_NEGATIVE_Z: GLenum
    abstract TEXTURE_CUBE_MAP_POSITIVE_X: GLenum
    abstract TEXTURE_CUBE_MAP_POSITIVE_Y: GLenum
    abstract TEXTURE_CUBE_MAP_POSITIVE_Z: GLenum
    abstract TEXTURE_MAG_FILTER: GLenum
    abstract TEXTURE_MIN_FILTER: GLenum
    abstract TEXTURE_WRAP_S: GLenum
    abstract TEXTURE_WRAP_T: GLenum
    abstract TRIANGLES: GLenum
    abstract TRIANGLE_FAN: GLenum
    abstract TRIANGLE_STRIP: GLenum
    abstract UNPACK_ALIGNMENT: GLenum
    abstract UNPACK_COLORSPACE_CONVERSION_WEBGL: GLenum
    abstract UNPACK_FLIP_Y_WEBGL: GLenum
    abstract UNPACK_PREMULTIPLY_ALPHA_WEBGL: GLenum
    abstract UNSIGNED_BYTE: GLenum
    abstract UNSIGNED_INT: GLenum
    abstract UNSIGNED_SHORT: GLenum
    abstract UNSIGNED_SHORT_4_4_4_4: GLenum
    abstract UNSIGNED_SHORT_5_5_5_1: GLenum
    abstract UNSIGNED_SHORT_5_6_5: GLenum
    abstract VALIDATE_STATUS: GLenum
    abstract VENDOR: GLenum
    abstract VERSION: GLenum
    abstract VERTEX_ATTRIB_ARRAY_BUFFER_BINDING: GLenum
    abstract VERTEX_ATTRIB_ARRAY_ENABLED: GLenum
    abstract VERTEX_ATTRIB_ARRAY_NORMALIZED: GLenum
    abstract VERTEX_ATTRIB_ARRAY_POINTER: GLenum
    abstract VERTEX_ATTRIB_ARRAY_SIZE: GLenum
    abstract VERTEX_ATTRIB_ARRAY_STRIDE: GLenum
    abstract VERTEX_ATTRIB_ARRAY_TYPE: GLenum
    abstract VERTEX_SHADER: GLenum
    abstract VIEWPORT: GLenum
    abstract ZERO: GLenum
    abstract ACTIVE_UNIFORM_BLOCKS: GLenum
    abstract ALREADY_SIGNALED: GLenum
    abstract ANY_SAMPLES_PASSED: GLenum
    abstract ANY_SAMPLES_PASSED_CONSERVATIVE: GLenum
    abstract COLOR: GLenum
    abstract COLOR_ATTACHMENT1: GLenum
    abstract COLOR_ATTACHMENT10: GLenum
    abstract COLOR_ATTACHMENT11: GLenum
    abstract COLOR_ATTACHMENT12: GLenum
    abstract COLOR_ATTACHMENT13: GLenum
    abstract COLOR_ATTACHMENT14: GLenum
    abstract COLOR_ATTACHMENT15: GLenum
    abstract COLOR_ATTACHMENT2: GLenum
    abstract COLOR_ATTACHMENT3: GLenum
    abstract COLOR_ATTACHMENT4: GLenum
    abstract COLOR_ATTACHMENT5: GLenum
    abstract COLOR_ATTACHMENT6: GLenum
    abstract COLOR_ATTACHMENT7: GLenum
    abstract COLOR_ATTACHMENT8: GLenum
    abstract COLOR_ATTACHMENT9: GLenum
    abstract COMPARE_REF_TO_TEXTURE: GLenum
    abstract CONDITION_SATISFIED: GLenum
    abstract COPY_READ_BUFFER: GLenum
    abstract COPY_READ_BUFFER_BINDING: GLenum
    abstract COPY_WRITE_BUFFER: GLenum
    abstract COPY_WRITE_BUFFER_BINDING: GLenum
    abstract CURRENT_QUERY: GLenum
    abstract DEPTH: GLenum
    abstract DEPTH24_STENCIL8: GLenum
    abstract DEPTH32F_STENCIL8: GLenum
    abstract DEPTH_COMPONENT24: GLenum
    abstract DEPTH_COMPONENT32F: GLenum
    abstract DRAW_BUFFER0: GLenum
    abstract DRAW_BUFFER1: GLenum
    abstract DRAW_BUFFER10: GLenum
    abstract DRAW_BUFFER11: GLenum
    abstract DRAW_BUFFER12: GLenum
    abstract DRAW_BUFFER13: GLenum
    abstract DRAW_BUFFER14: GLenum
    abstract DRAW_BUFFER15: GLenum
    abstract DRAW_BUFFER2: GLenum
    abstract DRAW_BUFFER3: GLenum
    abstract DRAW_BUFFER4: GLenum
    abstract DRAW_BUFFER5: GLenum
    abstract DRAW_BUFFER6: GLenum
    abstract DRAW_BUFFER7: GLenum
    abstract DRAW_BUFFER8: GLenum
    abstract DRAW_BUFFER9: GLenum
    abstract DRAW_FRAMEBUFFER: GLenum
    abstract DRAW_FRAMEBUFFER_BINDING: GLenum
    abstract DYNAMIC_COPY: GLenum
    abstract DYNAMIC_READ: GLenum
    abstract FLOAT_32_UNSIGNED_INT_24_8_REV: GLenum
    abstract FLOAT_MAT2x3: GLenum
    abstract FLOAT_MAT2x4: GLenum
    abstract FLOAT_MAT3x2: GLenum
    abstract FLOAT_MAT3x4: GLenum
    abstract FLOAT_MAT4x2: GLenum
    abstract FLOAT_MAT4x3: GLenum
    abstract FRAGMENT_SHADER_DERIVATIVE_HINT: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_BLUE_SIZE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_GREEN_SIZE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_RED_SIZE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER: GLenum
    abstract FRAMEBUFFER_DEFAULT: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_MULTISAMPLE: GLenum
    abstract HALF_FLOAT: GLenum
    abstract INTERLEAVED_ATTRIBS: GLenum
    abstract INT_2_10_10_10_REV: GLenum
    abstract INT_SAMPLER_2D: GLenum
    abstract INT_SAMPLER_2D_ARRAY: GLenum
    abstract INT_SAMPLER_3D: GLenum
    abstract INT_SAMPLER_CUBE: GLenum
    abstract INVALID_INDEX: GLenum
    abstract MAX: GLenum
    abstract MAX_3D_TEXTURE_SIZE: GLenum
    abstract MAX_ARRAY_TEXTURE_LAYERS: GLenum
    abstract MAX_CLIENT_WAIT_TIMEOUT_WEBGL: GLenum
    abstract MAX_COLOR_ATTACHMENTS: GLenum
    abstract MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS: GLenum
    abstract MAX_COMBINED_UNIFORM_BLOCKS: GLenum
    abstract MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS: GLenum
    abstract MAX_DRAW_BUFFERS: GLenum
    abstract MAX_ELEMENTS_INDICES: GLenum
    abstract MAX_ELEMENTS_VERTICES: GLenum
    abstract MAX_ELEMENT_INDEX: GLenum
    abstract MAX_FRAGMENT_INPUT_COMPONENTS: GLenum
    abstract MAX_FRAGMENT_UNIFORM_BLOCKS: GLenum
    abstract MAX_FRAGMENT_UNIFORM_COMPONENTS: GLenum
    abstract MAX_PROGRAM_TEXEL_OFFSET: GLenum
    abstract MAX_SAMPLES: GLenum
    abstract MAX_SERVER_WAIT_TIMEOUT: GLenum
    abstract MAX_TEXTURE_LOD_BIAS: GLenum
    abstract MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS: GLenum
    abstract MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS: GLenum
    abstract MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS: GLenum
    abstract MAX_UNIFORM_BLOCK_SIZE: GLenum
    abstract MAX_UNIFORM_BUFFER_BINDINGS: GLenum
    abstract MAX_VARYING_COMPONENTS: GLenum
    abstract MAX_VERTEX_OUTPUT_COMPONENTS: GLenum
    abstract MAX_VERTEX_UNIFORM_BLOCKS: GLenum
    abstract MAX_VERTEX_UNIFORM_COMPONENTS: GLenum
    abstract MIN: GLenum
    abstract MIN_PROGRAM_TEXEL_OFFSET: GLenum
    abstract OBJECT_TYPE: GLenum
    abstract PACK_ROW_LENGTH: GLenum
    abstract PACK_SKIP_PIXELS: GLenum
    abstract PACK_SKIP_ROWS: GLenum
    abstract PIXEL_PACK_BUFFER: GLenum
    abstract PIXEL_PACK_BUFFER_BINDING: GLenum
    abstract PIXEL_UNPACK_BUFFER: GLenum
    abstract PIXEL_UNPACK_BUFFER_BINDING: GLenum
    abstract QUERY_RESULT: GLenum
    abstract QUERY_RESULT_AVAILABLE: GLenum
    abstract R11F_G11F_B10F: GLenum
    abstract R16F: GLenum
    abstract R16I: GLenum
    abstract R16UI: GLenum
    abstract R32F: GLenum
    abstract R32I: GLenum
    abstract R32UI: GLenum
    abstract R8: GLenum
    abstract R8I: GLenum
    abstract R8UI: GLenum
    abstract R8_SNORM: GLenum
    abstract RASTERIZER_DISCARD: GLenum
    abstract READ_BUFFER: GLenum
    abstract READ_FRAMEBUFFER: GLenum
    abstract READ_FRAMEBUFFER_BINDING: GLenum
    abstract RED: GLenum
    abstract RED_INTEGER: GLenum
    abstract RENDERBUFFER_SAMPLES: GLenum
    abstract RG: GLenum
    abstract RG16F: GLenum
    abstract RG16I: GLenum
    abstract RG16UI: GLenum
    abstract RG32F: GLenum
    abstract RG32I: GLenum
    abstract RG32UI: GLenum
    abstract RG8: GLenum
    abstract RG8I: GLenum
    abstract RG8UI: GLenum
    abstract RG8_SNORM: GLenum
    abstract RGB10_A2: GLenum
    abstract RGB10_A2UI: GLenum
    abstract RGB16F: GLenum
    abstract RGB16I: GLenum
    abstract RGB16UI: GLenum
    abstract RGB32F: GLenum
    abstract RGB32I: GLenum
    abstract RGB32UI: GLenum
    abstract RGB8: GLenum
    abstract RGB8I: GLenum
    abstract RGB8UI: GLenum
    abstract RGB8_SNORM: GLenum
    abstract RGB9_E5: GLenum
    abstract RGBA16F: GLenum
    abstract RGBA16I: GLenum
    abstract RGBA16UI: GLenum
    abstract RGBA32F: GLenum
    abstract RGBA32I: GLenum
    abstract RGBA32UI: GLenum
    abstract RGBA8: GLenum
    abstract RGBA8I: GLenum
    abstract RGBA8UI: GLenum
    abstract RGBA8_SNORM: GLenum
    abstract RGBA_INTEGER: GLenum
    abstract RGB_INTEGER: GLenum
    abstract RG_INTEGER: GLenum
    abstract SAMPLER_2D_ARRAY: GLenum
    abstract SAMPLER_2D_ARRAY_SHADOW: GLenum
    abstract SAMPLER_2D_SHADOW: GLenum
    abstract SAMPLER_3D: GLenum
    abstract SAMPLER_BINDING: GLenum
    abstract SAMPLER_CUBE_SHADOW: GLenum
    abstract SEPARATE_ATTRIBS: GLenum
    abstract SIGNALED: GLenum
    abstract SIGNED_NORMALIZED: GLenum
    abstract SRGB: GLenum
    abstract SRGB8: GLenum
    abstract SRGB8_ALPHA8: GLenum
    abstract STATIC_COPY: GLenum
    abstract STATIC_READ: GLenum
    abstract STENCIL: GLenum
    abstract STREAM_COPY: GLenum
    abstract STREAM_READ: GLenum
    abstract SYNC_CONDITION: GLenum
    abstract SYNC_FENCE: GLenum
    abstract SYNC_FLAGS: GLenum
    abstract SYNC_FLUSH_COMMANDS_BIT: GLenum
    abstract SYNC_GPU_COMMANDS_COMPLETE: GLenum
    abstract SYNC_STATUS: GLenum
    abstract TEXTURE_2D_ARRAY: GLenum
    abstract TEXTURE_3D: GLenum
    abstract TEXTURE_BASE_LEVEL: GLenum
    abstract TEXTURE_BINDING_2D_ARRAY: GLenum
    abstract TEXTURE_BINDING_3D: GLenum
    abstract TEXTURE_COMPARE_FUNC: GLenum
    abstract TEXTURE_COMPARE_MODE: GLenum
    abstract TEXTURE_IMMUTABLE_FORMAT: GLenum
    abstract TEXTURE_IMMUTABLE_LEVELS: GLenum
    abstract TEXTURE_MAX_LEVEL: GLenum
    abstract TEXTURE_MAX_LOD: GLenum
    abstract TEXTURE_MIN_LOD: GLenum
    abstract TEXTURE_WRAP_R: GLenum
    abstract TIMEOUT_EXPIRED: GLenum
    abstract TIMEOUT_IGNORED: GLint64
    abstract TRANSFORM_FEEDBACK: GLenum
    abstract TRANSFORM_FEEDBACK_ACTIVE: GLenum
    abstract TRANSFORM_FEEDBACK_BINDING: GLenum
    abstract TRANSFORM_FEEDBACK_BUFFER: GLenum
    abstract TRANSFORM_FEEDBACK_BUFFER_BINDING: GLenum
    abstract TRANSFORM_FEEDBACK_BUFFER_MODE: GLenum
    abstract TRANSFORM_FEEDBACK_BUFFER_SIZE: GLenum
    abstract TRANSFORM_FEEDBACK_BUFFER_START: GLenum
    abstract TRANSFORM_FEEDBACK_PAUSED: GLenum
    abstract TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN: GLenum
    abstract TRANSFORM_FEEDBACK_VARYINGS: GLenum
    abstract UNIFORM_ARRAY_STRIDE: GLenum
    abstract UNIFORM_BLOCK_ACTIVE_UNIFORMS: GLenum
    abstract UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES: GLenum
    abstract UNIFORM_BLOCK_BINDING: GLenum
    abstract UNIFORM_BLOCK_DATA_SIZE: GLenum
    abstract UNIFORM_BLOCK_INDEX: GLenum
    abstract UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER: GLenum
    abstract UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER: GLenum
    abstract UNIFORM_BUFFER: GLenum
    abstract UNIFORM_BUFFER_BINDING: GLenum
    abstract UNIFORM_BUFFER_OFFSET_ALIGNMENT: GLenum
    abstract UNIFORM_BUFFER_SIZE: GLenum
    abstract UNIFORM_BUFFER_START: GLenum
    abstract UNIFORM_IS_ROW_MAJOR: GLenum
    abstract UNIFORM_MATRIX_STRIDE: GLenum
    abstract UNIFORM_OFFSET: GLenum
    abstract UNIFORM_SIZE: GLenum
    abstract UNIFORM_TYPE: GLenum
    abstract UNPACK_IMAGE_HEIGHT: GLenum
    abstract UNPACK_ROW_LENGTH: GLenum
    abstract UNPACK_SKIP_IMAGES: GLenum
    abstract UNPACK_SKIP_PIXELS: GLenum
    abstract UNPACK_SKIP_ROWS: GLenum
    abstract UNSIGNALED: GLenum
    abstract UNSIGNED_INT_10F_11F_11F_REV: GLenum
    abstract UNSIGNED_INT_24_8: GLenum
    abstract UNSIGNED_INT_2_10_10_10_REV: GLenum
    abstract UNSIGNED_INT_5_9_9_9_REV: GLenum
    abstract UNSIGNED_INT_SAMPLER_2D: GLenum
    abstract UNSIGNED_INT_SAMPLER_2D_ARRAY: GLenum
    abstract UNSIGNED_INT_SAMPLER_3D: GLenum
    abstract UNSIGNED_INT_SAMPLER_CUBE: GLenum
    abstract UNSIGNED_INT_VEC2: GLenum
    abstract UNSIGNED_INT_VEC3: GLenum
    abstract UNSIGNED_INT_VEC4: GLenum
    abstract UNSIGNED_NORMALIZED: GLenum
    abstract VERTEX_ARRAY_BINDING: GLenum
    abstract VERTEX_ATTRIB_ARRAY_DIVISOR: GLenum
    abstract VERTEX_ATTRIB_ARRAY_INTEGER: GLenum
    abstract WAIT_FAILED: GLenum

type [<StringEnum>] [<RequireQualifiedAccess>] OffscreenRenderingContextId =
    | [<CompiledName "2d">] N2d
    | Bitmaprenderer
    | Webgl
    | Webgl2

type OffscreenRenderingContext =
    U4<OffscreenCanvasRenderingContext2D, ImageBitmapRenderingContext, WebGLRenderingContext, WebGL2RenderingContext>

type [<AllowNullLiteral>] OffscreenCanvas =
    inherit EventTarget
    /// These attributes return the dimensions of the OffscreenCanvas object's bitmap.
    /// 
    /// They can be set, to replace the bitmap with a new, transparent black bitmap of the specified dimensions (effectively resizing it).
    /// These attributes return the dimensions of the OffscreenCanvas object's bitmap.
    /// 
    /// They can be set, to replace the bitmap with a new, transparent black bitmap of the specified dimensions (effectively resizing it).
    abstract height: float with get, set
    /// These attributes return the dimensions of the OffscreenCanvas object's bitmap.
    /// 
    /// They can be set, to replace the bitmap with a new, transparent black bitmap of the specified dimensions (effectively resizing it).
    /// These attributes return the dimensions of the OffscreenCanvas object's bitmap.
    /// 
    /// They can be set, to replace the bitmap with a new, transparent black bitmap of the specified dimensions (effectively resizing it).
    abstract width: float with get, set
    /// Returns a promise that will fulfill with a new Blob object representing a file containing the image in the OffscreenCanvas object.
    /// 
    /// The argument, if provided, is a dictionary that controls the encoding options of the image file to be created. The type field specifies the file format and has a default value of "image/png"; that type is also used if the requested type isn't supported. If the image format supports variable quality (such as "image/jpeg"), then the quality field is a number in the range 0.0 to 1.0 inclusive indicating the desired quality level for the resulting image.
    abstract convertToBlob: ?options: ImageEncodeOptions -> Promise<Blob>
    /// Returns an object that exposes an API for drawing on the OffscreenCanvas object. contextId specifies the desired API: "2d", "bitmaprenderer", "webgl", or "webgl2". options is handled by that API.
    /// 
    /// This specification defines the "2d" context below, which is similar but distinct from the "2d" context that is created from a canvas element. The WebGL specifications define the "webgl" and "webgl2" contexts. [WEBGL]
    /// 
    /// Returns null if the canvas has already been initialized with another context type (e.g., trying to get a "2d" context after getting a "webgl" context).
    [<Emit "$0.getContext('2d',$1)">] abstract getContext_2d: ?options: CanvasRenderingContext2DSettings -> OffscreenCanvasRenderingContext2D option
    [<Emit "$0.getContext('bitmaprenderer',$1)">] abstract getContext_bitmaprenderer: ?options: ImageBitmapRenderingContextSettings -> ImageBitmapRenderingContext option
    [<Emit "$0.getContext('webgl',$1)">] abstract getContext_webgl: ?options: WebGLContextAttributes -> WebGLRenderingContext option
    [<Emit "$0.getContext('webgl2',$1)">] abstract getContext_webgl2: ?options: WebGLContextAttributes -> WebGL2RenderingContext option
    abstract getContext: contextId: OffscreenRenderingContextId * ?options: obj -> OffscreenRenderingContext option
    /// Returns a newly created ImageBitmap object with the image in the OffscreenCanvas object. The image in the OffscreenCanvas object is replaced with a new blank image.
    abstract transferToImageBitmap: unit -> ImageBitmap

type GLsizei =
    float

type [<AllowNullLiteral>] WebGLObject =
    interface end

/// The WebGLProgram is part of the WebGL API and is a combination of two compiled WebGLShaders consisting of a vertex shader and a fragment shader (both written in GLSL).
type [<AllowNullLiteral>] WebGLProgram =
    inherit WebGLObject

/// The WebGLShader is part of the WebGL API and can either be a vertex or a fragment shader. A WebGLProgram requires both types of shaders.
type [<AllowNullLiteral>] WebGLShader =
    inherit WebGLObject

type GLuint =
    float

/// Part of the WebGL API and represents an opaque buffer object storing data such as vertices or colors.
type [<AllowNullLiteral>] WebGLBuffer =
    inherit WebGLObject

/// Part of the WebGL API and represents a collection of buffers that serve as a rendering destination.
type [<AllowNullLiteral>] WebGLFramebuffer =
    inherit WebGLObject

/// Part of the WebGL API and represents a buffer that can contain an image, or can be source or target of an rendering operation.
type [<AllowNullLiteral>] WebGLRenderbuffer =
    inherit WebGLObject

/// Part of the WebGL API and represents an opaque texture object providing storage and state for texturing operations.
type [<AllowNullLiteral>] WebGLTexture =
    inherit WebGLObject

type GLclampf =
    float

type GLbitfield =
    float

type GLint =
    float

type GLboolean =
    bool

type GLintptr =
    float

/// Part of the WebGL API and represents the information returned by calling the WebGLRenderingContext.getActiveAttrib() and WebGLRenderingContext.getActiveUniform() methods.
type [<AllowNullLiteral>] WebGLActiveInfo =
    abstract name: string
    abstract size: GLint
    abstract ``type``: GLenum

type [<AllowNullLiteral>] EXT_blend_minmax =
    abstract MAX_EXT: GLenum
    abstract MIN_EXT: GLenum

/// The EXT_texture_filter_anisotropic extension is part of the WebGL API and exposes two constants for anisotropic filtering (AF).
type [<AllowNullLiteral>] EXT_texture_filter_anisotropic =
    abstract MAX_TEXTURE_MAX_ANISOTROPY_EXT: GLenum
    abstract TEXTURE_MAX_ANISOTROPY_EXT: GLenum

/// The EXT_frag_depth extension is part of the WebGL API and enables to set a depth value of a fragment from within the fragment shader.
type [<AllowNullLiteral>] EXT_frag_depth =
    interface end

type [<AllowNullLiteral>] EXT_shader_texture_lod =
    interface end

type [<AllowNullLiteral>] EXT_sRGB =
    abstract FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_EXT: GLenum
    abstract SRGB8_ALPHA8_EXT: GLenum
    abstract SRGB_ALPHA_EXT: GLenum
    abstract SRGB_EXT: GLenum

type [<AllowNullLiteral>] WebGLVertexArrayObjectOES =
    inherit WebGLObject

type [<AllowNullLiteral>] OES_vertex_array_object =
    abstract bindVertexArrayOES: arrayObject: WebGLVertexArrayObjectOES option -> unit
    abstract createVertexArrayOES: unit -> WebGLVertexArrayObjectOES option
    abstract deleteVertexArrayOES: arrayObject: WebGLVertexArrayObjectOES option -> unit
    abstract isVertexArrayOES: arrayObject: WebGLVertexArrayObjectOES option -> GLboolean
    abstract VERTEX_ARRAY_BINDING_OES: GLenum

type [<AllowNullLiteral>] WEBGL_color_buffer_float =
    abstract FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_EXT: GLenum
    abstract RGBA32F_EXT: GLenum
    abstract UNSIGNED_NORMALIZED_EXT: GLenum

type [<AllowNullLiteral>] WEBGL_compressed_texture_astc =
    abstract getSupportedProfiles: unit -> ResizeArray<string>
    abstract COMPRESSED_RGBA_ASTC_10x10_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_10x5_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_10x6_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_10x8_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_12x10_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_12x12_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_4x4_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_5x4_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_5x5_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_6x5_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_6x6_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_8x5_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_8x6_KHR: GLenum
    abstract COMPRESSED_RGBA_ASTC_8x8_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_10x10_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_10x5_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_10x6_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_10x8_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_12x10_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_12x12_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_4x4_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_5x4_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_5x5_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_6x5_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_6x6_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_8x5_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_8x6_KHR: GLenum
    abstract COMPRESSED_SRGB8_ALPHA8_ASTC_8x8_KHR: GLenum

type [<AllowNullLiteral>] WEBGL_compressed_texture_s3tc_srgb =
    abstract COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT: GLenum
    abstract COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT: GLenum
    abstract COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT: GLenum
    abstract COMPRESSED_SRGB_S3TC_DXT1_EXT: GLenum

type [<AllowNullLiteral>] WEBGL_debug_shaders =
    abstract getTranslatedShaderSource: shader: WebGLShader -> string

type [<AllowNullLiteral>] WEBGL_draw_buffers =
    abstract drawBuffersWEBGL: buffers: ResizeArray<GLenum> -> unit
    abstract COLOR_ATTACHMENT0_WEBGL: GLenum
    abstract COLOR_ATTACHMENT10_WEBGL: GLenum
    abstract COLOR_ATTACHMENT11_WEBGL: GLenum
    abstract COLOR_ATTACHMENT12_WEBGL: GLenum
    abstract COLOR_ATTACHMENT13_WEBGL: GLenum
    abstract COLOR_ATTACHMENT14_WEBGL: GLenum
    abstract COLOR_ATTACHMENT15_WEBGL: GLenum
    abstract COLOR_ATTACHMENT1_WEBGL: GLenum
    abstract COLOR_ATTACHMENT2_WEBGL: GLenum
    abstract COLOR_ATTACHMENT3_WEBGL: GLenum
    abstract COLOR_ATTACHMENT4_WEBGL: GLenum
    abstract COLOR_ATTACHMENT5_WEBGL: GLenum
    abstract COLOR_ATTACHMENT6_WEBGL: GLenum
    abstract COLOR_ATTACHMENT7_WEBGL: GLenum
    abstract COLOR_ATTACHMENT8_WEBGL: GLenum
    abstract COLOR_ATTACHMENT9_WEBGL: GLenum
    abstract DRAW_BUFFER0_WEBGL: GLenum
    abstract DRAW_BUFFER10_WEBGL: GLenum
    abstract DRAW_BUFFER11_WEBGL: GLenum
    abstract DRAW_BUFFER12_WEBGL: GLenum
    abstract DRAW_BUFFER13_WEBGL: GLenum
    abstract DRAW_BUFFER14_WEBGL: GLenum
    abstract DRAW_BUFFER15_WEBGL: GLenum
    abstract DRAW_BUFFER1_WEBGL: GLenum
    abstract DRAW_BUFFER2_WEBGL: GLenum
    abstract DRAW_BUFFER3_WEBGL: GLenum
    abstract DRAW_BUFFER4_WEBGL: GLenum
    abstract DRAW_BUFFER5_WEBGL: GLenum
    abstract DRAW_BUFFER6_WEBGL: GLenum
    abstract DRAW_BUFFER7_WEBGL: GLenum
    abstract DRAW_BUFFER8_WEBGL: GLenum
    abstract DRAW_BUFFER9_WEBGL: GLenum
    abstract MAX_COLOR_ATTACHMENTS_WEBGL: GLenum
    abstract MAX_DRAW_BUFFERS_WEBGL: GLenum

/// The WEBGL_depth_texture extension is part of the WebGL API and defines 2D depth and depth-stencil textures.
type [<AllowNullLiteral>] WEBGL_depth_texture =
    abstract UNSIGNED_INT_24_8_WEBGL: GLenum

type [<AllowNullLiteral>] WEBGL_lose_context =
    abstract loseContext: unit -> unit
    abstract restoreContext: unit -> unit

/// The WEBGL_debug_renderer_info extension is part of the WebGL API and exposes two constants with information about the graphics driver for debugging purposes.
type [<AllowNullLiteral>] WEBGL_debug_renderer_info =
    abstract UNMASKED_RENDERER_WEBGL: GLenum
    abstract UNMASKED_VENDOR_WEBGL: GLenum

/// The WEBGL_compressed_texture_s3tc extension is part of the WebGL API and exposes four S3TC compressed texture formats.
type [<AllowNullLiteral>] WEBGL_compressed_texture_s3tc =
    abstract COMPRESSED_RGBA_S3TC_DXT1_EXT: GLenum
    abstract COMPRESSED_RGBA_S3TC_DXT3_EXT: GLenum
    abstract COMPRESSED_RGBA_S3TC_DXT5_EXT: GLenum
    abstract COMPRESSED_RGB_S3TC_DXT1_EXT: GLenum

/// The OES_texture_half_float_linear extension is part of the WebGL API and allows linear filtering with half floating-point pixel types for textures.
type [<AllowNullLiteral>] OES_texture_half_float_linear =
    interface end

/// The OES_texture_half_float extension is part of the WebGL API and adds texture formats with 16- (aka half float) and 32-bit floating-point components.
type [<AllowNullLiteral>] OES_texture_half_float =
    abstract HALF_FLOAT_OES: GLenum

/// The OES_texture_float_linear extension is part of the WebGL API and allows linear filtering with floating-point pixel types for textures.
type [<AllowNullLiteral>] OES_texture_float_linear =
    interface end

/// The OES_texture_float extension is part of the WebGL API and exposes floating-point pixel types for textures.
type [<AllowNullLiteral>] OES_texture_float =
    interface end

/// The OES_standard_derivatives extension is part of the WebGL API and adds the GLSL derivative functions dFdx, dFdy, and fwidth.
type [<AllowNullLiteral>] OES_standard_derivatives =
    abstract FRAGMENT_SHADER_DERIVATIVE_HINT_OES: GLenum

/// The OES_element_index_uint extension is part of the WebGL API and adds support for gl.UNSIGNED_INT types to WebGLRenderingContext.drawElements().
type [<AllowNullLiteral>] OES_element_index_uint =
    interface end

/// The ANGLE_instanced_arrays extension is part of the WebGL API and allows to draw the same object, or groups of similar objects multiple times, if they share the same vertex data, primitive count and type.
type [<AllowNullLiteral>] ANGLE_instanced_arrays =
    abstract drawArraysInstancedANGLE: mode: GLenum * first: GLint * count: GLsizei * primcount: GLsizei -> unit
    abstract drawElementsInstancedANGLE: mode: GLenum * count: GLsizei * ``type``: GLenum * offset: GLintptr * primcount: GLsizei -> unit
    abstract vertexAttribDivisorANGLE: index: GLuint * divisor: GLuint -> unit
    abstract VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE: GLenum

/// Part of the WebGL API and represents the information returned by calling the WebGLRenderingContext.getShaderPrecisionFormat() method.
type [<AllowNullLiteral>] WebGLShaderPrecisionFormat =
    abstract precision: GLint
    abstract rangeMax: GLint
    abstract rangeMin: GLint

/// Part of the WebGL API and represents the location of a uniform variable in a shader program.
type [<AllowNullLiteral>] WebGLUniformLocation =
    interface end

type GLfloat =
    float

type Float32List =
    U2<Float32Array, ResizeArray<GLfloat>>

type [<AllowNullLiteral>] WebGLRenderingContextBase =
    abstract canvas: U2<HTMLCanvasElement, OffscreenCanvas>
    abstract drawingBufferHeight: GLsizei
    abstract drawingBufferWidth: GLsizei
    abstract activeTexture: texture: GLenum -> unit
    abstract attachShader: program: WebGLProgram * shader: WebGLShader -> unit
    abstract bindAttribLocation: program: WebGLProgram * index: GLuint * name: string -> unit
    abstract bindBuffer: target: GLenum * buffer: WebGLBuffer option -> unit
    abstract bindFramebuffer: target: GLenum * framebuffer: WebGLFramebuffer option -> unit
    abstract bindRenderbuffer: target: GLenum * renderbuffer: WebGLRenderbuffer option -> unit
    abstract bindTexture: target: GLenum * texture: WebGLTexture option -> unit
    abstract blendColor: red: GLclampf * green: GLclampf * blue: GLclampf * alpha: GLclampf -> unit
    abstract blendEquation: mode: GLenum -> unit
    abstract blendEquationSeparate: modeRGB: GLenum * modeAlpha: GLenum -> unit
    abstract blendFunc: sfactor: GLenum * dfactor: GLenum -> unit
    abstract blendFuncSeparate: srcRGB: GLenum * dstRGB: GLenum * srcAlpha: GLenum * dstAlpha: GLenum -> unit
    abstract checkFramebufferStatus: target: GLenum -> GLenum
    abstract clear: mask: GLbitfield -> unit
    abstract clearColor: red: GLclampf * green: GLclampf * blue: GLclampf * alpha: GLclampf -> unit
    abstract clearDepth: depth: GLclampf -> unit
    abstract clearStencil: s: GLint -> unit
    abstract colorMask: red: GLboolean * green: GLboolean * blue: GLboolean * alpha: GLboolean -> unit
    abstract compileShader: shader: WebGLShader -> unit
    abstract copyTexImage2D: target: GLenum * level: GLint * internalformat: GLenum * x: GLint * y: GLint * width: GLsizei * height: GLsizei * border: GLint -> unit
    abstract copyTexSubImage2D: target: GLenum * level: GLint * xoffset: GLint * yoffset: GLint * x: GLint * y: GLint * width: GLsizei * height: GLsizei -> unit
    abstract createBuffer: unit -> WebGLBuffer option
    abstract createFramebuffer: unit -> WebGLFramebuffer option
    abstract createProgram: unit -> WebGLProgram option
    abstract createRenderbuffer: unit -> WebGLRenderbuffer option
    abstract createShader: ``type``: GLenum -> WebGLShader option
    abstract createTexture: unit -> WebGLTexture option
    abstract cullFace: mode: GLenum -> unit
    abstract deleteBuffer: buffer: WebGLBuffer option -> unit
    abstract deleteFramebuffer: framebuffer: WebGLFramebuffer option -> unit
    abstract deleteProgram: program: WebGLProgram option -> unit
    abstract deleteRenderbuffer: renderbuffer: WebGLRenderbuffer option -> unit
    abstract deleteShader: shader: WebGLShader option -> unit
    abstract deleteTexture: texture: WebGLTexture option -> unit
    abstract depthFunc: func: GLenum -> unit
    abstract depthMask: flag: GLboolean -> unit
    abstract depthRange: zNear: GLclampf * zFar: GLclampf -> unit
    abstract detachShader: program: WebGLProgram * shader: WebGLShader -> unit
    abstract disable: cap: GLenum -> unit
    abstract disableVertexAttribArray: index: GLuint -> unit
    abstract drawArrays: mode: GLenum * first: GLint * count: GLsizei -> unit
    abstract drawElements: mode: GLenum * count: GLsizei * ``type``: GLenum * offset: GLintptr -> unit
    abstract enable: cap: GLenum -> unit
    abstract enableVertexAttribArray: index: GLuint -> unit
    abstract finish: unit -> unit
    abstract flush: unit -> unit
    abstract framebufferRenderbuffer: target: GLenum * attachment: GLenum * renderbuffertarget: GLenum * renderbuffer: WebGLRenderbuffer option -> unit
    abstract framebufferTexture2D: target: GLenum * attachment: GLenum * textarget: GLenum * texture: WebGLTexture option * level: GLint -> unit
    abstract frontFace: mode: GLenum -> unit
    abstract generateMipmap: target: GLenum -> unit
    abstract getActiveAttrib: program: WebGLProgram * index: GLuint -> WebGLActiveInfo option
    abstract getActiveUniform: program: WebGLProgram * index: GLuint -> WebGLActiveInfo option
    abstract getAttachedShaders: program: WebGLProgram -> ResizeArray<WebGLShader> option
    abstract getAttribLocation: program: WebGLProgram * name: string -> GLint
    abstract getBufferParameter: target: GLenum * pname: GLenum -> obj option
    abstract getContextAttributes: unit -> WebGLContextAttributes option
    abstract getError: unit -> GLenum
    [<Emit "$0.getExtension('EXT_blend_minmax')">] abstract getExtension_EXT_blend_minmax: unit -> EXT_blend_minmax option
    [<Emit "$0.getExtension('EXT_texture_filter_anisotropic')">] abstract getExtension_EXT_texture_filter_anisotropic: unit -> EXT_texture_filter_anisotropic option
    [<Emit "$0.getExtension('EXT_frag_depth')">] abstract getExtension_EXT_frag_depth: unit -> EXT_frag_depth option
    [<Emit "$0.getExtension('EXT_shader_texture_lod')">] abstract getExtension_EXT_shader_texture_lod: unit -> EXT_shader_texture_lod option
    [<Emit "$0.getExtension('EXT_sRGB')">] abstract getExtension_EXT_sRGB: unit -> EXT_sRGB option
    [<Emit "$0.getExtension('OES_vertex_array_object')">] abstract getExtension_OES_vertex_array_object: unit -> OES_vertex_array_object option
    [<Emit "$0.getExtension('WEBGL_color_buffer_float')">] abstract getExtension_WEBGL_color_buffer_float: unit -> WEBGL_color_buffer_float option
    [<Emit "$0.getExtension('WEBGL_compressed_texture_astc')">] abstract getExtension_WEBGL_compressed_texture_astc: unit -> WEBGL_compressed_texture_astc option
    [<Emit "$0.getExtension('WEBGL_compressed_texture_s3tc_srgb')">] abstract getExtension_WEBGL_compressed_texture_s3tc_srgb: unit -> WEBGL_compressed_texture_s3tc_srgb option
    [<Emit "$0.getExtension('WEBGL_debug_shaders')">] abstract getExtension_WEBGL_debug_shaders: unit -> WEBGL_debug_shaders option
    [<Emit "$0.getExtension('WEBGL_draw_buffers')">] abstract getExtension_WEBGL_draw_buffers: unit -> WEBGL_draw_buffers option
    [<Emit "$0.getExtension('WEBGL_lose_context')">] abstract getExtension_WEBGL_lose_context: unit -> WEBGL_lose_context option
    [<Emit "$0.getExtension('WEBGL_depth_texture')">] abstract getExtension_WEBGL_depth_texture: unit -> WEBGL_depth_texture option
    [<Emit "$0.getExtension('WEBGL_debug_renderer_info')">] abstract getExtension_WEBGL_debug_renderer_info: unit -> WEBGL_debug_renderer_info option
    [<Emit "$0.getExtension('WEBGL_compressed_texture_s3tc')">] abstract getExtension_WEBGL_compressed_texture_s3tc: unit -> WEBGL_compressed_texture_s3tc option
    [<Emit "$0.getExtension('OES_texture_half_float_linear')">] abstract getExtension_OES_texture_half_float_linear: unit -> OES_texture_half_float_linear option
    [<Emit "$0.getExtension('OES_texture_half_float')">] abstract getExtension_OES_texture_half_float: unit -> OES_texture_half_float option
    [<Emit "$0.getExtension('OES_texture_float_linear')">] abstract getExtension_OES_texture_float_linear: unit -> OES_texture_float_linear option
    [<Emit "$0.getExtension('OES_texture_float')">] abstract getExtension_OES_texture_float: unit -> OES_texture_float option
    [<Emit "$0.getExtension('OES_standard_derivatives')">] abstract getExtension_OES_standard_derivatives: unit -> OES_standard_derivatives option
    [<Emit "$0.getExtension('OES_element_index_uint')">] abstract getExtension_OES_element_index_uint: unit -> OES_element_index_uint option
    [<Emit "$0.getExtension('ANGLE_instanced_arrays')">] abstract getExtension_ANGLE_instanced_arrays: unit -> ANGLE_instanced_arrays option
    abstract getExtension: extensionName: string -> obj option
    abstract getFramebufferAttachmentParameter: target: GLenum * attachment: GLenum * pname: GLenum -> obj option
    abstract getParameter: pname: GLenum -> obj option
    abstract getProgramInfoLog: program: WebGLProgram -> string option
    abstract getProgramParameter: program: WebGLProgram * pname: GLenum -> obj option
    abstract getRenderbufferParameter: target: GLenum * pname: GLenum -> obj option
    abstract getShaderInfoLog: shader: WebGLShader -> string option
    abstract getShaderParameter: shader: WebGLShader * pname: GLenum -> obj option
    abstract getShaderPrecisionFormat: shadertype: GLenum * precisiontype: GLenum -> WebGLShaderPrecisionFormat option
    abstract getShaderSource: shader: WebGLShader -> string option
    abstract getSupportedExtensions: unit -> ResizeArray<string> option
    abstract getTexParameter: target: GLenum * pname: GLenum -> obj option
    abstract getUniform: program: WebGLProgram * location: WebGLUniformLocation -> obj option
    abstract getUniformLocation: program: WebGLProgram * name: string -> WebGLUniformLocation option
    abstract getVertexAttrib: index: GLuint * pname: GLenum -> obj option
    abstract getVertexAttribOffset: index: GLuint * pname: GLenum -> GLintptr
    abstract hint: target: GLenum * mode: GLenum -> unit
    abstract isBuffer: buffer: WebGLBuffer option -> GLboolean
    abstract isContextLost: unit -> bool
    abstract isEnabled: cap: GLenum -> GLboolean
    abstract isFramebuffer: framebuffer: WebGLFramebuffer option -> GLboolean
    abstract isProgram: program: WebGLProgram option -> GLboolean
    abstract isRenderbuffer: renderbuffer: WebGLRenderbuffer option -> GLboolean
    abstract isShader: shader: WebGLShader option -> GLboolean
    abstract isTexture: texture: WebGLTexture option -> GLboolean
    abstract lineWidth: width: GLfloat -> unit
    abstract linkProgram: program: WebGLProgram -> unit
    abstract pixelStorei: pname: GLenum * param: U2<GLint, GLboolean> -> unit
    abstract polygonOffset: factor: GLfloat * units: GLfloat -> unit
    abstract renderbufferStorage: target: GLenum * internalformat: GLenum * width: GLsizei * height: GLsizei -> unit
    abstract sampleCoverage: value: GLclampf * invert: GLboolean -> unit
    abstract scissor: x: GLint * y: GLint * width: GLsizei * height: GLsizei -> unit
    abstract shaderSource: shader: WebGLShader * source: string -> unit
    abstract stencilFunc: func: GLenum * ref: GLint * mask: GLuint -> unit
    abstract stencilFuncSeparate: face: GLenum * func: GLenum * ref: GLint * mask: GLuint -> unit
    abstract stencilMask: mask: GLuint -> unit
    abstract stencilMaskSeparate: face: GLenum * mask: GLuint -> unit
    abstract stencilOp: fail: GLenum * zfail: GLenum * zpass: GLenum -> unit
    abstract stencilOpSeparate: face: GLenum * fail: GLenum * zfail: GLenum * zpass: GLenum -> unit
    abstract texParameterf: target: GLenum * pname: GLenum * param: GLfloat -> unit
    abstract texParameteri: target: GLenum * pname: GLenum * param: GLint -> unit
    abstract uniform1f: location: WebGLUniformLocation option * x: GLfloat -> unit
    abstract uniform1i: location: WebGLUniformLocation option * x: GLint -> unit
    abstract uniform2f: location: WebGLUniformLocation option * x: GLfloat * y: GLfloat -> unit
    abstract uniform2i: location: WebGLUniformLocation option * x: GLint * y: GLint -> unit
    abstract uniform3f: location: WebGLUniformLocation option * x: GLfloat * y: GLfloat * z: GLfloat -> unit
    abstract uniform3i: location: WebGLUniformLocation option * x: GLint * y: GLint * z: GLint -> unit
    abstract uniform4f: location: WebGLUniformLocation option * x: GLfloat * y: GLfloat * z: GLfloat * w: GLfloat -> unit
    abstract uniform4i: location: WebGLUniformLocation option * x: GLint * y: GLint * z: GLint * w: GLint -> unit
    abstract useProgram: program: WebGLProgram option -> unit
    abstract validateProgram: program: WebGLProgram -> unit
    abstract vertexAttrib1f: index: GLuint * x: GLfloat -> unit
    abstract vertexAttrib1fv: index: GLuint * values: Float32List -> unit
    abstract vertexAttrib2f: index: GLuint * x: GLfloat * y: GLfloat -> unit
    abstract vertexAttrib2fv: index: GLuint * values: Float32List -> unit
    abstract vertexAttrib3f: index: GLuint * x: GLfloat * y: GLfloat * z: GLfloat -> unit
    abstract vertexAttrib3fv: index: GLuint * values: Float32List -> unit
    abstract vertexAttrib4f: index: GLuint * x: GLfloat * y: GLfloat * z: GLfloat * w: GLfloat -> unit
    abstract vertexAttrib4fv: index: GLuint * values: Float32List -> unit
    abstract vertexAttribPointer: index: GLuint * size: GLint * ``type``: GLenum * normalized: GLboolean * stride: GLsizei * offset: GLintptr -> unit
    abstract viewport: x: GLint * y: GLint * width: GLsizei * height: GLsizei -> unit
    abstract ACTIVE_ATTRIBUTES: GLenum
    abstract ACTIVE_TEXTURE: GLenum
    abstract ACTIVE_UNIFORMS: GLenum
    abstract ALIASED_LINE_WIDTH_RANGE: GLenum
    abstract ALIASED_POINT_SIZE_RANGE: GLenum
    abstract ALPHA: GLenum
    abstract ALPHA_BITS: GLenum
    abstract ALWAYS: GLenum
    abstract ARRAY_BUFFER: GLenum
    abstract ARRAY_BUFFER_BINDING: GLenum
    abstract ATTACHED_SHADERS: GLenum
    abstract BACK: GLenum
    abstract BLEND: GLenum
    abstract BLEND_COLOR: GLenum
    abstract BLEND_DST_ALPHA: GLenum
    abstract BLEND_DST_RGB: GLenum
    abstract BLEND_EQUATION: GLenum
    abstract BLEND_EQUATION_ALPHA: GLenum
    abstract BLEND_EQUATION_RGB: GLenum
    abstract BLEND_SRC_ALPHA: GLenum
    abstract BLEND_SRC_RGB: GLenum
    abstract BLUE_BITS: GLenum
    abstract BOOL: GLenum
    abstract BOOL_VEC2: GLenum
    abstract BOOL_VEC3: GLenum
    abstract BOOL_VEC4: GLenum
    abstract BROWSER_DEFAULT_WEBGL: GLenum
    abstract BUFFER_SIZE: GLenum
    abstract BUFFER_USAGE: GLenum
    abstract BYTE: GLenum
    abstract CCW: GLenum
    abstract CLAMP_TO_EDGE: GLenum
    abstract COLOR_ATTACHMENT0: GLenum
    abstract COLOR_BUFFER_BIT: GLenum
    abstract COLOR_CLEAR_VALUE: GLenum
    abstract COLOR_WRITEMASK: GLenum
    abstract COMPILE_STATUS: GLenum
    abstract COMPRESSED_TEXTURE_FORMATS: GLenum
    abstract CONSTANT_ALPHA: GLenum
    abstract CONSTANT_COLOR: GLenum
    abstract CONTEXT_LOST_WEBGL: GLenum
    abstract CULL_FACE: GLenum
    abstract CULL_FACE_MODE: GLenum
    abstract CURRENT_PROGRAM: GLenum
    abstract CURRENT_VERTEX_ATTRIB: GLenum
    abstract CW: GLenum
    abstract DECR: GLenum
    abstract DECR_WRAP: GLenum
    abstract DELETE_STATUS: GLenum
    abstract DEPTH_ATTACHMENT: GLenum
    abstract DEPTH_BITS: GLenum
    abstract DEPTH_BUFFER_BIT: GLenum
    abstract DEPTH_CLEAR_VALUE: GLenum
    abstract DEPTH_COMPONENT: GLenum
    abstract DEPTH_COMPONENT16: GLenum
    abstract DEPTH_FUNC: GLenum
    abstract DEPTH_RANGE: GLenum
    abstract DEPTH_STENCIL: GLenum
    abstract DEPTH_STENCIL_ATTACHMENT: GLenum
    abstract DEPTH_TEST: GLenum
    abstract DEPTH_WRITEMASK: GLenum
    abstract DITHER: GLenum
    abstract DONT_CARE: GLenum
    abstract DST_ALPHA: GLenum
    abstract DST_COLOR: GLenum
    abstract DYNAMIC_DRAW: GLenum
    abstract ELEMENT_ARRAY_BUFFER: GLenum
    abstract ELEMENT_ARRAY_BUFFER_BINDING: GLenum
    abstract EQUAL: GLenum
    abstract FASTEST: GLenum
    abstract FLOAT: GLenum
    abstract FLOAT_MAT2: GLenum
    abstract FLOAT_MAT3: GLenum
    abstract FLOAT_MAT4: GLenum
    abstract FLOAT_VEC2: GLenum
    abstract FLOAT_VEC3: GLenum
    abstract FLOAT_VEC4: GLenum
    abstract FRAGMENT_SHADER: GLenum
    abstract FRAMEBUFFER: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_OBJECT_NAME: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE: GLenum
    abstract FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL: GLenum
    abstract FRAMEBUFFER_BINDING: GLenum
    abstract FRAMEBUFFER_COMPLETE: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_ATTACHMENT: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_DIMENSIONS: GLenum
    abstract FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT: GLenum
    abstract FRAMEBUFFER_UNSUPPORTED: GLenum
    abstract FRONT: GLenum
    abstract FRONT_AND_BACK: GLenum
    abstract FRONT_FACE: GLenum
    abstract FUNC_ADD: GLenum
    abstract FUNC_REVERSE_SUBTRACT: GLenum
    abstract FUNC_SUBTRACT: GLenum
    abstract GENERATE_MIPMAP_HINT: GLenum
    abstract GEQUAL: GLenum
    abstract GREATER: GLenum
    abstract GREEN_BITS: GLenum
    abstract HIGH_FLOAT: GLenum
    abstract HIGH_INT: GLenum
    abstract IMPLEMENTATION_COLOR_READ_FORMAT: GLenum
    abstract IMPLEMENTATION_COLOR_READ_TYPE: GLenum
    abstract INCR: GLenum
    abstract INCR_WRAP: GLenum
    abstract INT: GLenum
    abstract INT_VEC2: GLenum
    abstract INT_VEC3: GLenum
    abstract INT_VEC4: GLenum
    abstract INVALID_ENUM: GLenum
    abstract INVALID_FRAMEBUFFER_OPERATION: GLenum
    abstract INVALID_OPERATION: GLenum
    abstract INVALID_VALUE: GLenum
    abstract INVERT: GLenum
    abstract KEEP: GLenum
    abstract LEQUAL: GLenum
    abstract LESS: GLenum
    abstract LINEAR: GLenum
    abstract LINEAR_MIPMAP_LINEAR: GLenum
    abstract LINEAR_MIPMAP_NEAREST: GLenum
    abstract LINES: GLenum
    abstract LINE_LOOP: GLenum
    abstract LINE_STRIP: GLenum
    abstract LINE_WIDTH: GLenum
    abstract LINK_STATUS: GLenum
    abstract LOW_FLOAT: GLenum
    abstract LOW_INT: GLenum
    abstract LUMINANCE: GLenum
    abstract LUMINANCE_ALPHA: GLenum
    abstract MAX_COMBINED_TEXTURE_IMAGE_UNITS: GLenum
    abstract MAX_CUBE_MAP_TEXTURE_SIZE: GLenum
    abstract MAX_FRAGMENT_UNIFORM_VECTORS: GLenum
    abstract MAX_RENDERBUFFER_SIZE: GLenum
    abstract MAX_TEXTURE_IMAGE_UNITS: GLenum
    abstract MAX_TEXTURE_SIZE: GLenum
    abstract MAX_VARYING_VECTORS: GLenum
    abstract MAX_VERTEX_ATTRIBS: GLenum
    abstract MAX_VERTEX_TEXTURE_IMAGE_UNITS: GLenum
    abstract MAX_VERTEX_UNIFORM_VECTORS: GLenum
    abstract MAX_VIEWPORT_DIMS: GLenum
    abstract MEDIUM_FLOAT: GLenum
    abstract MEDIUM_INT: GLenum
    abstract MIRRORED_REPEAT: GLenum
    abstract NEAREST: GLenum
    abstract NEAREST_MIPMAP_LINEAR: GLenum
    abstract NEAREST_MIPMAP_NEAREST: GLenum
    abstract NEVER: GLenum
    abstract NICEST: GLenum
    abstract NONE: GLenum
    abstract NOTEQUAL: GLenum
    abstract NO_ERROR: GLenum
    abstract ONE: GLenum
    abstract ONE_MINUS_CONSTANT_ALPHA: GLenum
    abstract ONE_MINUS_CONSTANT_COLOR: GLenum
    abstract ONE_MINUS_DST_ALPHA: GLenum
    abstract ONE_MINUS_DST_COLOR: GLenum
    abstract ONE_MINUS_SRC_ALPHA: GLenum
    abstract ONE_MINUS_SRC_COLOR: GLenum
    abstract OUT_OF_MEMORY: GLenum
    abstract PACK_ALIGNMENT: GLenum
    abstract POINTS: GLenum
    abstract POLYGON_OFFSET_FACTOR: GLenum
    abstract POLYGON_OFFSET_FILL: GLenum
    abstract POLYGON_OFFSET_UNITS: GLenum
    abstract RED_BITS: GLenum
    abstract RENDERBUFFER: GLenum
    abstract RENDERBUFFER_ALPHA_SIZE: GLenum
    abstract RENDERBUFFER_BINDING: GLenum
    abstract RENDERBUFFER_BLUE_SIZE: GLenum
    abstract RENDERBUFFER_DEPTH_SIZE: GLenum
    abstract RENDERBUFFER_GREEN_SIZE: GLenum
    abstract RENDERBUFFER_HEIGHT: GLenum
    abstract RENDERBUFFER_INTERNAL_FORMAT: GLenum
    abstract RENDERBUFFER_RED_SIZE: GLenum
    abstract RENDERBUFFER_STENCIL_SIZE: GLenum
    abstract RENDERBUFFER_WIDTH: GLenum
    abstract RENDERER: GLenum
    abstract REPEAT: GLenum
    abstract REPLACE: GLenum
    abstract RGB: GLenum
    abstract RGB565: GLenum
    abstract RGB5_A1: GLenum
    abstract RGBA: GLenum
    abstract RGBA4: GLenum
    abstract SAMPLER_2D: GLenum
    abstract SAMPLER_CUBE: GLenum
    abstract SAMPLES: GLenum
    abstract SAMPLE_ALPHA_TO_COVERAGE: GLenum
    abstract SAMPLE_BUFFERS: GLenum
    abstract SAMPLE_COVERAGE: GLenum
    abstract SAMPLE_COVERAGE_INVERT: GLenum
    abstract SAMPLE_COVERAGE_VALUE: GLenum
    abstract SCISSOR_BOX: GLenum
    abstract SCISSOR_TEST: GLenum
    abstract SHADER_TYPE: GLenum
    abstract SHADING_LANGUAGE_VERSION: GLenum
    abstract SHORT: GLenum
    abstract SRC_ALPHA: GLenum
    abstract SRC_ALPHA_SATURATE: GLenum
    abstract SRC_COLOR: GLenum
    abstract STATIC_DRAW: GLenum
    abstract STENCIL_ATTACHMENT: GLenum
    abstract STENCIL_BACK_FAIL: GLenum
    abstract STENCIL_BACK_FUNC: GLenum
    abstract STENCIL_BACK_PASS_DEPTH_FAIL: GLenum
    abstract STENCIL_BACK_PASS_DEPTH_PASS: GLenum
    abstract STENCIL_BACK_REF: GLenum
    abstract STENCIL_BACK_VALUE_MASK: GLenum
    abstract STENCIL_BACK_WRITEMASK: GLenum
    abstract STENCIL_BITS: GLenum
    abstract STENCIL_BUFFER_BIT: GLenum
    abstract STENCIL_CLEAR_VALUE: GLenum
    abstract STENCIL_FAIL: GLenum
    abstract STENCIL_FUNC: GLenum
    abstract STENCIL_INDEX8: GLenum
    abstract STENCIL_PASS_DEPTH_FAIL: GLenum
    abstract STENCIL_PASS_DEPTH_PASS: GLenum
    abstract STENCIL_REF: GLenum
    abstract STENCIL_TEST: GLenum
    abstract STENCIL_VALUE_MASK: GLenum
    abstract STENCIL_WRITEMASK: GLenum
    abstract STREAM_DRAW: GLenum
    abstract SUBPIXEL_BITS: GLenum
    abstract TEXTURE: GLenum
    abstract TEXTURE0: GLenum
    abstract TEXTURE1: GLenum
    abstract TEXTURE10: GLenum
    abstract TEXTURE11: GLenum
    abstract TEXTURE12: GLenum
    abstract TEXTURE13: GLenum
    abstract TEXTURE14: GLenum
    abstract TEXTURE15: GLenum
    abstract TEXTURE16: GLenum
    abstract TEXTURE17: GLenum
    abstract TEXTURE18: GLenum
    abstract TEXTURE19: GLenum
    abstract TEXTURE2: GLenum
    abstract TEXTURE20: GLenum
    abstract TEXTURE21: GLenum
    abstract TEXTURE22: GLenum
    abstract TEXTURE23: GLenum
    abstract TEXTURE24: GLenum
    abstract TEXTURE25: GLenum
    abstract TEXTURE26: GLenum
    abstract TEXTURE27: GLenum
    abstract TEXTURE28: GLenum
    abstract TEXTURE29: GLenum
    abstract TEXTURE3: GLenum
    abstract TEXTURE30: GLenum
    abstract TEXTURE31: GLenum
    abstract TEXTURE4: GLenum
    abstract TEXTURE5: GLenum
    abstract TEXTURE6: GLenum
    abstract TEXTURE7: GLenum
    abstract TEXTURE8: GLenum
    abstract TEXTURE9: GLenum
    abstract TEXTURE_2D: GLenum
    abstract TEXTURE_BINDING_2D: GLenum
    abstract TEXTURE_BINDING_CUBE_MAP: GLenum
    abstract TEXTURE_CUBE_MAP: GLenum
    abstract TEXTURE_CUBE_MAP_NEGATIVE_X: GLenum
    abstract TEXTURE_CUBE_MAP_NEGATIVE_Y: GLenum
    abstract TEXTURE_CUBE_MAP_NEGATIVE_Z: GLenum
    abstract TEXTURE_CUBE_MAP_POSITIVE_X: GLenum
    abstract TEXTURE_CUBE_MAP_POSITIVE_Y: GLenum
    abstract TEXTURE_CUBE_MAP_POSITIVE_Z: GLenum
    abstract TEXTURE_MAG_FILTER: GLenum
    abstract TEXTURE_MIN_FILTER: GLenum
    abstract TEXTURE_WRAP_S: GLenum
    abstract TEXTURE_WRAP_T: GLenum
    abstract TRIANGLES: GLenum
    abstract TRIANGLE_FAN: GLenum
    abstract TRIANGLE_STRIP: GLenum
    abstract UNPACK_ALIGNMENT: GLenum
    abstract UNPACK_COLORSPACE_CONVERSION_WEBGL: GLenum
    abstract UNPACK_FLIP_Y_WEBGL: GLenum
    abstract UNPACK_PREMULTIPLY_ALPHA_WEBGL: GLenum
    abstract UNSIGNED_BYTE: GLenum
    abstract UNSIGNED_INT: GLenum
    abstract UNSIGNED_SHORT: GLenum
    abstract UNSIGNED_SHORT_4_4_4_4: GLenum
    abstract UNSIGNED_SHORT_5_5_5_1: GLenum
    abstract UNSIGNED_SHORT_5_6_5: GLenum
    abstract VALIDATE_STATUS: GLenum
    abstract VENDOR: GLenum
    abstract VERSION: GLenum
    abstract VERTEX_ATTRIB_ARRAY_BUFFER_BINDING: GLenum
    abstract VERTEX_ATTRIB_ARRAY_ENABLED: GLenum
    abstract VERTEX_ATTRIB_ARRAY_NORMALIZED: GLenum
    abstract VERTEX_ATTRIB_ARRAY_POINTER: GLenum
    abstract VERTEX_ATTRIB_ARRAY_SIZE: GLenum
    abstract VERTEX_ATTRIB_ARRAY_STRIDE: GLenum
    abstract VERTEX_ATTRIB_ARRAY_TYPE: GLenum
    abstract VERTEX_SHADER: GLenum
    abstract VIEWPORT: GLenum
    abstract ZERO: GLenum

type GLsizeiptr =
    float

type BufferSource =
    U2<ArrayBufferView, ArrayBuffer>

type TexImageSource =
    U6<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement, OffscreenCanvas>

type Int32List =
    U2<Int32Array, ResizeArray<GLint>>

type [<AllowNullLiteral>] WebGLRenderingContextOverloads =
    abstract bufferData: target: GLenum * size: GLsizeiptr * usage: GLenum -> unit
    abstract bufferData: target: GLenum * data: BufferSource option * usage: GLenum -> unit
    abstract bufferSubData: target: GLenum * offset: GLintptr * data: BufferSource -> unit
    abstract compressedTexImage2D: target: GLenum * level: GLint * internalformat: GLenum * width: GLsizei * height: GLsizei * border: GLint * data: ArrayBufferView -> unit
    abstract compressedTexSubImage2D: target: GLenum * level: GLint * xoffset: GLint * yoffset: GLint * width: GLsizei * height: GLsizei * format: GLenum * data: ArrayBufferView -> unit
    abstract readPixels: x: GLint * y: GLint * width: GLsizei * height: GLsizei * format: GLenum * ``type``: GLenum * pixels: ArrayBufferView option -> unit
    abstract texImage2D: target: GLenum * level: GLint * internalformat: GLint * width: GLsizei * height: GLsizei * border: GLint * format: GLenum * ``type``: GLenum * pixels: ArrayBufferView option -> unit
    abstract texImage2D: target: GLenum * level: GLint * internalformat: GLint * format: GLenum * ``type``: GLenum * source: TexImageSource -> unit
    abstract texSubImage2D: target: GLenum * level: GLint * xoffset: GLint * yoffset: GLint * width: GLsizei * height: GLsizei * format: GLenum * ``type``: GLenum * pixels: ArrayBufferView option -> unit
    abstract texSubImage2D: target: GLenum * level: GLint * xoffset: GLint * yoffset: GLint * format: GLenum * ``type``: GLenum * source: TexImageSource -> unit
    abstract uniform1fv: location: WebGLUniformLocation option * v: Float32List -> unit
    abstract uniform1iv: location: WebGLUniformLocation option * v: Int32List -> unit
    abstract uniform2fv: location: WebGLUniformLocation option * v: Float32List -> unit
    abstract uniform2iv: location: WebGLUniformLocation option * v: Int32List -> unit
    abstract uniform3fv: location: WebGLUniformLocation option * v: Float32List -> unit
    abstract uniform3iv: location: WebGLUniformLocation option * v: Int32List -> unit
    abstract uniform4fv: location: WebGLUniformLocation option * v: Float32List -> unit
    abstract uniform4iv: location: WebGLUniformLocation option * v: Int32List -> unit
    abstract uniformMatrix2fv: location: WebGLUniformLocation option * transpose: GLboolean * value: Float32List -> unit
    abstract uniformMatrix3fv: location: WebGLUniformLocation option * transpose: GLboolean * value: Float32List -> unit
    abstract uniformMatrix4fv: location: WebGLUniformLocation option * transpose: GLboolean * value: Float32List -> unit

/// Provides an interface to the OpenGL ES 2.0 graphics rendering context for the drawing surface of an HTML <canvas> element.
type [<AllowNullLiteral>] WebGLRenderingContext =
    inherit WebGLRenderingContextBase
    inherit WebGLRenderingContextOverloads

type [<AllowNullLiteral>] ReadStream =
    inherit Node.Stream.Readable<obj>
    abstract close: ?callback: ((Node.Base.ErrnoException) option -> unit) -> unit
    abstract bytesRead: float with get, set
    abstract path: U2<string, Buffer> with get, set
    abstract pending: bool with get, set
    [<Emit "$0.addListener('close',$1)">] abstract addListener_close: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.addListener('data',$1)">] abstract addListener_data: listener: (U2<Buffer, string> -> unit) -> ReadStream
    [<Emit "$0.addListener('end',$1)">] abstract addListener_end: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.addListener('error',$1)">] abstract addListener_error: listener: (Error -> unit) -> ReadStream
    [<Emit "$0.addListener('open',$1)">] abstract addListener_open: listener: (float -> unit) -> ReadStream
    [<Emit "$0.addListener('pause',$1)">] abstract addListener_pause: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.addListener('readable',$1)">] abstract addListener_readable: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.addListener('ready',$1)">] abstract addListener_ready: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.addListener('resume',$1)">] abstract addListener_resume: listener: (unit -> unit) -> ReadStream
    abstract addListener: ``event``: U2<string, Symbol> * listener: (ResizeArray<obj option> -> unit) -> ReadStream
    [<Emit "$0.on('close',$1)">] abstract on_close: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.on('data',$1)">] abstract on_data: listener: (U2<Buffer, string> -> unit) -> ReadStream
    [<Emit "$0.on('end',$1)">] abstract on_end: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.on('error',$1)">] abstract on_error: listener: (Error -> unit) -> ReadStream
    [<Emit "$0.on('open',$1)">] abstract on_open: listener: (float -> unit) -> ReadStream
    [<Emit "$0.on('pause',$1)">] abstract on_pause: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.on('readable',$1)">] abstract on_readable: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.on('ready',$1)">] abstract on_ready: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.on('resume',$1)">] abstract on_resume: listener: (unit -> unit) -> ReadStream
    abstract on: ``event``: U2<string, Symbol> * listener: (ResizeArray<obj option> -> unit) -> ReadStream
    [<Emit "$0.once('close',$1)">] abstract once_close: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.once('data',$1)">] abstract once_data: listener: (U2<Buffer, string> -> unit) -> ReadStream
    [<Emit "$0.once('end',$1)">] abstract once_end: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.once('error',$1)">] abstract once_error: listener: (Error -> unit) -> ReadStream
    [<Emit "$0.once('open',$1)">] abstract once_open: listener: (float -> unit) -> ReadStream
    [<Emit "$0.once('pause',$1)">] abstract once_pause: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.once('readable',$1)">] abstract once_readable: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.once('ready',$1)">] abstract once_ready: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.once('resume',$1)">] abstract once_resume: listener: (unit -> unit) -> ReadStream
    abstract once: ``event``: U2<string, Symbol> * listener: (ResizeArray<obj option> -> unit) -> ReadStream
    [<Emit "$0.prependListener('close',$1)">] abstract prependListener_close: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependListener('data',$1)">] abstract prependListener_data: listener: (U2<Buffer, string> -> unit) -> ReadStream
    [<Emit "$0.prependListener('end',$1)">] abstract prependListener_end: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependListener('error',$1)">] abstract prependListener_error: listener: (Error -> unit) -> ReadStream
    [<Emit "$0.prependListener('open',$1)">] abstract prependListener_open: listener: (float -> unit) -> ReadStream
    [<Emit "$0.prependListener('pause',$1)">] abstract prependListener_pause: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependListener('readable',$1)">] abstract prependListener_readable: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependListener('ready',$1)">] abstract prependListener_ready: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependListener('resume',$1)">] abstract prependListener_resume: listener: (unit -> unit) -> ReadStream
    abstract prependListener: ``event``: U2<string, Symbol> * listener: (ResizeArray<obj option> -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('close',$1)">] abstract prependOnceListener_close: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('data',$1)">] abstract prependOnceListener_data: listener: (U2<Buffer, string> -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('end',$1)">] abstract prependOnceListener_end: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('error',$1)">] abstract prependOnceListener_error: listener: (Error -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('open',$1)">] abstract prependOnceListener_open: listener: (float -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('pause',$1)">] abstract prependOnceListener_pause: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('readable',$1)">] abstract prependOnceListener_readable: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('ready',$1)">] abstract prependOnceListener_ready: listener: (unit -> unit) -> ReadStream
    [<Emit "$0.prependOnceListener('resume',$1)">] abstract prependOnceListener_resume: listener: (unit -> unit) -> ReadStream
    abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: (ResizeArray<obj option> -> unit) -> ReadStream