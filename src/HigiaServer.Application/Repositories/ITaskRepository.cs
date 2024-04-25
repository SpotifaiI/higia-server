namespace HigiaServer.Application.Repositories;

public interface ITaskRepository
{
    void AddTask(HigiaServer.Domain.Entities.Task task);
    Task<HigiaServer.Domain.Entities.Task?> GetTaskById(Guid taskId);
    void UpdateTask(HigiaServer.Domain.Entities.Task task);
    void DeleteTask(Guid taskId);
}
