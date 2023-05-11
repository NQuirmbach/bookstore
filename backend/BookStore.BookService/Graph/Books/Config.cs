using HotChocolate.Execution.Configuration;

namespace BookStore.BookService.Graph.Books;

public static class Config
{
    public static IRequestExecutorBuilder AddBooks(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<BookObjectType>()
            .AddType<BookQueries>();
    }
}