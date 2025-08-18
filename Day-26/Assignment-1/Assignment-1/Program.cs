using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1) Force HTTPS (security requirement)
app.UseHttpsRedirection();

// 2) Request/Response logging (stopwatch + status code)
app.Use(async (context, next) =>
{
    var sw = Stopwatch.StartNew();
    Console.WriteLine($"--> {context.Request.Method} {context.Request.Path}");
    await next();
    sw.Stop();
    Console.WriteLine($"<-- {context.Response.StatusCode} [{sw.ElapsedMilliseconds}ms]");
});

// 3) Content Security Policy header (basic XSS protection)
app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] =
        "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self' data:; object-src 'none'; upgrade-insecure-requests";
    await next();
});


// 4) Error handler -> serve our custom static error page
app.UseExceptionHandler("/error.html");

// 5) Serve wwwroot (default file = index.html)
app.UseDefaultFiles(); // enables index.html as default
app.UseStaticFiles();   

app.MapGet("/api/hello", () => Results.Json(new{ message = "Hello From Middleware demo!"}));

app.Run();
