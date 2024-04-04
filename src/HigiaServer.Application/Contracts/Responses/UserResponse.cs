namespace HigiaServer.Application.Contracts.Responses;

public record UserResponse(
    string Email, 
    string Name, 
    string Number,
    bool IsAdmin
);