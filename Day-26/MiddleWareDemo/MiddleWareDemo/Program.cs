using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. Middleware: Log requests
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request received for: {context.Request.Path}");
    await next();
});

// 2. Serve static files from "publicfiles" folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "publicfiles")),
    RequestPath = "" // keep URL clean (no /publicfiles prefix)
});

// 3. Authentication middleware (optional)
app.Use(async (context, next) =>
{
    if (context.Request.Query.TryGetValue("auth", out var authKey) && authKey == "secret")
    {
        await next();
    }
    else
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Not authorized");
    }
});

// 4. Final fallback endpoint
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from Middleware Demo (no static file matched)!");
});

app.Run();
