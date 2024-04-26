namespace HigiaServer.Application.Contracts.Responses;

public class BaseSuccessResponse(string message, bool success = true)
{
    public bool Success { get; private set; } = success;
    public string Message { get; private set; } = message;
}