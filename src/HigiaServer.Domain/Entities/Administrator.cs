namespace HigiaServer.Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(string firstName, string lastName, string address, string phoneNumber, DateTime birthday)
        : base(firstName, lastName, address, phoneNumber, birthday)
    {
        IsAdmin = true;
    }
}