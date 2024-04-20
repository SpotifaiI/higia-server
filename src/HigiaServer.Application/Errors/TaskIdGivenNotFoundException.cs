using System.Net;
using HigiaServer.Application.Services;

namespace HigiaServer.Application.Errors;

public class TaskIdGivenNotFoundException(string taskId) : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage =>
        $"The task id {taskId} given was not found in the system. Please provide a valid task id.";
}
