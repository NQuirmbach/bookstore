using BookStore.BookService.Database.Entities;
using BookStore.BookService.Graph.Authors;

namespace BookStore.BookService.Graph.Books;

public class BookObjectType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.ImplementsNode();

        descriptor.Field(m => m.Id).ID();
        
        descriptor.Field(m => m.Title);
        descriptor.Field(m => m.Description);
        descriptor.Field(m => m.Year);
        descriptor.Field(m => m.Categories);

        descriptor.Field("author")
            .Resolve(ctx =>
                ctx.Services
                    .GetRequiredService<AuthorDataLoader>()
                    .LoadAsync(ctx.Parent<Book>().AuthorId, ctx.RequestAborted)
            );
    }
}