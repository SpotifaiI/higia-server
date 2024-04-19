using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Application.Repositories;

public interface ITaskRepository
{
    void AddTask(Task task);
    Task? GetTaskById(Guid taskId);
}