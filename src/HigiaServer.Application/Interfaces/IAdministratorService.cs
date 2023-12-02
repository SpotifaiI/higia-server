using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Interfaces;

public interface IAdministratorService
{
    Task<List<AdministratorDTO>> GetAdministrators();
    Task<AdministratorDTO> GetAdministratorById(Guid id);

    Task CreateAdministrator(CreateAdministratorDTO administratorDto);
    Task UpdateAdministrator(AdministratorDTO administratorDto);
    Task DeleteAdministrator(Guid id);
}