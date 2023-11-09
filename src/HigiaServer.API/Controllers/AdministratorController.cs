using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace HigiaServer.API.Controllers;

[ApiController]
[Route("api/administrators")]
public class AdministratorController : ControllerBase
{
    private readonly IAdministratorService _administratorService;

    public AdministratorController(IAdministratorService administratorService)
    {
        _administratorService = administratorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAdministrators()
    {
        try
        {
            List<AdministratorDTO> administrators = await _administratorService.GetAdministrators();
            return Ok(administrators);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdministratorById(Guid id)
    {
        try
        {
            AdministratorDTO administrator = await _administratorService.GetAdministratorById(id);
            return Ok(administrator);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}