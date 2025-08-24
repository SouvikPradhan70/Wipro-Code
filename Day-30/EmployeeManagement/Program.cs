using Microsoft.Extensions.Caching.Memory;
using EmployeeManagement.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Add MemoryCache support
builder.Services.AddMemoryCache();

// ✅ Register your custom cache filter so it can be injected
builder.Services.AddScoped<ProductCacheResultFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// ✅ This is needed for MVC pipeline to serve static + run filters
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
