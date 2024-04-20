namespace HigiaServer.Application.Contracts.Responses;

public record AuthenticationResponse(UserResponse User, string Token);