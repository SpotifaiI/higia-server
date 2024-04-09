using AutoMapper;

using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;

namespace HigiaServer.API.Endpoints;

public static class TaskEndpoint
{
    public static IEndpointRouteBuilder AddTaskEndpoint(this IEndpointRouteBuilder app)
    {
        var authEndpoint = app.MapGroup("higia-server/api/")
            .WithTags("Tasks");

        // register
        authEndpoint.MapPost("tasks",
                async (HttpContext context, AddTaskRequest request, IUserRepository userRepository,
                        ITaskRepository taskRepository, IMapper mapper)
                => await HandleAddTask(context, request, userRepository, taskRepository, mapper)
            );

        return app;
    }

    private static async Task<IResult> HandleAddTask(
        HttpContext context,
        AddTaskRequest request,
        IUserRepository userRepository,
        ITaskRepository taskRepository,
        IMapper mapper)
    {
        if (!context.User!.Identity!.IsAuthenticated) throw new UnauthenticatedUserException();
        if (!request.Collaborators.All(id => userRepository.GetUserById(id) != null)) throw new Exception();

        var task = mapper.Map<Domain.Entities.Task>(request);
        task.AddCollaboratorsToTask(request.Collaborators
            .Select(id => userRepository.GetUserById(id)!)
            .ToList());

        taskRepository.AddTask(task);

        return Results.Ok();
    }
}