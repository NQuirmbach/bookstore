namespace BookStore.UserService.Exceptions;

public class EmailTakenException : Exception
{
    public EmailTakenException(string email)
        : base($"A user with the email {email} already exists")
    { }
}