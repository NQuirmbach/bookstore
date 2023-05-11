using BookStore.UserService.Graph.Users;

namespace BookStore.UserService.Graph;

public static class Config
{
    public static void AddGraphQlBackend(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType()
            .AddMutationType()
            .AddGlobalObjectIdentification()
            
            .AddFiltering()
            .AddSorting()
            .AddMutationConventions()
            
            .AddUsers();
    }
}