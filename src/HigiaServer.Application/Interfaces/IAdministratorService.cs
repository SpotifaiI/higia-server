using HigiaServer.Application.DTOs;

namespace HigiaServer.Application.Interfaces;

public interface IAdministratorService
{
    Task<List<AdministratorDTO>> GetAdministratorDTOs();
    Task<AdministratorDTO> GetAdministratorDTOById(Guid id);
    
    Task<AdministratorDTO> CreateAdministratorDTO(AdministratorDTO administrator);
    Task<AdministratorDTO> UpdateAdministrator(AdministratorDTO administrator);
    Task<AdministratorDTO> DeleteAdministrator(Guid id);
}
