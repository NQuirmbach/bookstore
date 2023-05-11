using HotChocolate.Execution.Configuration;

namespace BookStore.UserService.Graph.Users;

public static class Config
{
    public static IRequestExecutorBuilder AddUsers(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<UserObjectType>()
            .AddType<UserQueries>()
            .AddType<UserMutations>();
    }
}