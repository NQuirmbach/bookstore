using BookStore.BookService.Database;
using BookStore.BookService.Database.Entities;
using HotChocolate.Language;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookService.Graph.Books;

[ExtendObjectType(OperationType.Query)]
public class BookQueries
{
    [UsedImplicitly]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<Book> GetBooks([Service] AppDbContext dbContext)
        => dbContext.Books.AsQueryable();

}