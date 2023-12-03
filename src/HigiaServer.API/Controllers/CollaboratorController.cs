using HigiaServer.Application;
using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;
using HigiaServer.Domain.Entities;

using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
    [Authorize]
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
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> CreateCollaborator(CreateCollaboratorDTO collaboratorDTO)
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
    [Authorize(Roles = "Administrator")]
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
    [Authorize(Roles = "Administrator")]
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

    [HttpGet("{id}/tasks")]
    [Authorize]
    public async Task<IActionResult> GetTasksFromCollaborator(Guid id)
    {
        try
        {
            List<TaskDTO> tasks = await _collaboratorService.GetTasksFromCollaborator(id);
            return tasks is null || tasks.Count == 0 ? NoContent() : Ok(tasks);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}