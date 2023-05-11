namespace BookStore.Gateway;

public static class GatewayExtensions
{
    public static void AddGraphlStiching(this WebApplicationBuilder builder)
    {
        var settings = new SchemaSettings();

        builder.Configuration.GetSection("Schema").Bind(settings);

        var graphBuilder = builder.Services
            .AddGraphQLServer();

        foreach (var (name, port) in settings.Endpoints)
        {
            builder.Services.AddHttpClient(name, c => c.BaseAddress = new Uri($"http://localhost:{port}/graphql"));
            graphBuilder = graphBuilder.AddRemoteSchema(name);
        }
    }
}