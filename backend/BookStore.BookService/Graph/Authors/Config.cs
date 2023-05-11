using HotChocolate.Execution.Configuration;

namespace BookStore.BookService.Graph.Authors;

public static class Config
{
    public static IRequestExecutorBuilder AddAuthors(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<AuthorObjectType>()
            .AddType<AuthorQueries>();
    }
}