using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Domain.Interfaces;

public interface ITaskRepository
{
    Task<List<Task>> GetTasks();
    Task<Task> GetTaskById(Guid id);

    Task<Task> CreateTask(Task task);
    Task<Task> UpdateTask(Task task);
    Task<Task> DeleteTask(Guid id);
}