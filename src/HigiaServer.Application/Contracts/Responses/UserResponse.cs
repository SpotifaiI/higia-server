namespace HigiaServer.Application.Contracts.Responses;

public record UserResponse(
    string Email, 
    string Name, 
    bool IsAdmin
);