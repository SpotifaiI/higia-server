namespace HigiaServer.Application.Contracts.Responses;

public class StandardSuccessResponse<T>(T data)
{
    public bool Success { get; init; } = true;
    public T Data { get; init; } = data;
}