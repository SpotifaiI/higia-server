namespace HigiaServer.Application.Contracts.Responses;

public class BaseSuccessResponse(string message)
{
    public bool Success { get; private set; } = true;
    public string Message { get; private set; } = message;
}