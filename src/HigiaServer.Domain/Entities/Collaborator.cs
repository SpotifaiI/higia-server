namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    public Administrator? CreatedBy { get; init; }
    public Administrator? LastModifiedBy { get; private set; }
    public List<Entities.Task> Tasks { get; protected set; } = new List<Entities.Task>();

    public Collaborator(string firstName, string lastName, string address, string phoneNumber, DateTime birthday) : base(firstName, lastName, address, phoneNumber, birthday)
    {
        IsAdmin = false;
    }

    public void AddTaskToCollaborator(Task task)
    {
        Tasks.Add(task);
    }
}