## Blazor Complete Guide (WASM & Server .NET Core 5)
- Introduction:
    - Blazor, Blazor Server, .NET 5 API, Blazor WASM (Web Assembly.)
    - Project resources: 
        - [Course Content]<https://www.dotnetmastery.com/Home/Details?courseId=17>
        - [GitHub Repository]<https://github.com/bhrugen/HiddenVillaBlazor>
    - What is Blazor?
        - C# with server-side and client-side. Browser leverages web assemply.
        - Blazor hosting model. (1) Server. SignalR. (2) Client. Blazor, .NET, and WebAssembly to/from DOM.
        - Blazor server hosting model: 
            - Smaller download size. Application takes full advantage of server capabilities.
            - Thin clients are supported.
            - Disadvantages: Higher UI latency. No offline support. Scalability is challenging.
        - Blazor client WASM:
            - No .NET server-side dependency. ASP.NET Core web server is not required to host.
            - Work is offloaded from the server to the client.
            - Disadvantages: Browser capability resrtict the app. Download size is larger, and apps take longer to load. WebAssembly support is required.

- Blazor Basics:
    - One-way data binding.
    - Two-way data binding.
    - Components.

    - Blazor lifecycle:
        - OnInitialized() & OnInitializedAsync():
        - It is executed once the component is completely loaded. Useful for: Calling services.
        - OnParametersSet() & OnParametersSetAsync():
        - When a component is first initialized, and each time new or updated parameters are received from a parent, within the render tree.
        - OnAfterRender(bool firstRender) & OnAfterRenderAsync(bool firstRender):
        - Called after each render of the component. Perfect for attaching an event listener. Activate third-party JavaScript libraries.
        - Beware rendering complete, especially for something rendered on screen.
        - ShouldRender() returns a boolen value. If true, refresh the UI, otherwise changes are not sent to the UI.
        - StateHasChanged() is a method that notifies the component that its state has changed.

    - Event callback: e.g.: A child component accessing a parent component's method.
    ```csharp
        [Parameter()]
        public EventCallback<bool> OnSelection { get; set; }
    ```

- Blazor Intermediate:
    - Render fragment:
    - Attribute splatting: Override child attributes. e.g.: placeholder with a text box. 
        - Child component overrides. Also, attributes are overridden from left to right.
        ```csharp
            [Parameter(CaptureUnmatchedValues = true)]
            public Dictionary<string, object> InputAttrinutes { get; set; } = new Dictionary<string, object> {};
        ```
    - Casacding parameters: Ensure type, as name does not matter. And if it does, use "Name="
        ```javascript
            <CascadingValue Value="123" Name="X"><ChildComponent /></CascadingValue>
        ```
        ```csharp
            [CascadingParameter(Name="X")]
            public string X { get; set; }
        ```
    - Routing: Routes are not case sensitive. e.g.: NavLink gives us the "active" routing.
        ```javascript
            @page "/Route"
            @page "/NewRoute"
            @page "/Route/{Parameter1}"
            @inject NavagationalManager NavagationalManager
            <NavLink></NavLink>
        ```
        ```csharp
            [Parameter()]
            public string Parameter1 { get; set; }
            private void Scrape()
            {
                var absoluteUri = new Uri(NavagationalManager.Uri);
                var queryParams = System.Web.HttpUtility.ParseQueryString(absoluteUri.Query);
                var param1 = queryParams["Param1"];
            }
        ```
    - NavigationManager:
        ```csharp
            private void NavigateTo()
            {
                NavagationalManager.NavigateTo("prior-page");
            }
        ```

- Database In Blazor:
    - NOTE: Within Package Manager Console, ensure that your DAL is selected as the default project.
        ```javascript
            PM> add-migration CreateDatabase
            PM> update-database
        ```

- Blazor Forms & CRUD:
    - Forms:
        ```javascript
            <EditForm Model="obj" OnValidSubmit="OnValidSubmitAsync">
                <DataAnnotationsValidator />
                <ValidationSummary />
            </EditForm>
        ```

- Blazor & JavaScript:
    ```javascript
        @inject IJSRuntime js;
    ```
    - TOASTR. With a lengthy CDN setup wrappered via helper extensions.