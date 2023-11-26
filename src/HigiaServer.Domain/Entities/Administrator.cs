namespace HigiaServer.Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(string firstName, string lastName, string email, string phoneNumber, DateTime birthday)
        : base(firstName, lastName, email, phoneNumber, birthday)
    {
        IsAdmin = true;
    }
}