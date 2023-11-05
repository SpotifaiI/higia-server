namespace HigiaServer.Domain.Interfaces;

public interface ITaskRepository
{
    Task<List<Entities.Task>> GetTasks();
    Task<Entities.Task> GetTaskById(Guid id);
    
    Task<Entities.Task> CreateTask(Entities.Task task);
    Task<Entities.Task> UpdateTask(Entities.Task task);
    Task<Entities.Task> DeleteTask(Guid id);
}
