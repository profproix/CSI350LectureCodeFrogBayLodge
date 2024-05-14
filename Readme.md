# Controllers and Routes 
## Objectives: Students will be able to
- Review MVC Pattern
- Build Controller Actions 
- Create Custome routes 


## Custom Routes 
Create a custom route that includes the number of beds in our rooms. 
1. in Program.cs include this line above the app.MapControllerRoute(...) 
app.MapControllerRoute(name: "room",
                pattern: "room/{id:int}/beds/{beds?}",
                defaults: new { controller = "Room", action = "Details" });
    Note: The id:int is a route constraint
2. In the Rooms controller above the Details action, add   [Route("room/{id:int}/beds/{beds?}")]
3. In the Index view, update the anchor tag to include this helper asp-route-beds="@item.Beds"
4. Run your code and confirm the custom route is working. You should see something like `Room/2/beds/2`
