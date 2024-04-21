# Security Authentication and Authorization 
## Topics
- Identity Framework 
- Authentication 
- Authorization: Creating Roles & Restricting access
- How to properly scaffold 

- Stretch Goal: Updating user info


## Adding more functionality 
We are adding <FrameworkReference Include="Microsoft.AspNetCore.app" /> to the project file. This will give us a bit more functionality and help resolve some scaffolding errors we see with the Identity framework. 

## Scaffold Identity 
- First, we Installed Microsoft.AspNetCore.Identity.EntityFrameworkCore   
- AppicationdbContext needs to be updated to inherit from Identity before we Scaffoled `ApplicationDbContext : IdentityDbContext<IdentityUser>`   
- Create a new scaffold item and walk through the steps for scaffolding identity. Select ApplicationDbcontext as it's context to avoid errors.    
	- Dealing with errors     
	    - You may or may not need to remove the following. As of the last time I scaffolded using ApplicationDbContext (with IdentityDbcontext), these issues have yet to come up.   
		- Identity may add an extra ApplicationDBContext! If there is a Data file in Areas -> Identity, remove the new ApplicationDbContext we will be using the one we built.   
		- Check applsetting.json. You may also see an extra connection string created by Identity; remove it as well.   
### Further Configuration
- Add  base.OnModelCreating(modelBuilder); to on Model creating in ApplicationDbContext   
- Add login partial to the nav in Layout   
- Add the Middlewear app.UseAuthentication(); before app.UseAuthorization(); to Program.cs. Order is essential here. A user should be Authenticated before they are Authorized to do anything.   
- Identity uses Razorpages, add builder.Services.AddRazorPages(); to the Program.cs as well.   
- Down above the MapControllerRoute add app.MapRazorPages(); this will set up our auth routes.   
- Add a new migration and update the database    

## Adding Roles
- Note: There are better practices for doing this, but I thought this solution by tutorials (see citation) would be a bit more accessible.   
- Add `.AddRoles<IdentityRole>()` to the following line in Programs.cs 
 It should look like this: builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();   

- Seed Roles and an Admin User by adding the following 
 ```
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
```

- We will need to first restrict our actions. Add `Authorize(Roles = "Admin")]` above the Get Create, Edit and Delete actions. 
- Lastly we need to remove the Create, Edit and Delete buttons from our View. In the Index View Nest the elements we'd like to remove in 
```
@if (User.IsInRole("Admin"))
   {

}	
```

### Sources
.net 8.0 scaffolding error solution 
Patel, B. (2023, November). .NET Core MVC - The Complete Guide 2023 [E-commerce] [.NET8]: Identity in .NET core. https://www.udemy.com/. Retrieved April 21, 2024, from https://www.udemy.com/course/complete-aspnet-core-21-course/?couponCode=KEEPLEARNING

Other references 
tutorialsEU - C#. (2023, February 23). ASP.NET User Roles - Create and Assign Roles for AUTHORIZATION! [Video]. YouTube. https://www.youtube.com/watch?v=Y6DCP-yH-9Q