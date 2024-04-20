using AutoMapper;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Application.Mappers;

public class TaskMapping : Profile
{
    public TaskMapping()
    {
        CreateMap<AddTaskRequest, Task>()
            .ConvertUsing(request => new Task(
                request.Title,
                new[] { request.Coordinates.Latitude, request.Coordinates.Longitude },
                request.UrgencyLevel,
                request.Description
            ));

        CreateMap<Task, TaskResponse>()
            .ConvertUsing(task => new TaskResponse(
                task.Id,
                task.Title,
                task.UrgencyLevel,
                new Coordinates(task.Coordinates[0], task.Coordinates[1]),
                task.Collaborators.Select(c => c.Id).ToList(),
                task.Description
            ));
    }
}