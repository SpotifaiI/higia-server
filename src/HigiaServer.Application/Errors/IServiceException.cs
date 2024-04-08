using System.Net;

namespace HigiaServer.Application.Errors;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}