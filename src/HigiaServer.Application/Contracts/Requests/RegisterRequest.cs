using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HigiaServer.Application.Contracts.Requests;

public class RegisterRequest(string email, string password, string name, bool isAdmin)
{
    [EmailAddress] public string Name { get; set; } = name;

    public string Email { get; set; } = email;

    [PasswordPropertyText] public string Password { get; set; } = password;

    public bool IsAdmin { get; set; } = isAdmin;
}