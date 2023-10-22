using HigiaServer.Domain.Common;

namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    public IList<Task> Tasks { get; private set; } = new List<Task>();

    public Collaborator(string firstName, string lastName, string address, string phoneNumber, DateTimeOffset birthday, 
        Administrator administrator) : base(firstName, lastName, address, phoneNumber, birthday)
    {
        IsAdmin = false;
        LastModifiedBy = administrator;
        CreatedBy = administrator;
        
    }

    public void AddTaskToCollaborator(Task task)
    {
        Tasks.Add(task);
    }
}