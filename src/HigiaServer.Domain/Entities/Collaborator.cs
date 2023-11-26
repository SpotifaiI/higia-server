namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    public Collaborator(string name, string email, string phoneNumber, DateTime birthday) :
        base(name, email, phoneNumber, birthday)
    {
        IsAdmin = false;
    }

    public List<Task>? Tasks { get; protected set; } = new();
}