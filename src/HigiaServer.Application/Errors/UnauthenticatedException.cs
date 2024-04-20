using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class UnauthenticatedException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NetworkAuthenticationRequired;
    public string ErrorMessage => "Access Denied. Authentication required for access.";
}
