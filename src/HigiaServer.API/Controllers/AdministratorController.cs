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
            return administrators is null || administrators.Count == 0 ? NoContent() : Ok(administrators);
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
            return administrator is null ? NoContent() : Ok(administrator);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdministrator(AdministratorDTO administratorDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            await _administratorService.CreateAdministrator(administratorDTO);
            return StatusCode(201, "Administrator created successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAdministrator(AdministratorDTO administratorDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            await _administratorService.UpdateAdministrator(administratorDTO);
            return Ok("Administrator updated successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdministrator(Guid id)
    {
        try
        {
            await _administratorService.DeleteAdministrator(id);
            return Ok("Administrator deleted successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}