using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HigiaServer.Application.Contracts.Requests;

public record LoginRequest(
    [EmailAddress] string Email, 
    [PasswordPropertyText] string Password
);