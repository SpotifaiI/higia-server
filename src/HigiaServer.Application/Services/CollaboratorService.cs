using AutoMapper;

using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;
using HigiaServer.Domain.Entities;
using HigiaServer.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Services;

public class CollaboratorService : ICollaboratorService
{   
    private readonly IMapper _mapper;
    private readonly ICollaboratorRepository _collaboratorRepository;
    public CollaboratorService(ICollaboratorRepository collaboratorRepository, IMapper mapper)
    {
        _collaboratorRepository = collaboratorRepository;
        _mapper = mapper;
    }

    public async Task CreateCollaborator(CollaboratorDTO collaboratorDto)
    {
        var collaborator = _mapper.Map<Collaborator>(collaboratorDto);
        await _collaboratorRepository.CreateCollaborator(collaborator);
    }

    public async Task DeleteCollaborator(Guid id)
    {
        await _collaboratorRepository.DeleteCollaborator(id);
    }

    public async Task<CollaboratorDTO> GetCollaboratorById(Guid id)
    {
        var collaborator = await _collaboratorRepository.GetCollaboratorById(id);
        var collaboratorDto = _mapper.Map<CollaboratorDTO>(collaborator);
        return collaboratorDto;
    }

    public async Task<List<CollaboratorDTO>> GetCollaborators()
    {
        var collaborators = await _collaboratorRepository.GetCollaborators();
        var collaboratorsDto = _mapper.Map<List<CollaboratorDTO>>(collaborators);
        return collaboratorsDto;
    }

    public async Task UpdateCollaborator(CollaboratorDTO collaboratorDto)
    {
        var collaborator = _mapper.Map<Collaborator>(collaboratorDto);
        await _collaboratorRepository.UpdateCollaborator(collaborator);
    }

    public async Task AddTask(Guid id, Domain.Entities.Task task)
    {
        await _collaboratorRepository.AddTask(id, task);
    }
}
