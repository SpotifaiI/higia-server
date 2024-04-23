using HigiaServer.Domain.Enums;

namespace HigiaServer.Application.Contracts.Requests;

public class UpdateTaskRequest(string title, Coordinates coordinates, string? description)
{
    public string Title { get; private set; } = title;
    public Coordinates Coordinates { get; private set; } = coordinates;
    public string? Description { get; private set; } = description;
}
