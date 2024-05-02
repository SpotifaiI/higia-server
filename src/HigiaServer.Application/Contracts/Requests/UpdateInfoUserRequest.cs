using System.ComponentModel.DataAnnotations;

namespace HigiaServer.Application.Contracts.Requests;

public class UpdateInfoUserRequest(string? name, string? email, string? number)
{
    public string? Name { get; private set; } = name;
    [EmailAddress] public string? Email { get; private set; } = email;
    public string? Number { get; private set; } = number;
}
