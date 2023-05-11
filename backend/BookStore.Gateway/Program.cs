var builder = WebApplication.CreateBuilder(args);

builder.AddGraphlStiching();

var app = builder.Build();

app.MapGraphQL();

app.Run();