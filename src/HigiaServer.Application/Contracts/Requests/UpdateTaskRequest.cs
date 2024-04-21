using HigiaServer.Domain.Enums;

namespace HigiaServer.Application.Contracts.Requests;

public class UpdateTaskRequest(
    Guid id,
    string title,
    UrgencyLevel urgencyLevel,
    Status status,
    Coordinates coordinates,
    List<Guid> collaboratorsId,
    string? description
)
{
    public Guid Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public UrgencyLevel UrgencyLevel { get; private set; } = urgencyLevel;
    public Status Status { get; private set; } = status;
    public Coordinates Coordinates { get; private set; } = coordinates;
    public List<Guid> CollaboratorsId { get; private set; } = collaboratorsId;
    public string? Description { get; private set; } = description;
}