namespace HigiaServer.Domain.Entities;

public class Task(decimal[] coordinates, string? description, string? title, List<User> collaborators)
{
    public decimal[] Coordinates { get; private set; } = coordinates;
    public string? Description { get; private set; } = description;
    public string? Title { get; private set; } = title;

    public List<User> Collaborators { get; } = collaborators;
}