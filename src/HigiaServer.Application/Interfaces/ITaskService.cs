using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Interfaces;

public interface ITaskService
{
    Task<List<TaskDTO>> GetTasks();
    Task<TaskDTO> GetTaskById(Guid id);

    Task CreateTask(TaskDTO taskDto);
    Task UpdateTask(TaskDTO taskDto);
    Task DeleteTask(Guid id);

    Task<TaskDTO> AddCollaboratorToTask(Guid idCollaborator, Guid idTask);
    Task<List<CollaboratorDTO>> GetCollaboratorsFromTask(Guid id);
}