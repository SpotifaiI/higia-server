namespace HigiaServer.Application.Contracts.Requests;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
public class RegisterRequest(string email, string password, string name, bool isAdmin, string? number)
{
    [EmailAddress]
    public string Email { get; set; } = email;
    [PasswordPropertyText]
    public string Password { get; set; } = password;
    public string Name { get; set; } = name;
    public bool IsAdmin { get; set; } = isAdmin;
    public string? Number { get; set; } = number;
}