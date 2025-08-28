using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Register services
    public void ConfigureServices(IServiceCollection services)
    {
        // Database context
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // MVC without HTTPS requirement
        services.AddControllersWithViews();
    }

    // Middleware pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Commented out HTTPS redirection
        // app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Authentication + Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        // Seed roles and users inside a scope
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            SeedUsersAndRoles(serviceProvider).Wait();
        }

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }

    private async Task SeedUsersAndRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Create roles if they don't exist
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        if (!await roleManager.RoleExistsAsync("User"))
            await roleManager.CreateAsync(new IdentityRole("User"));

        // Create admin user with Username = "admin"
        if (await userManager.FindByNameAsync("admin") == null)
        {
            var adminUser = new ApplicationUser { UserName = "admin", Email = "admin@example.com" };
            await userManager.CreateAsync(adminUser, "Admin@1234");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // Create normal user with Username = "user"
        if (await userManager.FindByNameAsync("user") == null)
        {
            var normalUser = new ApplicationUser { UserName = "user", Email = "user@example.com" };
            await userManager.CreateAsync(normalUser, "User@1234");
            await userManager.AddToRoleAsync(normalUser, "User");
        }
    }
}
