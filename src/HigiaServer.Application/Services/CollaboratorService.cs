using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Services;

public class CollaboratorService : ICollaboratorService
{
    private readonly ICollaboratorRepository _collaboratorRepository;
    private readonly IMapper _mapper;

    public CollaboratorService(ICollaboratorRepository collaboratorRepository, IMapper mapper)
    {
        _collaboratorRepository = collaboratorRepository;
        _mapper = mapper;
    }

    public async Task CreateCollaborator(CreateCollaboratorDTO collaboratorDto)
    {
        Collaborator? collaborator = _mapper.Map<Collaborator>(collaboratorDto);
        await _collaboratorRepository.CreateCollaborator(collaborator);
    }

    public async Task DeleteCollaborator(Guid id)
    {
        await _collaboratorRepository.DeleteCollaborator(id);
    }

    public async Task<CollaboratorDTO> GetCollaboratorById(Guid id)
    {
        Collaborator collaborator = await _collaboratorRepository.GetCollaboratorById(id);
        CollaboratorDTO? collaboratorDto = _mapper.Map<CollaboratorDTO>(collaborator);
        return collaboratorDto;
    }

    public async Task<List<CollaboratorDTO>> GetCollaborators()
    {
        List<Collaborator> collaborators = await _collaboratorRepository.GetCollaborators();
        List<CollaboratorDTO>? collaboratorsDto = _mapper.Map<List<CollaboratorDTO>>(collaborators);
        return collaboratorsDto;
    }

    public async Task UpdateCollaborator(CollaboratorDTO collaboratorDto)
    {
        Collaborator? collaborator = _mapper.Map<Collaborator>(collaboratorDto);
        await _collaboratorRepository.UpdateCollaborator(collaborator);
    }

    public async Task AddTask(Guid id, Domain.Entities.Task task)
    {
        await _collaboratorRepository.AddTask(id, task);
    }

    public async Task<List<TaskDTO>> GetTasksFromCollaborator(Guid id)
    {
        List<Domain.Entities.Task> tasks = await _collaboratorRepository.GetTasksFromCollaborator(id);
        List<TaskDTO>? tasksDto = _mapper.Map<List<TaskDTO>>(tasks);
        return tasksDto;
    }
}