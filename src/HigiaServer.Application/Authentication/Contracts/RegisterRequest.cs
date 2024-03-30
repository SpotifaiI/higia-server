namespace HigiaServer.Application.Authentication.Contracts;

public record RegisterRequest(string Email, string Name, string Password);