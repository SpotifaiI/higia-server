using HigiaServer.Application.Repositories;

namespace HigiaServer.Infra.Repositories;

public class TaskRepository : ITaskRepository
{
    private static readonly List<Domain.Entities.Task> Tasks = [];
    public void AddTask(Domain.Entities.Task task) => Tasks.Add(task);

}