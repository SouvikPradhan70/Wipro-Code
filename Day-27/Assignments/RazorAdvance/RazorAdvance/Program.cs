using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorAdvance.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    // Remove this line if you want default Index.cshtml as home
    // options.Conventions.AddPageRoute("/Products/Index", "/");  

    options.Conventions.AddPageRoute("/Products/Index", "/Products");
    options.Conventions.AddPageRoute("/Products/Details", "/Products/{id:int}");
    options.Conventions.AddPageRoute("/Products/Category", "/Products/Category/{categoryName}");
});
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.Run();
