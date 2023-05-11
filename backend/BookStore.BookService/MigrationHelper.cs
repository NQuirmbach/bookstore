using BookStore.BookService.Database;
using BookStore.BookService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#pragma warning disable CS8601
#pragma warning disable CS8604
#pragma warning disable CS8619

namespace BookStore.BookService;

public static class MigrationHelper
{
    public static async Task MigrateDbAsync(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(MigrationHelper));

        try
        {
            logger.LogInformation("Starting db migration...");
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.MigrateAsync();

            await SeedAsync(scope.ServiceProvider, context, logger);
            
            logger.LogInformation("DB migration finished");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while migrating database");
        }
    }

    private static async Task SeedAsync(IServiceProvider services, AppDbContext context, ILogger logger)
    {
        if (await context.Books.AnyAsync()) return;

        var hostEnv = services.GetRequiredService<IHostEnvironment>();

        var seedFile = hostEnv.ContentRootFileProvider.GetFileInfo("seed.json");
        if (!seedFile.Exists)
        {
            logger.LogWarning("No seed file found");
            return;
        }

        try
        {
            await using var s = seedFile.CreateReadStream();

            var authors = await ReadSeedData(s);

            context.Authors.AddRange(authors);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while seeding data");
        }
    }

    private static async Task<ICollection<Author>> ReadSeedData(Stream s)
    {
        using var sr = new StreamReader(s);
        await using var reader = new JsonTextReader(sr);

        var jObj = await JObject.ReadFromAsync(reader);

        var result = new List<Author>();

        foreach (var jBook in jObj["books"].ToArray())
        {
            var authorName = jBook["author"].Value<string>();

            var author = result.SingleOrDefault(m => m.Name == authorName);
            if (author == null)
            {
                author = new Author()
                {
                    Name = authorName
                };
                result.Add(author);
            }

            var book = new Book()
            {
                Title = jBook["title"].Value<string>(),
                Description = jBook["description"].Value<string>(),
                Year = jBook["year"].Value<int>(),
                Categories = jBook["categories"]
                        .ToArray()
                        .Select(t => t.Value<string>())
                        .ToArray(),
            };

            author.Books.Add(book);
        }

        return result;
    }
}