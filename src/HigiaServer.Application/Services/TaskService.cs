using AutoMapper;

using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;
using HigiaServer.Domain.Interfaces;

namespace HigiaServer.Application;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;
    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task CreateTask(TaskDTO taskDto)
    {
        var task = _mapper.Map<Domain.Entities.Task>(taskDto);
        await _taskRepository.CreateTask(task);
    }

    public async Task DeleteTask(Guid id)
    {
        await _taskRepository.DeleteTask(id);
    }

    public async Task<TaskDTO> GetTaskById(Guid id)
    {
        var task = await _taskRepository.GetTaskById(id);
        var taskDto = _mapper.Map<TaskDTO>(task);
        
        return taskDto;
    }

    public async Task<List<TaskDTO>> GetTasks()
    {
        var tasks = await _taskRepository.GetTasks();
        var tasksDto = _mapper.Map<List<TaskDTO>>(tasks);

        return tasksDto;
    }

    public async Task UpdateTask(TaskDTO taskDto)
    {
        var task = _mapper.Map<Domain.Entities.Task>(taskDto);
        await _taskRepository.UpdateTask(task);
    }
}
