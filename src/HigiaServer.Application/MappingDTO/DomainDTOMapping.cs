using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Application.MappingDTO;

public class DomainDTOMapping : Profile
{
    public DomainDTOMapping()
    {
        CreateMap<Administrator, AdministratorDTO>().ReverseMap();
        CreateMap<Collaborator, CollaboratorDTO>().ReverseMap();
        CreateMap<Task, TaskDTO>().ReverseMap();

        CreateMap<CreateAdministratorDTO, Administrator>().ForMember(dest => dest.PasswordHash,
            opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

        CreateMap<CreateCollaboratorDTO, Collaborator>().ForMember(dest => dest.PasswordHash,
            opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
    }
}