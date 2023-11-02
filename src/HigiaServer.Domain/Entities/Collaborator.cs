namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    public List<Task> Tasks { get; protected set; } = new List<Task>();

    public Collaborator(string firstName, string lastName, string address, string phoneNumber, DateTime birthday) : base(firstName, lastName, address, phoneNumber, birthday)
    {
        IsAdmin = false;
    }

    public void AddTaskToCollaborator(Task task)
    {
        Tasks.Add(task);
    }
}