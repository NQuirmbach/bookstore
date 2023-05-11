namespace BookStore.BookService.Database.Entities;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required int Year { get; set; }
    public required string Description { get; set; }
    public required ICollection<string> Categories { get; set; }

    public Guid AuthorId { get; set; }
}