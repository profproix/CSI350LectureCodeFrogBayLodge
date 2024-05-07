using FrogBayLodge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Note: Configures DB context 
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
//Note: Identity uses Razor Pages, this allows the use of RazorPages in our app
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//Nopte: UseRouting adds route matching to the middleware pipeline. This middleware looks at the set of endpoints defined in the app, and selects the best match based on the request.
app.UseRouting();
//Note: Why do we place these here?
//Apply an authorization policy before UseEndpoints dispatches to the endpoint.
app.UseAuthentication();
app.UseAuthorization();
//Note: Configres routing for Identity 
app.MapRazorPages();
//Note: Customized route Route templates
app.MapControllerRoute(name: "room",
                pattern: "room/{id:int}/beds/{beds?}",
                defaults: new { controller = "Room", action = "Details" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

//Note: Seeding roles and a user with a specific role is a bit more complext so we will need to seed the roles and a defaul admin user in here. 
//Note: Seeds Roles
using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Customer", "RewardsMember" };
    foreach(var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roles = new[] { "Admin", "Customer", "RewardsMember" };
    string email = "admin@gmail.com";
    string password = "Aa123456!";
    if(await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;
        await userManager.CreateAsync(user,password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}
//Citation: (ASP.Net User Roles - Create and Assign Roles for Authorization!)

//Note: 
//Endpoints
//Endpoints represent units of the app's functionality that are distinct from each other in terms of routing, authorization, and any number of ASP.NET Core's systems.
//An endpoint is something that can be:

//Selected, by matching the URL and HTTP method.
//Executed, by running the delegate.




//Note: This will show info about our routing in console, to show what's going on under the hood
app.Use(async (context, next) =>
{
 
  
    var currentEndpoint = context.GetEndpoint();

    if (currentEndpoint is null)
    {
        await next(context);
        return;
    }

    Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

    if (currentEndpoint is RouteEndpoint routeEndpoint)
    {
        Console.WriteLine($"  - Route Pattern: {routeEndpoint.RoutePattern}");
    }

    foreach (var endpointMetadata in currentEndpoint.Metadata)
    {
        Console.WriteLine($"  - Metadata: {endpointMetadata}");
    }

    await next(context);
});

app.MapGet("/test", () => "Inspect Endpoint.");

app.MapGet("/hello", () => "Hello World!");
app.Run();
//Notes reference for routing: Rick-Anderson. (2023, September 20). Routing in ASP.NET core. Microsoft Learn. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-8.0#route-constraints