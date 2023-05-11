using BookStore.BookService.Database;
using BookStore.BookService.Graph.Authors;
using BookStore.BookService.Graph.Books;

namespace BookStore.BookService.Graph;

public static class Config
{
    public static void AddGraphQlBackend(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType()
            // .AddMutationType()
            .AddGlobalObjectIdentification()
            .RegisterDbContext<AppDbContext>()
            
            .AddFiltering()
            .AddSorting()
            // .AddMutationConventions()
            
            .AddBooks()
            .AddAuthors();

        services.AddScoped<AuthorDataLoader>();
    }
}