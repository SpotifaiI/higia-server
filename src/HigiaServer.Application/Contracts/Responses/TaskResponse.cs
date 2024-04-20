using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Domain.Enums;

namespace HigiaServer.Application.Contracts.Responses;

public record TaskResponse(
    Guid Id,
    string Title,
    UrgencyLevel UrgencyLevel,
    Status Status,
    Coordinates Coordinates,
    List<Guid> Collaborators,
    string? Description
);
