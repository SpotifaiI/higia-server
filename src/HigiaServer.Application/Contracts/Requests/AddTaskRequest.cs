using HigiaServer.Domain.Enums;

namespace HigiaServer.Application.Contracts.Requests;

public class AddTaskRequest(
    string title,
    UrgencyLevel urgencyLevel,
    string description,
    Coordinates coordinates,
    List<Guid> collaborators)
{
    public string Title { get; set; } = title;
    public UrgencyLevel UrgencyLevel { get; set; } = urgencyLevel;
    public string Description { get; set; } = description;
    public Coordinates Coordinates { get; set; } = coordinates;
    public List<Guid> Collaborators { get; set; } = collaborators;
}

public record Coordinates(string Latitude, string Longitude);