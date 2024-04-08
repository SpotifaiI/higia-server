using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HigiaServer.Application.Contracts.Requests;

public class LoginRequest(string email, string password)
{
    [EmailAddress] public string Email { get; private set; } = email;

    [PasswordPropertyText] public string Password { get; private set; } = password;
}