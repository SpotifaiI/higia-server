namespace HigiaServer.Application.Contracts.Requests;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public record RegisterRequest(
    [EmailAddress] string Email, 
    [PasswordPropertyText] string Password,
    string Name, 
    string Number,
    bool IsAdmin
);