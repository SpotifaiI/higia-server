namespace HigiaServer.Domain.Entities;

public class Administrator : BaseUserEntity
{
    protected Administrator() { }
    public Administrator(string name, string email, string phoneNumber, DateTime birthday, string passwordHash)
        : base(name, email, phoneNumber, birthday, passwordHash)
    {
        IsAdmin = true;
    }
}