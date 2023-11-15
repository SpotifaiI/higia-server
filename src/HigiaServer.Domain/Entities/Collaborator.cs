namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    public Collaborator(string firstName, string lastName, string address, string phoneNumber, DateTime birthday) :
        base(firstName, lastName, address, phoneNumber, birthday)
    {
        IsAdmin = false;
    }

    public List<Task> ?Tasks { get; protected set; } = new();
}