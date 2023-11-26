namespace HigiaServer.Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(string name, string email, string phoneNumber, DateTime birthday)
        : base(name, email, phoneNumber, birthday)
    {
        IsAdmin = true;
    }
}