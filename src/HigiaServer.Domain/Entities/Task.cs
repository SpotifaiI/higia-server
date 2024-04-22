using HigiaServer.Domain.Enums;

namespace HigiaServer.Domain.Entities;

public class Task(
    string title,
    string[] coordinates,
    UrgencyLevel urgencyLevel,
    string? description
)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = title;
    public UrgencyLevel UrgencyLevel { get; private set; } = urgencyLevel;
    public string? Description { get; private set; } = description;
    public string[] Coordinates { get; private set; } = coordinates;
    public Status Status { get; private set; } = Status.New;
    public List<User> Collaborators { get; } = [];

    public void UpdateTask(string? title = null, string? description = null, string[]? coordinates = null)
    {
        Title = title ?? Title;
        Description = description ?? Description;
        Coordinates = coordinates ?? Coordinates;
    }
    
    public void AddCollaboratorToTask(User user) => Collaborators.Add(user);

    public void AddCollaboratorsToTask(List<User> user) => Collaborators.AddRange(user);

    public void UpdateTaskStatus(Status newStatus) => Status = newStatus;
}
