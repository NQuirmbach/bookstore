using BookStore.BookService.Database;
using BookStore.BookService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookService.Graph.Authors;

public class AuthorObjectType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.ImplementsNode();

        descriptor.Field(m => m.Id).ID();
        descriptor.Field(m => m.Name);
        descriptor.Field(m => m.Books)
            .Resolve(ctx =>
            {
                var dbContext = ctx.Services.GetRequiredService<AppDbContext>();
                return dbContext.Books
                    .Where(m => m.AuthorId == ctx.Parent<Author>().Id)
                    .ToListAsync(ctx.RequestAborted);
            });
    }
}