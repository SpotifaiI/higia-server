using System.ComponentModel.DataAnnotations;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Domain.Enums;

namespace HigiaServer.Application.Contracts.Responses;

public record TaskResponseWithLocation([Url] Uri Location, Guid Id ,string Title, UrgencyLevel UrgencyLevel, Coordinates Coordinates, 
    List<Guid> Collaborators, string? Description);