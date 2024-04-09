using HigiaServer.Application.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HigiaServer.API.Extensions;

public static class CustomErrorsExtension
{
    public static WebApplication AddCustomErrors(this WebApplication app)
    {
        const string endPoint = "/higia-server/api/errors";
        app.UseExceptionHandler(endPoint);

        app.Map(endPoint, (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            (var statusCode, var title) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
            };

            return Results.Problem(new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Detail = exception?.Message
            });
        });

        return app;
    }
}