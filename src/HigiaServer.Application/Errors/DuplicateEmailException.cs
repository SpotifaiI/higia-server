using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class DuplicateEmailException(string email) : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => $"The email {email} is already in use. Please provide a different email.";
}