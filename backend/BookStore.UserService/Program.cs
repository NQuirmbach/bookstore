using BookStore.UserService.Database;
using BookStore.UserService.Graph;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseNpgsql(connectionString);
});

builder.Services.AddGraphQlBackend();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

await app.MigrateDbAsync();
app.Run();