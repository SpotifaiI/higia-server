using HigiaServer.Application.DTOs;
using HigiaServer.Application.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HigiaServer.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetTasks()
    {
        try
        {
            List<TaskDTO> tasks = await _taskService.GetTasks();
            return tasks is null || tasks.Count == 0 ? NoContent() : Ok(tasks);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        try
        {
            TaskDTO task = await _taskService.GetTaskById(id);
            return task is null ? NoContent() : Ok(task);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> UpdateTask(TaskDTO taskDTO)
    {
        try
        {
            await _taskService.UpdateTask(taskDTO);
            return Ok("Task updated successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        try
        {
            await _taskService.DeleteTask(id);
            return Ok("Task deleted successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> CreateTask(TaskDTO taskDTO)
    {
        try
        {
            await _taskService.CreateTask(taskDTO);
            return StatusCode(201, "Task created successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{idCollaborator}/assign")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> AddCollaboratorToTask(Guid idTask, Guid idCollaborator)
    {
        try
        {
            await _taskService.AddCollaboratorToTask(idTask, idCollaborator);
            return Ok("Collaborator added successfully");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}/collaborators")]
    [Authorize]
    public async Task<IActionResult> GetCollaboratorsFromTask(Guid id)
    {
        try
        {
            List<CollaboratorDTO> collaborators = await _taskService.GetCollaboratorsFromTask(id);
            return collaborators is null || collaborators.Count == 0 ? NoContent() : Ok(collaborators);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}