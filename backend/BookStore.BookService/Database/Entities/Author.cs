namespace BookStore.BookService.Database.Entities;

public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}