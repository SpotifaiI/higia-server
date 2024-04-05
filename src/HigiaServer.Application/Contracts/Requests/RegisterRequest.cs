namespace HigiaServer.Application.Contracts.Requests;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
public class RegisterRequest(string email, string password, string name, bool isAdmin)
{
    [EmailAddress]
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    [PasswordPropertyText]
    public string Password { get; set; } = password;
    public bool IsAdmin { get; set; } = isAdmin;
}