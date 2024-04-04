namespace HigiaServer.Domain.Entities;

public class User(bool isAdmin, string email, string name, string number, string password)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool IsAdmin { get; private set; } = isAdmin;
    public string Email { get; private set; } = email;
    public string Name { get; private set; } = name;
    public string Number { get; private set; } = number;
    public string Password { get; private set; } = password;
    public List<Task>? Tasks { get; private set; } = isAdmin ? [] : null;
}