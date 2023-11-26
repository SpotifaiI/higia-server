using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Domain.Interfaces;

public interface ICollaboratorRepository
{
    Task<List<Collaborator>> GetCollaborators();
    Task<Collaborator> GetCollaboratorById(Guid id);

    Task<Collaborator> CreateCollaborator(Collaborator collaborator);
    Task<Collaborator> UpdateCollaborator(Collaborator collaborator);
    Task<Collaborator> DeleteCollaborator(Guid id);

    Task<Collaborator> AddTask(Guid id, Task task);
    Task<List<Task>> GetTasksFromCollaborator(Guid id);
}