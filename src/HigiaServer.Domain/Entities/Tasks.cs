using HigiaServer.Domain.Enums;

namespace HigiaServer.Domain.Entities;

public class Task(
    string title,
    string[] coordinates,
    UrgencyLevel urgencyLevel,
    List<User> collaborators,
    string? description)
{
    public string Title { get; private set; } = title;
    public string[] Coordinates { get; private set; } = coordinates;
    public UrgencyLevel UrgencyLevel { get; private set; } = urgencyLevel;
    public List<User> Collaborators { get; private set; } = collaborators;
    public string? Description { get; private set; } = description;
    public Status Status { get; private set; } = Status.New;
}