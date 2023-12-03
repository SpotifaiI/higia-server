namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    protected Collaborator() { }

    public Collaborator(string name, string email, string phoneNumber, DateTime birthday, string passwordHash) :
        base(name, email, phoneNumber, birthday, passwordHash)
    {
        IsAdmin = false;
    }

    public List<Task>? Tasks { get; protected set; } = new();
}