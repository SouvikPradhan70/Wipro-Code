var builder = WebApplication.CreateBuilder(args);
//Adding MVC
builder.Services.AddControllersWithViews(); //This adds the MVC services to the app
var app = builder.Build();

//app.MapGet("/", () => "Hello World!"); //mimal API endpoint

//Ex 1: Creating a list (hardcoded)
//here is am testing end point
app.MapGet("/Mobilephones", () => new List<string> { "Samsung", "Apple", "Xiaomi", "OnePlus" });

//Ex 2:Dynamic List(Query Parameter)
app.MapGet("/RepeatNames", (string name, int count) => Enumerable.Repeat(name, count).ToList());


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//step 1:Run this template as it it
//Step 2: Need to add MVC(http page)
        //We will be adding a MVC
                //create a controller
                //crate a view
                //Running u r app