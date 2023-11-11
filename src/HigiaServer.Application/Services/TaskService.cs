using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Services;

public class TaskService : ITaskService
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task CreateTask(TaskDTO taskDto)
    {
        Domain.Entities.Task? task = _mapper.Map<Domain.Entities.Task>(taskDto);
        await _taskRepository.CreateTask(task);
    }

    public async Task DeleteTask(Guid id)
    {
        await _taskRepository.DeleteTask(id);
    }

    public async Task<TaskDTO> GetTaskById(Guid id)
    {
        Domain.Entities.Task task = await _taskRepository.GetTaskById(id);
        TaskDTO? taskDto = _mapper.Map<TaskDTO>(task);

        return taskDto;
    }

    public async Task<List<TaskDTO>> GetTasks()
    {
        List<Domain.Entities.Task> tasks = await _taskRepository.GetTasks();
        List<TaskDTO>? tasksDto = _mapper.Map<List<TaskDTO>>(tasks);

        return tasksDto;
    }

    public async Task UpdateTask(TaskDTO taskDto)
    {
        Domain.Entities.Task? task = _mapper.Map<Domain.Entities.Task>(taskDto);
        await _taskRepository.UpdateTask(task);
    }

    public async Task<TaskDTO> AddCollaborator(TaskDTO taskDto, CollaboratorDTO collaboratorDto)
    {
        Domain.Entities.Task? task = _mapper.Map<Domain.Entities.Task>(taskDto);
        Collaborator? collaborator = _mapper.Map<Domain.Entities.Collaborator>(collaboratorDto);
        
        return _mapper.Map<TaskDTO>(await _taskRepository.AddCollaborator(task, collaborator));
    }
}