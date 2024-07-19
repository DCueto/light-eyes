using light_eyes.Data;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Extensions;

public static class StartupDbExtensions
{
    public static async void CreateDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var dbContextService = services.GetRequiredService<AppDbContext>();

        try
        {
            dbContextService.Database.EnsureCreated();
            dbContextService.Database.Migrate();
            
            // Custom static class and method that creates table rows if there is not any row data into db
            // DBInitializerSeedData.InitializeDatabase(dbContextService);
        }
        catch (Exception e)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError($"Migration issue {e.Message}");
        }
    }
}