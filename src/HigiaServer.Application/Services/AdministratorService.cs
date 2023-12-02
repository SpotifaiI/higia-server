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

    public async Task CreateAdministrator(CreateAdministratorDTO administratorDto)
    {
        Administrator? administrator = _mapper.Map<Administrator>(administratorDto);
        await _administratorRepository.CreateAdministrator(administrator);
    }

    public async Task DeleteAdministrator(Guid id)
    {
        await _administratorRepository.DeleteAdministrator(id);
    }

    public async Task<AdministratorDTO> GetAdministratorById(Guid id)
    {
        Administrator administrator = await _administratorRepository.GetAdministratorById(id);
        AdministratorDTO? administratorDto = _mapper.Map<AdministratorDTO>(administrator);
        return administratorDto;
    }

    public async Task<List<AdministratorDTO>> GetAdministrators()
    {
        List<Administrator> administrators = await _administratorRepository.GetAdministrators();
        List<AdministratorDTO>? administratorsDto = _mapper.Map<List<AdministratorDTO>>(administrators);
        return administratorsDto;
    }

    public async Task UpdateAdministrator(AdministratorDTO administratorDto)
    {
        Administrator? administrator = _mapper.Map<Administrator>(administratorDto);
        await _administratorRepository.UpdateAdministrator(administrator);
    }
}