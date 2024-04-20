using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class NonGuidTypeException(string taskId) : Exception, IServiceException
{
    public string ErrorMessage =>
        $"The provided id {taskId} does not match the expected type. Please ensure that the id is in the correct format and try again.";

    public HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
}
