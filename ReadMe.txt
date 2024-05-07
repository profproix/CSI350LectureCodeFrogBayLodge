# Views
## Topics
- Views Review
- Razor Pages
- Partials
- View Components 
- Tag helpers

### Razor View Engine
- Markup that generates HTML and server-side code

### View Components 
- View Components are like partials with more logic. 
1. Create a folder called Components.
2. Create a class for your component; in this demo we are creating a dynamic drop-down menu so our component is called `SpaMenuViewComponent.cs`
3. Have SpaMenuViewComponent inherit from ViewComponent `  public class SpaMenuViewComponent : ViewComponent`
4. We will need access to our database so bring context into the class. 
```
  private readonly ApplicationDbContext _context;

        public SpaMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
```
5. Since we need access to the database to grab our spa package names, create an async task <IViewComponentResult> called InvokeAsync(). Use context to access the Spa packages and pass them to the view component. 
```
  public async Task<IViewComponentResult> InvokeAsync()
        {
            var spa = await _context.Spa.ToListAsync();
            return View(spa);
        }
```

6. In the shared folder, create a components folder. Within that folder, create a SpaMenu folder. Name the field Default.cshtml and add your markdown and styling.
```
<li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle role="button" data-bs-toggle="dropdown">Spa Packages</a>
    <ul class="dropdown-menu">
        @foreach(var spaPackage in Model)
        {
            <li> <a asp-controller="Spa" asp-action="Details" asp-route-id="@spaPackage.Id" class="text-decoration-none text-reset">@spaPackage.Package</a> </li>
        }
    </ul>
</li>

```

### Custom Helper Tags
- We will create a custom helper tag that will create a <a> for a phone number
1. Create a folder called Helpers 
2. Create a class for your tag called `CustomContactTagHelper.cs`
3. Have CustomeContactTagHelper inherit from TagHelper `public class CustomContactTagHelper : TagHelper`
4. Create an attribute PhoneNumber. ` public string PhoneNumber { get; set; }`
5. Process is a TagHelper method allowing us to create our TagHelper. override the method with ` public override void Process(TagHelperContext context, TagHelperOutput output)`
6. Within the Process method, use output.TagName is used to define the HTML tag we are creating; output.Attributes.SetAttribut is used to set its href to the PhoneNumber and output.Content.SetContent  is used to set the displayed text to PhoneNumber
```
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "tel: +" + PhoneNumber);
            output.Content.SetContent(PhoneNumber);
        
```
7. _ViewImports.cshtml is where we import our existing helper tags. To import our custom tag, add `@addTagHelper *, FrogBayLodge` to the file. 
8. To use the helper in a view, we can invoke the helper using the Tags name; our Tag is CustomContactTagHelper, so its tag is <custom-contact>. To set the PhoneNumber attribute, we can add an attribute to our helper called 'phone-number'
```
    <div class="container">
            Phone: <custom-contact phone-number="000-111-2222"></custom-contact>
        </div>
```