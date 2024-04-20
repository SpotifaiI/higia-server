using System.Security.Authentication;
using System.Security.Claims;
using AutoMapper;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Enums;

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

        authEndpoint.MapPatch("/{taskId:guid}/{status}", HandleUpdateTaskStatus)
            .WithName("Update Task Status")
            .WithOpenApi(x =>
            {
                x.Summary = "Get task by id";
                return x;
            });

        return app;
    }

    #region private methods

    private static async Task<IResult> HandleUpdateTaskStatus(
        HttpContext context,
        Guid taskId,
        Status status,
        ITaskRepository taskRepository
    )
    {
        CheckAuthorizationAsAdministrator(context);
        if (await taskRepository.GetTaskById(taskId) is not { } task) return Results.NoContent();
        
        task.UpdateTaskStatus(status);
        taskRepository.UpdateTask(task);

        context.Response.Headers.Location = $"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{task.Id}";
        return Results.Ok();
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
        
        var collaborators = (await Task.WhenAll(request.CollaboratorsId
            .Select(async id => await userRepository.GetUserById(id) ?? throw new AddTaskCollaboratorNotFoundException(id.ToString()))))
            .ToList();

        task.AddCollaboratorsToTask(collaborators);
        taskRepository.AddTask(task);

        var location = new Uri($"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{task.Id}");
        
        var taskResponse = mapper.Map<TaskResponse>(task);
        return Results.Created(location, new StandardSuccessResponse<TaskResponse>(taskResponse, location));
    }

    private static async Task<IResult> HandleGetTask(
        HttpContext context,
        Guid taskId,
        ITaskRepository taskRepository,
        IMapper mapper
    )
    {
        if (!context.User!.Identity!.IsAuthenticated) throw new UnauthenticatedException();
        
        if (await taskRepository.GetTaskById(taskId) is not { } task) return Results.NoContent();
        
        var taskResponse = mapper.Map<TaskResponse>(task);
        return Results.Ok(new StandardSuccessResponse<TaskResponse>(taskResponse));
    }

    private static void CheckAuthorizationAsAdministrator(HttpContext context)
    {
        if (!context.User!.Identity!.IsAuthenticated) throw new UnauthenticatedException();
        if (context.User.FindFirstValue(ClaimTypes.Role) != "admin") throw new UnauthorizedAccessException();
    }
    #endregion
}
