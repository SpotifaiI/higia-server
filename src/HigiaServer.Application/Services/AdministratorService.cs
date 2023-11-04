using AutoMapper;

using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;

using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Services;

public class AdministratorService : IAdministratorService
{
    private AdministratorRepository _administratorRepository;
    public AdministratorService(IAdministratorService administratorService, IMapper mapper)
    {

    }

    public Task<List<AdministratorDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AdministratorDTO> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<AdministratorDTO> AddAsync(AdministratorDTO administratorDTO)
    {
        throw new NotImplementedException();
    }

    public Task<AdministratorDTO> UpdateAsync(AdministratorDTO administratorDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
