using HigiaServer.Application.Repositories;
using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Infra.Repositories;

public class TaskRepository : ITaskRepository
{
    private static readonly List<Task> Tasks = [];

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public Task? GetTaskById(Guid taskId)
    {
        return Tasks.SingleOrDefault(x => x.Id == taskId);
    }
}