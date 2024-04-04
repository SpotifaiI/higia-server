using System.Net;
namespace HigiaServer.Application.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "The email given is already in use. Please provide a different email.";
}