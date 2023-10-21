using HigiaServer.Domain.Common;

namespace HigiaServer.Domain.Entities;

public class Collaborator : BaseUserEntity
{
    public IList<Task> Tasks { get; private set; } = new List<Task>();

    public Collaborator(string firstName, string lastName, string address, int number, DateTime? birthday, Administrator? lastModifiedBy,
    Administrator? createdBy) : base(firstName, lastName, address, number, birthday, lastModifiedBy, createdBy)
    {
        IsAdmin = false;
    }

    private void AddTaskToCollaborator(Collaborator collaborator, Task task)
    {
        collaborator.Tasks.Add(task);
    }
}