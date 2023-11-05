using AutoMapper;

using HigiaServer.Application.DTOs;
using HigiaServer.Domain.Entities;

using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Application.Mappings;

public class DomainDTOMappings : Profile
{
    public DomainDTOMappings()
    {
        CreateMap<Administrator, AdministratorDTO>().ReverseMap();
        CreateMap<Collaborator, CollaboratorDTO>().ReverseMap();
        CreateMap<Task, TaskDTO>().ReverseMap();
    }
}
