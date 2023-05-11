using BookStore.UserService.Database.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace BookStore.UserService.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}