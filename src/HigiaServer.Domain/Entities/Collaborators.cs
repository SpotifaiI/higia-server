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

    private void AddTaskToCollaborator(Collaborator collaborator, Task task)
    {
        collaborator.Tasks.Add(task);
    }
}