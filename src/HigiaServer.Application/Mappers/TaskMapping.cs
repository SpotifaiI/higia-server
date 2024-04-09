using AutoMapper;

using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Domain.Entities;

namespace HigiaServer.Application.Mappers;

public class TaskMapping : Profile
{
    public TaskMapping()
    {
        CreateMap<AddTaskRequest, Domain.Entities.Task>()
            .ConstructUsing(src =>
                new Domain.Entities.Task(
                    src.Title,
                    new string[] { src.Coordinates.Latitude, src.Coordinates.Longitude },
                    src.UrgencyLevel,
                    src.Description
                ));
    }
}