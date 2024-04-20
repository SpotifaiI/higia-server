using HigiaServer.Domain.Enums;

namespace HigiaServer.Application.Contracts.Requests;

public class AddTaskRequest(
    string title,
    UrgencyLevel urgencyLevel,
    Coordinates coordinates,
    List<Guid> collaboratorsId,
    string? description
)
{
    public string Title { get; private set; } = title;
    public UrgencyLevel UrgencyLevel { get; private set; } = urgencyLevel;
    public Coordinates Coordinates { get; private set; } = coordinates;
    public List<Guid> CollaboratorsId { get; private set; } = collaboratorsId;
    public string? Description { get; private set; } = description;
}

public class Coordinates(string latitude, string longitude)
{
    public string Latitude { get; private set; } = latitude;
    public string Longitude { get; private set; } = longitude;
}
