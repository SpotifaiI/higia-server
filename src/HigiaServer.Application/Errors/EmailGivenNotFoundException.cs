using System.Net;
namespace HigiaServer.Application.Errors;

public class EmailGivenNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "The email given was not found in the system. Please provide a valid email.";
}