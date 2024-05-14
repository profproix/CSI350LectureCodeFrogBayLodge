## Custom Routes 
Create a custom route that includes the movie's rating. 
1. in Program.cs include this line above the app.MapControllerRoute(...) 
app.MapControllerRoute(name: "rating",
                pattern: "movie/{id:int}/{rating?}",
                defaults: new { controller = "rating", action = "Details" });
    Note: The id:int is a route constraint
2. In the Movies controller above the Details action, add  [route ("movie/{id:int}/{rating}")]
3. In the Index view, update the anchor tag to include this helper asp-route-beds="@item.rating"
4. Run your code and confirm the custom route is working. You should see something like `Movie/Details/3/PG`
