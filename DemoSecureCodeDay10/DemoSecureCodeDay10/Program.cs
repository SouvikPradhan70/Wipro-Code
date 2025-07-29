var builder = WebApplication.CreateBuilder(args);

//adding  htps redirection(Force secure connection)
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 433; // Default HTTPS port


});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Middlewear orders mattters
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
