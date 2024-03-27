using HigiaServer.Application.Authentication;
namespace HigiaServer.Application.Contracts;

public class StandardSuccessResponse<T>(T data) where T : AuthenticationResult
{
    public bool Success { get; init; } = true;
    public T Data { get; init; } = data;
}