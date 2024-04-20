using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HigiaServer.Application.Contracts.Requests;

public class RegisterRequest(string email, string password, string name, bool isAdmin)
{
    public string Name { get; private set; } = name;

    [EmailAddress]
    public string Email { get; private set; } = email;

    [PasswordPropertyText]
    public string Password { get; set; } = password;

    public bool IsAdmin { get; private set; } = isAdmin;
}
