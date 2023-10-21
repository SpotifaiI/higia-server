namespace HigiaServer.Domain.Entities;

abstract public class User
{
    public Guid Id { get; init; }
    public bool IsAdmin { get; init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Adress { get; private set; }
    public DateTime Birthday { get; private set; }
    public int Number { get; private set; }

    public DateTime CreatedAt { get; init; }
    public DateTime UpdateAt { get; private set; }

    public User(Guid id, string firstName, string lastName, string adress, DateTime birthday, int number, bool isAdmin, DateTime createdAt, DateTime updateAt)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Adress = adress;
        Birthday = birthday;
        Number = number;
        IsAdmin = isAdmin;
        CreatedAt = createdAt;
        UpdateAt = updateAt;
    }
}
