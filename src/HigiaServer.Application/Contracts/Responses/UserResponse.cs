using System.ComponentModel.DataAnnotations;

namespace HigiaServer.Application.Contracts.Responses;

public class UserResponse(string email, string name, bool isAdmin)
{
    public string Name { get; private set; } = name;

    [EmailAddress] public string Email { get; private set; } = email;

    public bool IsAdmin { get; private set; } = isAdmin;
}