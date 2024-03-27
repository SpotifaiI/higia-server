using HigiaServer.Application.Contracts;
namespace HigiaServer.Application.Authentication;

public record AuthenticationResult(UserResponse User, string Token);