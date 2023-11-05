using HigiaServer.Application.DTOs;

namespace HigiaServer.Application.Interfaces;

public interface IAdministratorService
{
    Task<List<AdministratorDTO>> GetAdministrators();
    Task<AdministratorDTO> GetAdministratorById(Guid id);
    
    Task CreateAdministrator(AdministratorDTO administratorDto);
    Task UpdateAdministrator(AdministratorDTO administratorDto);
    Task DeleteAdministrator(Guid id);
}
