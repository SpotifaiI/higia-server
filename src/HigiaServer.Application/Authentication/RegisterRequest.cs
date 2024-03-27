namespace HigiaServer.Application.Authentication;

public record RegisterRequest(string Email, string Name, string Password);