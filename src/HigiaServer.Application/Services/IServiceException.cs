using System.Net;

namespace HigiaServer.Application.Services;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}
