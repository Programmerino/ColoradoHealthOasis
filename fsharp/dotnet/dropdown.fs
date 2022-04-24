// ts2fable 0.8.0-build.655
module rec dropdown

#nowarn "3390" // disable warnings for invalid XML comments

open System
open Fable.Core
open Fable.Core.JS

type RegExp = System.Text.RegularExpressions.Regex


module Global =

    type [<AllowNullLiteral>] JQuery =
        abstract dropdown: SemanticUI.Dropdown with get, set

    module SemanticUI =

        type [<AllowNullLiteral>] Dropdown =
            abstract settings: DropdownSettings with get, set
            /// Recreates dropdown menu from select option values.
            [<Emit("$0.Invoke('setup menu')")>] abstract Invoke_setup_menu: unit -> JQuery
            /// Refreshes all cached selectors and data
            [<Emit("$0.Invoke('refresh')")>] abstract Invoke_refresh: unit -> JQuery
            /// Toggles current visibility of dropdown
            [<Emit("$0.Invoke('toggle')")>] abstract Invoke_toggle: unit -> JQuery
            /// Shows dropdown
            [<Emit("$0.Invoke('show')")>] abstract Invoke_show: unit -> JQuery
            /// Hides dropdown
            [<Emit("$0.Invoke('hide')")>] abstract Invoke_hide: unit -> JQuery
            /// Clears dropdown of selection
            [<Emit("$0.Invoke('clear')")>] abstract Invoke_clear: unit -> JQuery
            /// Hides all other dropdowns that is not current dropdown
            [<Emit("$0.Invoke('hide others')")>] abstract Invoke_hide_others: unit -> JQuery
            /// Restores dropdown text and value to its value on page load
            [<Emit("$0.Invoke('restore defaults')")>] abstract Invoke_restore_defaults: unit -> JQuery
            /// Restores dropdown text to its value on page load
            [<Emit("$0.Invoke('restore default text')")>] abstract Invoke_restore_default_text: unit -> JQuery
            /// Restores dropdown text to its prompt, placeholder text
            [<Emit("$0.Invoke('restore placeholder text')")>] abstract Invoke_restore_placeholder_text: unit -> JQuery
            /// Restores dropdown value to its value on page load
            [<Emit("$0.Invoke('restore default value')")>] abstract Invoke_restore_default_value: unit -> JQuery
            /// Saves current text and value as new defaults (for use with restore)
            [<Emit("$0.Invoke('save defaults')")>] abstract Invoke_save_defaults: unit -> JQuery
            /// Sets value as selected
            [<Emit("$0.Invoke('set selected',$1)")>] abstract Invoke_set_selected: value: obj option -> JQuery
            /// Remove value from selected
            [<Emit("$0.Invoke('remove selected',$1)")>] abstract Invoke_remove_selected: value: obj option -> JQuery
            /// Adds a group of values as selected
            [<Emit("$0.Invoke('set selected',$1)")>] abstract Invoke_set_selected: values: obj option[] -> JQuery
            /// Sets selected values to exactly specified values, removing current selection
            [<Emit("$0.Invoke('set exactly',$1)")>] abstract Invoke_set_exactly: values: obj option[] -> JQuery
            /// Sets dropdown text to a value
            [<Emit("$0.Invoke('set text',$1)")>] abstract Invoke_set_text: text: string -> JQuery
            /// Sets dropdown input to value (does not update display state)
            [<Emit("$0.Invoke('set value',$1)")>] abstract Invoke_set_value: value: obj option -> JQuery
            /// Returns current dropdown text
            [<Emit("$0.Invoke('get text')")>] abstract Invoke_get_text: unit -> string
            /// Returns current dropdown input value
            [<Emit("$0.Invoke('get value')")>] abstract Invoke_get_value: unit -> obj option
            /// Returns DOM element that matches a given input value
            [<Emit("$0.Invoke('get item',$1)")>] abstract Invoke_get_item: value: obj option -> JQuery
            /// Adds touch events to element
            [<Emit("$0.Invoke('bind touch events')")>] abstract Invoke_bind_touch_events: unit -> JQuery
            /// Adds mouse events to element
            [<Emit("$0.Invoke('bind mouse events')")>] abstract Invoke_bind_mouse_events: unit -> JQuery
            /// Binds a click to document to determine if you click away from a dropdown
            [<Emit("$0.Invoke('bind intent')")>] abstract Invoke_bind_intent: unit -> JQuery
            /// Unbinds document intent click
            [<Emit("$0.Invoke('unbind intent')")>] abstract Invoke_unbind_intent: unit -> JQuery
            /// Returns whether event occurred inside dropdown
            [<Emit("$0.Invoke('determine intent')")>] abstract Invoke_determine_intent: unit -> bool
            /// Triggers preset item selection action based on settings passing text/value
            [<Emit("$0.Invoke('determine select action',$1,$2)")>] abstract Invoke_determine_select_action: text: string * value: obj option -> JQuery
            /// Sets dropdown to active state
            [<Emit("$0.Invoke('set active')")>] abstract Invoke_set_active: unit -> JQuery
            /// Sets dropdown to visible state
            [<Emit("$0.Invoke('set visible')")>] abstract Invoke_set_visible: unit -> JQuery
            /// Removes dropdown active state
            [<Emit("$0.Invoke('remove active')")>] abstract Invoke_remove_active: unit -> JQuery
            /// Removes dropdown visible state
            [<Emit("$0.Invoke('remove visible')")>] abstract Invoke_remove_visible: unit -> JQuery
            /// Returns whether dropdown is a selection dropdown
            [<Emit("$0.Invoke('is selection')")>] abstract Invoke_is_selection: unit -> bool
            /// Returns whether dropdown is animated
            [<Emit("$0.Invoke('is animated')")>] abstract Invoke_is_animated: unit -> bool
            /// Returns whether dropdown is visible
            [<Emit("$0.Invoke('is visible')")>] abstract Invoke_is_visible: unit -> bool
            /// Returns whether dropdown is hidden
            [<Emit("$0.Invoke('is hidden')")>] abstract Invoke_is_hidden: unit -> bool
            /// Returns dropdown value as set on page load
            [<Emit("$0.Invoke('get default text')")>] abstract Invoke_get_default_text: unit -> string
            /// Returns placeholder text
            [<Emit("$0.Invoke('get placeholder text')")>] abstract Invoke_get_placeholder_text: unit -> string
            [<Emit("$0.Invoke('destroy')")>] abstract Invoke_destroy: unit -> JQuery
            // [<Emit("$0.Invoke('setting',$1,$2)")>] abstract Invoke_setting: name: K * ?value: obj -> obj
            // [<Emit("$0.Invoke('setting',$1,$2)")>] abstract Invoke_setting: name: K * value: obj -> JQuery
            [<Emit("$0.Invoke('setting',$1)")>] abstract Invoke_setting: value: DropdownSettings -> JQuery
            [<Emit("$0($1...)")>] abstract Invoke: ?settings: DropdownSettings -> JQuery

        /// <seealso href="http://semantic-ui.com/modules/dropdown.html#/settings" />
        type DropdownSettings =
            DropdownSettings.Param

        module DropdownSettings =

            type [<AllowNullLiteral>] Param =
                interface end

            type [<AllowNullLiteral>] _Impl =
                /// <summary>Event used to trigger dropdown (Hover, Click, Custom Event)</summary>
                /// <default>'click'</default>
                abstract on: string with get, set
                /// <summary>When specified allows you to initialize dropdown with specific values. See usage guide for details.</summary>
                /// <default>false</default>
                abstract values: obj option with get, set
                /// <summary>When set to true will fire onChange even when the value a user select matches the currently selected value.</summary>
                /// <default>false</default>
                abstract allowReselection: bool with get, set
                /// <summary>Whether search selection should allow users to add their own selections, works for single or multi-select.</summary>
                /// <default>false</default>
                abstract allowAdditions: bool with get, set
                /// <summary>When disabled user additions will appear in the results menu using a specially formatted selection item formatted by templates.addition.</summary>
                /// <default>true</default>
                abstract hideAdditions: bool with get, set
                /// <summary>Sets a default action to occur. (See usage guide)</summary>
                /// <default>'activate'</default>
                /// <seealso href="http://semantic-ui.com/modules/dropdown.html#/usage" />
                abstract action: U2<(JQuery -> string -> string -> JQuery -> unit), string> with get, set
                /// <summary>The minimum characters for a search to begin showing results</summary>
                /// <default>1</default>
                abstract minCharacters: float with get, set
                /// <summary>When using search selection specifies how to match values.</summary>
                /// <default>'both'</default>
                abstract ``match``: _ImplMatch with get, set
                /// <summary>Whether dropdown should select new option when using keyboard shortcuts. Setting to false will require enter or left click to confirm a choice.</summary>
                /// <default>true</default>
                abstract selectOnKeydown: bool with get, set
                /// <summary>Whether search selection will force currently selected choice when element is blurred.</summary>
                /// <default>true</default>
                abstract forceSelection: bool with get, set
                /// <summary>Whether menu items with sub-menus (categories) should be selectable</summary>
                /// <default>false</default>
                abstract allowCategorySelection: bool with get, set
                /// <default>'auto'</default>
                abstract placeholder: _ImplPlaceholder with get, set
                /// List mapping dropdown content to JSON Property when using API
                abstract fields: Dropdown.FieldsSettings with get, set
                /// <summary>When enabled will automatically store selected name/value pairs in sessionStorage to preserve user selection on page refresh. Disabling will clear remote dropdown values on refresh.</summary>
                /// <default>true</default>
                abstract saveRemoteData: bool with get, set
                /// <summary>When set to true API will be expected to return the complete result set, which will then be filtered clientside to only display matching results.</summary>
                /// <default>false</default>
                abstract filterRemoteData: bool with get, set
                /// <summary>Whether multiselect should use labels. Must be set to true when allowAdditions is true</summary>
                /// <default>true</default>
                abstract useLabels: bool with get, set
                /// <summary>When set to a number, sets the maximum number of selections</summary>
                /// <default>false</default>
                abstract maxSelections: float with get, set
                /// <summary>Maximum glyph width, used to calculate search size. This is usually size of a "W" in your font in em</summary>
                /// <default>1.0714</default>
                abstract glyphWidth: float with get, set
                /// Allows customization of multi-select labels
                abstract label: Dropdown.LabelSettings with get, set
                /// <summary>When set to auto determines direction based on whether dropdown can fit on screen. Set to upward or downward to always force a direction.</summary>
                /// <default>'auto'</default>
                abstract direction: _ImplDirection with get, set
                /// <summary>Whether dropdown should try to keep itself on screen by checking whether menus display position in its context (Default context is page).</summary>
                /// <default>true</default>
                abstract keepOnScreen: bool with get, set
                /// <summary>Element context to use when checking whether can show when keepOnScreen: true</summary>
                /// <default>'window'</default>
                abstract context: U2<string, JQuery> with get, set
                /// <summary>Specifying to "true" will use a fuzzy full text search, setting to "exact" will force the exact search to be matched somewhere in the string</summary>
                /// <default>false</default>
                abstract fullTextSearch: U2<bool, string> with get, set
                /// <summary>Whether HTML included in dropdown values should be preserved. (Allows icons to show up in selected value)</summary>
                /// <default>true</default>
                abstract preserveHTML: bool with get, set
                /// <summary>Whether to sort values when creating a dropdown automatically from a select element.</summary>
                /// <default>false</default>
                abstract sortSelect: bool with get, set
                /// <summary>Whether to show dropdown menu automatically on element focus.</summary>
                /// <default>true</default>
                abstract showOnFocus: bool with get, set
                /// <summary>Whether to allow the element to be navigable by keyboard, by automatically creating a tabindex</summary>
                /// <default>true</default>
                abstract allowTab: bool with get, set
                /// <summary>
                /// Named transition to use when animating menu in and out.
                /// Defaults to slide down or slide up depending on dropdown direction.
                /// Fade and slide down are available without including ui transitions
                /// </summary>
                /// <default>'auto'</default>
                /// <seealso href="http://semantic-ui.com/modules/transition.html" />
                abstract transition: U2<string, string> with get, set
                /// <summary>Duration of animation events</summary>
                /// <default>200</default>
                abstract duration: float with get, set
                /// The keycode used to represent keyboard shortcuts. To avoid issues with some foreign languages, you can pass false for comma delimiter's value
                abstract keys: Dropdown.KeySettings with get, set
                /// Time in milliseconds to debounce show or hide behavior when on: hover is used, or when touch is used.
                abstract delay: Dropdown.DelaySettings with get, set
                /// Is called after a dropdown value changes. Receives the name and value of selection and the active menu element
                abstract onChange: this: JQuery * value: obj option * text: string * ``$choice``: JQuery -> unit
                /// Is called after a dropdown selection is added using a multiple select dropdown, only receives the added value
                abstract onAdd: this: JQuery * addedValue: obj option * addedText: string * ``$addedChoice``: JQuery -> unit
                /// Is called after a dropdown selection is removed using a multiple select dropdown, only receives the removed value
                abstract onRemove: this: JQuery * removedValue: obj option * removedText: string * ``$removedChoice``: JQuery -> unit
                /// Allows you to modify a label before it is added. Expects the jQ DOM element for a label to be returned.
                abstract onLabelCreate: this: JQuery * value: obj option * text: string -> JQuery
                /// Called when a label is remove, return false; will prevent the label from being removed.
                abstract onLabelRemove: this: JQuery * value: obj option -> unit
                /// Is called after a label is selected by a user
                abstract onLabelSelect: this: JQuery * ``$selectedLabels``: JQuery -> unit
                /// Is called after a dropdown is searched with no matching values
                abstract onNoResults: this: JQuery * searchValue: obj option -> unit
                /// Is called before a dropdown is shown. If false is returned, dropdown will not be shown.
                abstract onShow: this: JQuery -> unit
                /// Is called before a dropdown is hidden. If false is returned, dropdown will not be hidden.
                abstract onHide: this: JQuery -> unit
                /// You can specify site wide messages by modifying $.fn.dropdown.settings.message that will apply on any dropdown if it appears in the page.
                abstract message: Dropdown.MessageSettings with get, set
                abstract selector: Dropdown.SelectorSettings with get, set
                abstract regExp: Dropdown.RegExpSettings with get, set
                abstract metadata: Dropdown.MetadataSettings with get, set
                abstract className: Dropdown.ClassNameSettings with get, set
                abstract error: Dropdown.ErrorSettings with get, set
                /// Event namespace. Makes sure module teardown does not effect other events attached to an element.
                abstract ``namespace``: string with get, set
                /// Name used in log statements
                abstract name: string with get, set
                /// Silences all console output including error messages, regardless of other debug settings.
                abstract silent: bool with get, set
                /// Debug output to console
                abstract debug: bool with get, set
                /// Show console.table output with performance metrics
                abstract performance: bool with get, set
                /// Debug output includes all internal behaviors
                abstract verbose: bool with get, set

            type [<StringEnum>] [<RequireQualifiedAccess>] _ImplMatch =
                | Both
                | Value
                | Text

            type [<StringEnum>] [<RequireQualifiedAccess>] _ImplPlaceholder =
                | Auto
                | Value

            type [<StringEnum>] [<RequireQualifiedAccess>] _ImplDirection =
                | Auto
                | Upward
                | Downward

        module Dropdown =

            type FieldsSettings =
                FieldsSettings.Param

            module FieldsSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <summary>grouping for api results</summary>
                    /// <default>'results'</default>
                    abstract remoteValues: string with get, set
                    /// <summary>grouping for all dropdown values</summary>
                    /// <default>'values'</default>
                    abstract values: string with get, set
                    /// <summary>displayed dropdown text</summary>
                    /// <default>'name'</default>
                    abstract name: string with get, set
                    /// <summary>actual dropdown value</summary>
                    /// <default>'value'</default>
                    abstract value: string with get, set

            type LabelSettings =
                LabelSettings.Param

            module LabelSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>'horizontal flip'</default>
                    abstract transition: string with get, set
                    /// <default>200</default>
                    abstract duration: float with get, set
                    /// <default>false</default>
                    abstract variation: string with get, set

            type KeySettings =
                KeySettings.Param

            module KeySettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>8</default>
                    abstract backspace: float with get, set
                    /// <default>188</default>
                    abstract delimiter: float with get, set
                    /// <default>46</default>
                    abstract deleteKey: float with get, set
                    /// <default>13</default>
                    abstract enter: float with get, set
                    /// <default>27</default>
                    abstract escape: float with get, set
                    /// <default>33</default>
                    abstract pageUp: float with get, set
                    /// <default>34</default>
                    abstract pageDown: float with get, set
                    /// <default>37</default>
                    abstract leftArrow: float with get, set
                    /// <default>38</default>
                    abstract upArrow: float with get, set
                    /// <default>39</default>
                    abstract rightArrow: float with get, set
                    /// <default>40</default>
                    abstract downArrow: float with get, set

            type DelaySettings =
                DelaySettings.Param

            module DelaySettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>300</default>
                    abstract hide: float with get, set
                    /// <default>200</default>
                    abstract show: float with get, set
                    /// <default>50</default>
                    abstract search: float with get, set
                    /// <default>50</default>
                    abstract touch: float with get, set

            type MessageSettings =
                MessageSettings.Param

            module MessageSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>'Add &lt;b&gt;{term}&lt;/b&gt;'</default>
                    abstract addResult: string with get, set
                    /// <default>'{count} selected'</default>
                    abstract count: string with get, set
                    /// <default>'Max {maxCount} selections'</default>
                    abstract maxSelections: string with get, set
                    /// 'No results found.'
                    abstract noResults: string with get, set

            type SelectorSettings =
                SelectorSettings.Param

            module SelectorSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>'.addition'</default>
                    abstract addition: string with get, set
                    /// <default>'.ui.dropdown'</default>
                    abstract dropdown: string with get, set
                    /// <default>'&gt; .dropdown.icon'</default>
                    abstract icon: string with get, set
                    /// <default>'&gt; input[type="hidden"], &gt; select'</default>
                    abstract input: string with get, set
                    /// <default>'.item'</default>
                    abstract item: string with get, set
                    /// <default>'&gt; .label'</default>
                    abstract label: string with get, set
                    /// <default>'&gt; .label &gt; .delete.icon'</default>
                    abstract remove: string with get, set
                    /// <default>'.label'</default>
                    abstract siblingLabel: string with get, set
                    /// <default>'.menu'</default>
                    abstract menu: string with get, set
                    /// <default>'.message'</default>
                    abstract message: string with get, set
                    /// <default>'.dropdown.icon'</default>
                    abstract menuIcon: string with get, set
                    /// <default>'input.search, .menu &gt; .search &gt; input'</default>
                    abstract search: string with get, set
                    /// <default>'&gt; .text:not(.icon)'</default>
                    abstract text: string with get, set

            type RegExpSettings =
                RegExpSettings.Param

            module RegExpSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>/[-[\]{}()*+?.,\\^$|#\s]/g</default>
                    abstract escape: RegExp with get, set

            type MetadataSettings =
                MetadataSettings.Param

            module MetadataSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>'defaultText'</default>
                    abstract defaultText: string with get, set
                    /// <default>'defaultValue'</default>
                    abstract defaultValue: string with get, set
                    /// <default>'placeholderText'</default>
                    abstract placeholderText: string with get, set
                    /// <default>'text'</default>
                    abstract text: string with get, set
                    /// <default>'value'</default>
                    abstract value: string with get, set

            type ClassNameSettings =
                ClassNameSettings.Param

            module ClassNameSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>'active'</default>
                    abstract active: string with get, set
                    /// <default>'addition'</default>
                    abstract addition: string with get, set
                    /// <default>'animating'</default>
                    abstract animating: string with get, set
                    /// <default>'disabled'</default>
                    abstract disabled: string with get, set
                    /// <default>'ui dropdown'</default>
                    abstract dropdown: string with get, set
                    /// <default>'filtered'</default>
                    abstract filtered: string with get, set
                    /// <default>'hidden transition'</default>
                    abstract hidden: string with get, set
                    /// <default>'item'</default>
                    abstract item: string with get, set
                    /// <default>'ui label'</default>
                    abstract label: string with get, set
                    /// <default>'loading'</default>
                    abstract loading: string with get, set
                    /// <default>'menu'</default>
                    abstract menu: string with get, set
                    /// <default>'message'</default>
                    abstract message: string with get, set
                    /// <default>'multiple'</default>
                    abstract multiple: string with get, set
                    /// <default>'default'</default>
                    abstract placeholder: string with get, set
                    /// <default>'search'</default>
                    abstract search: string with get, set
                    /// <default>'selected'</default>
                    abstract selected: string with get, set
                    /// <default>'selection'</default>
                    abstract selection: string with get, set
                    /// <default>'upward'</default>
                    abstract upward: string with get, set
                    /// <default>'visible'</default>
                    abstract visible: string with get, set

            type ErrorSettings =
                ErrorSettings.Param

            module ErrorSettings =

                type [<AllowNullLiteral>] Param =
                    interface end

                type [<AllowNullLiteral>] _Impl =
                    /// <default>'You called a dropdown action that was not defined'</default>
                    abstract action: string with get, set
                    /// <default>'Once a select has been initialized behaviors must be called on the created ui dropdown'</default>
                    abstract alreadySetup: string with get, set
                    /// <default>'Allowing user additions currently requires the use of labels.'</default>
                    abstract labels: string with get, set
                    /// <default>'The method you called is not defined.'</default>
                    abstract method: string with get, set
                    /// <default>'This module requires ui transitions &lt;https: github.com="" semantic-org="" ui-transition=""&gt;'</default>
                    abstract noTransition: string with get, set
