using light_eyes.Data;
using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Extensions;

public static class StartupDbExtensions
{
    public static async Task CreateDbIfNotExistsAndInitUserAdmin(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var dbContextService = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var configuration = services.GetRequiredService<IConfiguration>();

        try
        {
            await dbContextService.Database.EnsureCreatedAsync();
            await dbContextService.Database.MigrateAsync();
            
            // Custom static class and method that creates table rows if there is not any row data into db
            // DBInitializerSeedData.InitializeDatabase(dbContextService);
            
            // Initialize admin user
            await InitializeAdminUserAsync(userManager, configuration);
        }
        catch (Exception e)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError($"Migration issue {e.Message}");
        }
    }

    private static async Task InitializeAdminUserAsync(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        var adminSettings = configuration.GetSection("AdminSettings");
        var adminEmail = adminSettings["Email"];
        var adminUsername = adminSettings["Username"];
        var adminPassword = adminSettings["Password"];
        var adminRole = adminSettings["Role"];
        
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var admin = new AppUser { UserName = adminUsername, Email = adminEmail, IsActive = true };
            var createAdminResult = await userManager.CreateAsync(admin, adminPassword);

            if (createAdminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, adminRole);
            }
        }
        
    }
}