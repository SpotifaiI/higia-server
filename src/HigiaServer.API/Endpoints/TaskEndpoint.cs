using System.Security.Authentication;
using System.Security.Claims;
using AutoMapper;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HigiaServer.API.Endpoints;

public static class TaskEndpoint
{
    public static IEndpointRouteBuilder AddTaskEndpoint(this IEndpointRouteBuilder app)
    {
        var authEndpoint = app.MapGroup("higia-server/api/tasks").WithTags("Tasks");

        // add task
        authEndpoint.MapPost("/", HandleAddTask)
            .WithName("Add new task")
            .Produces<TaskResponse>(StatusCodes.Status201Created)
            .WithOpenApi(x =>
            {
                x.Summary = "Add Tasks";
                return x;
            });

        // get task by id
        authEndpoint.MapGet("/{taskId:guid}", HandleGetTask)
            .WithName("Get task by id")
            .Produces<TaskResponse>()
            .WithOpenApi(x =>
            {
                x.Summary = "Get task by id";
                return x;
            });

        // update status
        authEndpoint.MapPatch("/{taskId:guid}/{status}", HandleUpdateTaskStatus)
            .WithName("Update Task Status")
            .WithOpenApi(x =>
            {
                x.Summary = "Update task status";
                return x;
            });
        
        // update task info
        authEndpoint.MapPut("/{taskId:guid}/info", HandleUpdateTaskInformation)
            .WithName("Update Task")
            .WithOpenApi(x =>
            {
                x.Summary = "Update task information";
                return x;
            });
        
        // add collaborator to task
        authEndpoint.MapPatch("/{taskId:guid}/collaborators/{collaboratorId:guid}", HandleAddCollaboratorToTask)
            .WithName("Add collaborator to task")
            .WithOpenApi(x =>
            {
                x.Summary = "Add collaborator to task";
                return x;
            });
        
        authEndpoint.MapDelete("/{taskId:guid}", HandleDeleteTask)
            .WithName("Delete task by id")
            .WithOpenApi(x =>
            {
                x.Summary = "Delete task by id";
                return x;
            });

        return app;
    }

    #region private methods

    private static async Task<IResult> HandleDeleteTask(
        HttpContext context, 
        Guid taskId, 
        ITaskRepository taskRepository)
    {
        CheckAuthorizationAsAdministrator(context);
        if (await taskRepository.GetTaskById(taskId) is not { } task)
        {
            return Results.BadRequest("Unable to update task because no matching task was found");
        }
        
        taskRepository.DeleteTask(taskId);
        return Results.Ok(new BaseSuccessResponse("task deleted successfully"));
    }
    
    private static async Task<IResult> HandleAddCollaboratorToTask(
        Guid taskId,
        Guid collaboratorId,
        HttpContext context,
        IUserRepository userRepository,
        ITaskRepository taskRepository,
        UpdateTaskRequest request
    )
    {
        CheckAuthorizationAsAdministrator(context);
        if (await taskRepository.GetTaskById(taskId) is not { } task)
        {
            return Results.BadRequest("Unable to update task because no matching task was found");
        }

        if (await userRepository.GetUserById(collaboratorId) is not { } collaborator)
        {
            return Results.BadRequest($"Collaborator with id {collaboratorId} was not found!");
        }

        if (!task.Collaborators.Contains(collaborator))
        {
            return Results.BadRequest(
                $"The collaborator with id {collaboratorId} is already participating in this task"
            );
        }

        task.AddCollaboratorToTask(collaborator);
        taskRepository.UpdateTask(task);

        context.Response.Headers.Location = $"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{task.Id}";
        
        return Results.Ok(new BaseSuccessResponse("collaborator successfully added to task"));
    }

    private static async Task<IResult> HandleUpdateTaskInformation(
        Guid taskId,
        HttpContext context,
        ITaskRepository taskRepository,
        UpdateTaskRequest request
    )
    {
        CheckAuthorizationAsAdministrator(context);
        if (await taskRepository.GetTaskById(taskId) is not { } task)
        {
            return Results.BadRequest("Unable to update task because no matching task was found");
        }

        task.UpdateTask(
            request.Title,
            request.Description,
            [request.Coordinates.Latitude, request.Coordinates.Longitude]
        );

        taskRepository.UpdateTask(task);

        context.Response.Headers.Location =
            $"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{taskId}";
        return Results.Ok();
    }

    private static async Task<IResult> HandleUpdateTaskStatus(
        HttpContext context,
        Guid taskId,
        Status status,
        ITaskRepository taskRepository
    )
    {
        CheckAuthorizationAsAdministrator(context);
        if (await taskRepository.GetTaskById(taskId) is not { } task)
            return Results.NoContent();

        task.UpdateTaskStatus(status);
        taskRepository.UpdateTask(task);

        context.Response.Headers.Location =
            $"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{task.Id}";
        return Results.Ok("task information updated successfully");
    }

    private static async Task<IResult> HandleAddTask(
        HttpContext context,
        AddTaskRequest request,
        IUserRepository userRepository,
        ITaskRepository taskRepository,
        IMapper mapper
    )
    {
        CheckAuthorizationAsAdministrator(context);
        var task = mapper.Map<Domain.Entities.Task>(request);

        var collaborators = (
            await Task.WhenAll(
                request.CollaboratorsId.Select(async id =>
                    await userRepository.GetUserById(id)
                    ?? throw new AddTaskCollaboratorNotFoundException(id.ToString())
                )
            )
        ).ToList();

        task.AddCollaboratorsToTask(collaborators);
        taskRepository.AddTask(task);

        var location = new Uri(
            $"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{task.Id}"
        );

        var taskResponse = mapper.Map<TaskResponse>(task);
        return Results.Created(
            location,
            new SuccessResponseWithT<TaskResponse>(taskResponse, location)
        );
    }

    private static async Task<IResult> HandleGetTask(
        HttpContext context,
        Guid taskId,
        ITaskRepository taskRepository,
        IMapper mapper
    )
    {
        if (!context.User!.Identity!.IsAuthenticated)
            throw new UnauthenticatedException();

        if (await taskRepository.GetTaskById(taskId) is not { } task)
            return Results.NoContent();

        var taskResponse = mapper.Map<TaskResponse>(task);
        return Results.Ok(new SuccessResponseWithT<TaskResponse>(taskResponse));
    }

    private static void CheckAuthorizationAsAdministrator(HttpContext context)
    {
        if (!context.User!.Identity!.IsAuthenticated)
            throw new UnauthenticatedException();
        if (context.User.FindFirstValue(ClaimTypes.Role) != "admin")
            throw new UnauthorizedAccessException();
    }

    #endregion
}
