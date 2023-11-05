using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Application.MappingDTO;

public class DomainDTOMapping : Profile
{
    public DomainDTOMapping()
    {
        CreateMap<Administrator, AdministratorDTO>().ReverseMap();
        CreateMap<Collaborator, CollaboratorDTO>().ReverseMap();
        CreateMap<Task, TaskDTO>().ReverseMap();
    }
}