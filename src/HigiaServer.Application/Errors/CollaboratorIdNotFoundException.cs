using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class CollaboratorIdNotFound(string collaboratorId) : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage =>
        $"The Collaborator with id {collaboratorId} was not found in the system. Please provide a valid Id.";
}
