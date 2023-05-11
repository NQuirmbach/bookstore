using BookStore.UserService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.UserService.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}