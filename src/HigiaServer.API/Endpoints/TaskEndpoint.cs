using System.Security.Authentication;
using System.Security.Claims;
using AutoMapper;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;
using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.API.Endpoints;

public static class TaskEndpoint
{
    public static IEndpointRouteBuilder AddTaskEndpoint(this IEndpointRouteBuilder app)
    {
        var authEndpoint = app.MapGroup("higia-server/api/tasks")
            .WithTags("Tasks");

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
        authEndpoint.MapGet("/{taskId}", GetTask)
            .WithName("Get task by id")
            .Produces<TaskResponse>()
            .WithOpenApi(x =>
            {
                x.Summary = "Get task by id";
                return x;
            });

        return app;
    }

    #region private methods
    
    private static async Task<IResult> HandleAddTask(
        HttpContext context,
        AddTaskRequest request,
        IUserRepository userRepository,
        ITaskRepository taskRepository,
        IMapper mapper)
    {
        if (!context.User!.Identity!.IsAuthenticated) throw new UnauthenticatedException();
        if (context.User.FindFirstValue(ClaimTypes.Role) == "collaborator") throw new UnauthorizedAccessException();
        var task = mapper.Map<Task>(request);

        var collaborators = request.CollaboratorsId
            .Select(id => userRepository.GetUserById(id) ?? throw new CollaboratorIdNotFound(id.ToString()))
            .ToList();

        task.AddCollaboratorsToTask(collaborators);
        taskRepository.AddTask(task);

        var location = new Uri($"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/{task.Id}");
        var taskResponse = mapper.Map<TaskResponse>(task);
        return Results.Created(location, new StandardSuccessResponse<TaskResponse>(taskResponse, location));
    }

    private static async Task<IResult> GetTask(
        HttpContext context,
        string taskId,
        ITaskRepository taskRepository,
        IMapper mapper)
    {
        if (!context.User!.Identity!.IsAuthenticated) throw new AuthenticationException();
        if (!Guid.TryParse(taskId, out var id)) throw new NonGuidTypeException(taskId);

        var task = taskRepository.GetTaskById(id) ?? throw new TaskIdGivenNotFoundException(id.ToString());
        var taskResponse = mapper.Map<TaskResponse>(task);
        return Results.Ok(new StandardSuccessResponse<TaskResponse>(taskResponse));
    }
    
    #endregion
}