using BookStore.UserService.Database;
using Microsoft.EntityFrameworkCore;

namespace BookStore.UserService;

public static class MigrationHelper
{
    public static async Task MigrateDbAsync(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(MigrationHelper));

        try
        {
            logger.LogInformation("Starting db migration...");
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await dbContext.Database.MigrateAsync();
            
            logger.LogInformation("DB migration finished");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while migrating database");
        }
    }
}