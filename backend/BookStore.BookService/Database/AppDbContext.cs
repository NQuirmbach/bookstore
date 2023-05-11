using BookStore.BookService.Database.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace BookStore.BookService.Database;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>()
            .Property(m => m.Categories)
            .HasColumnType("jsonb");
        
        base.OnModelCreating(builder);
    }
}