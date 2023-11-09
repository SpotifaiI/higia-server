using HigiaServer.Infra.Data;

namespace HigiaServer.Infra.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _taskContext;

    public TaskRepository(ApplicationDbContext taskContext)
    {
        _taskContext = taskContext;
    }

    public async Task<Task> CreateTask(Task task)
    {
        _taskContext.Add(task);
        await _taskContext.SaveChangesAsync();
        return task;
    }

    public async Task<Task> DeleteTask(Guid id)
    {
        _taskContext.Remove(await GetTaskById(id));
        await _taskContext.SaveChangesAsync();

        return await GetTaskById(id);
    }

    public async Task<Task> GetTaskById(Guid id)
    {
        Task? task = await _taskContext.Tasks
            .Where(x => x.Id == id).FirstOrDefaultAsync();

        return task!;
    }

    public async Task<List<Task>> GetTasks()
    {
        return await _taskContext.Tasks.ToListAsync();
    }

    public async Task<Task> UpdateTask(Task task)
    {
        _taskContext.Update(task);
        await _taskContext.SaveChangesAsync();
        return task;
    }
}