using HigiaServer.Application.Contracts;
namespace HigiaServer.Application.Authentication.Contracts;

public record AuthenticationResult(UserResponse User, string Token);