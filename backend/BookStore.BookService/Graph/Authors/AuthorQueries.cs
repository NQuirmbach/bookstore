using BookStore.BookService.Database;
using BookStore.BookService.Database.Entities;
using HotChocolate.Language;
using JetBrains.Annotations;

namespace BookStore.BookService.Graph.Authors;

[ExtendObjectType(OperationType.Query)]
public class AuthorQueries
{
    [UsedImplicitly]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<Author> GetAuthors([Service] AppDbContext dbContext)
        => dbContext.Authors.AsQueryable();
    
}