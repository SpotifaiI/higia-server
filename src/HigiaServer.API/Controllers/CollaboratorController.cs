using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HigiaServer.API.Controllers;

[ApiController]
[Route("api/collaborators")]
public class CollaboratorController : ControllerBase
{
    private readonly ICollaboratorService _collaboratorService;

    public CollaboratorController(ICollaboratorService collaboratorService)
    {
        _collaboratorService = collaboratorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCollaborators()
    {
        try
        {
            List<CollaboratorDTO> collaborators = await _collaboratorService.GetCollaborators();
            return collaborators is null || collaborators.Count == 0 ? NoContent() : Ok(collaborators);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCollaboratorById(Guid id)
    {
        try
        {
            CollaboratorDTO collaborator = await _collaboratorService.GetCollaboratorById(id);
            return collaborator is null ? NoContent() : Ok(collaborator);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCollaborator(CollaboratorDTO collaboratorDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            await _collaboratorService.CreateCollaborator(collaboratorDTO);
            return StatusCode(201, "Collaborator created successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCollaborator(CollaboratorDTO collaboratorDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            await _collaboratorService.UpdateCollaborator(collaboratorDTO);
            return Ok("Collaborator updated successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCollaborator(Guid id)
    {
        try
        {
            await _collaboratorService.DeleteCollaborator(id);
            return Ok("Collaborator deleted successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}