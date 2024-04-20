using HigiaServer.Application.Repositories;
using HigiaServer.Infra.DbContext;
using Microsoft.EntityFrameworkCore;
using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Infra.Repositories;

public class TaskRepository(HigiaServerContext context) : ITaskRepository
{
    private readonly HigiaServerContext _context = context;

    public async void AddTask(Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task<Task?> GetTaskById(Guid taskId)
    {
        return await _context.Tasks.SingleOrDefaultAsync(x => x.Id == taskId);
    }

    public async void UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
}
