using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class InvalidPasswordException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErrorMessage => "Invalid password provided. Please provide a valid password.";
}
