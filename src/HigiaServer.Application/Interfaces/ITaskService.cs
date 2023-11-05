using HigiaServer.Application.DTOs;

namespace HigiaServer.Application.Interfaces;

public interface ITaskService
{
    Task<List<TaskDTO>> GetTasks();
    Task<TaskDTO> GetTaskById(Guid id);

    Task CreateTask(TaskDTO taskDto);
    Task UpdateTask(TaskDTO taskDto);
    Task DeleteTask(Guid id);
}
