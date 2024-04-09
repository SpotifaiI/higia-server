using System.Net;

namespace HigiaServer.Application.Errors;
public class UnauthenticatedUserException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string ErrorMessage => "Access Denied. Authentication required for access.";
}