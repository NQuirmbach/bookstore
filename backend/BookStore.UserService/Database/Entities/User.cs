namespace BookStore.UserService.Database.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }

    public static User Create(string email, string firstName, string lastName)
    {
        return new User()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName
        };
    }
}