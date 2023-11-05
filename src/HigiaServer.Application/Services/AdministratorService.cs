using AutoMapper;
using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;
using HigiaServer.Domain.Interfaces;

using Task = System.Threading.Tasks.Task;

namespace HigiaServer.Application.Services;

public class AdministratorService : IAdministratorService
{
    private IAdministratorRepository _administratorRepository;
    public AdministratorService(IAdministratorService administratorService, IMapper mapper)
    {

    }
}