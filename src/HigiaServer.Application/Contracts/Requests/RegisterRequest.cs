namespace HigiaServer.Application.Contracts.Requests;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
public class RegisterRequest(string email, string password, string name, bool isAdmin, string number)
{
    [EmailAddress]
    public string Email { get; private set; } = email;
    [PasswordPropertyText]
    public string Password { get; private set; } = password;
    public string Name { get; private set; } = name;
    public bool IsAdmin { get; private set; } = isAdmin;
    public string Number { get; private set; } = number;
}