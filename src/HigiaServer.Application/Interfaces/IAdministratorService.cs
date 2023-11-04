using HigiaServer.Application.DTOs;

namespace HigiaServer.Application.Interfaces;

public interface IAdministratorService
{
    Task<List<AdministratorDTO>> GetAllAsync();
    Task<AdministratorDTO> GetByIdAsync(Guid id);
    Task<AdministratorDTO> AddAsync(AdministratorDTO administratorDTO);
    Task<AdministratorDTO> UpdateAsync(AdministratorDTO administratorDTO);
    Task RemoveAsync(Guid id);
}
