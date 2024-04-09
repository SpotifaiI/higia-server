using HigiaServer.Domain.Enums;

namespace HigiaServer.Domain.Entities;

public class Task(
    string title,
    string[] coordinates,
    UrgencyLevel urgencyLevel,
    string? description)
{
    public string Title { get; private set; } = title;
    public UrgencyLevel UrgencyLevel { get; private set; } = urgencyLevel;
    public string? Description { get; private set; } = description;
    public string[] Coordinates { get; private set; } = coordinates;
    public Status Status { get; private set; } = Status.New;
    public List<User> Collaborators { get; private set; } = [];

    public void AddCollaboratorToTask(User user) => Collaborators.Add(user);
    public void AddCollaboratorsToTask(List<User> user) => Collaborators.AddRange(user);
}