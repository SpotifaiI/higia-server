using AutoMapper;
using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;
using HigiaServer.Domain.Entities;
using HigiaServer.Domain.Interfaces;

using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Services;

public class AdministratorService : IAdministratorService
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IMapper _mapper;
    public AdministratorService(IAdministratorRepository administratorRepository, IMapper mapper)
    {
        _administratorRepository = administratorRepository;
        _mapper = mapper;
    }

    public async Task CreateAdministrator(AdministratorDTO administratorDto)
    {
        var administrator = _mapper.Map<Administrator>(administratorDto);
        await _administratorRepository.CreateAdministrator(administrator);
    }

    public async Task DeleteAdministrator(Guid id)
    {
        await _administratorRepository.DeleteAdministrator(id);
    }

    public async Task<AdministratorDTO> GetAdministratorById(Guid id)
    {
        var administrator = await _administratorRepository.GetAdministratorById(id);
        var administratorDto = _mapper.Map<AdministratorDTO>(administrator);
        return administratorDto;
    }

    public async Task<List<AdministratorDTO>> GetAdministrators()
    {
        var administrators = await _administratorRepository.GetAdministrators();
        var administratorsDto = _mapper.Map<List<AdministratorDTO>>(administrators);
        return administratorsDto;
    }

    public async Task UpdateAdministrator(AdministratorDTO administratorDto)
    {
        var administrator = _mapper.Map<Administrator>(administratorDto);
        await _administratorRepository.UpdateAdministrator(administrator);
    }
}