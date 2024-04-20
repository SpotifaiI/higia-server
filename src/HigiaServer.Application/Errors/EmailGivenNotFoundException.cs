using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class EmailGivenNotFoundException(string email) : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NoContent;
    public string ErrorMessage =>
        $"The email {email} was not found in the system. Please provide a valid email.";
}
