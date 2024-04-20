using System.Text.Json.Serialization;

namespace HigiaServer.Application.Contracts.Responses;

public class StandardSuccessResponse<T>(T data, Uri? location = null)
{
    public bool Success { get; init; } = true;
    public T Data { get; init; } = data;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? Location { get; set; } = location;
}