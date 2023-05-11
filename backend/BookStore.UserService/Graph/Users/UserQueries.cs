using BookStore.UserService.Database;
using BookStore.UserService.Database.Entities;
using HotChocolate.Language;
using Microsoft.EntityFrameworkCore;

namespace BookStore.UserService.Graph.Users;

[ExtendObjectType(OperationType.Query)]
public class UserQueries
{
    [UsedImplicitly]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<User> GetUsers([Service] AppDbContext dbContext)
        => dbContext.Users.AsQueryable();

    [UsedImplicitly]
    public async Task<User?> GetUserById(
        [ID] Guid id,
        [Service] AppDbContext context,
        CancellationToken cancellationToken
    ) => await context.Users.SingleOrDefaultAsync(m => m.Id == id, cancellationToken);

}