namespace HigiaServer.Domain.Entities;

public class User(bool isAdmin, string name, string email, string password, string? number)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public bool IsAdmin { get; private set; } = isAdmin;
    public string? Number { get; private set; } = number;
    public List<Task>? Tasks { get; private set; } = isAdmin ? [] : null;
}
