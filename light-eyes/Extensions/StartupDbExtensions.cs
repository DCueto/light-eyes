using light_eyes.Data;
using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Extensions;

public static class StartupDbExtensions
{
    public static async Task CreateDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var dbContextService = services.GetRequiredService<AppDbContext>();

        try
        {
            await dbContextService.Database.EnsureCreatedAsync();
            await dbContextService.Database.MigrateAsync();
            
            // Custom static class and method that creates table rows if there is not any row data into db
            // DBInitializerSeedData.InitializeDatabase(dbContextService);
        }
        catch (Exception e)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError($"Migration issue {e.Message}");
        }
    }

    public static async Task InitializeAdminUser(IServiceProvider serviceProvider)
    {
        // var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        var adminEmail = "admin@light-eyes.com";
        var adminUsername = "admin";
        var adminPassword = "AdminP@ssword123!";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var admin = new AppUser { UserName = adminUsername, Email = adminEmail, IsActive = true };
            var createAdminResult = await userManager.CreateAsync(admin, adminPassword);

            if (createAdminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
        
    }
}