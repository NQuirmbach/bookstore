using BookStore.UserService.Database;
using BookStore.UserService.Database.Entities;
using BookStore.UserService.Exceptions;
using HotChocolate.Language;
using Microsoft.EntityFrameworkCore;

namespace BookStore.UserService.Graph.Users;

[ExtendObjectType(OperationType.Mutation)]
public class UserMutations
{
    [UsedImplicitly]
    [Error(typeof(EmailTakenException))]
    public async Task<User?> CreateUser(
        string email,
        string firstName,
        string lastName,
        [Service] AppDbContext context,
        CancellationToken cancellationToken
    )
    {
        if (await context.Users.AnyAsync(u => u.Email == email.ToLower(), cancellationToken))
        {
            throw new EmailTakenException(email);
        }

        var user = User.Create(email, firstName, lastName);

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user;
    }
}