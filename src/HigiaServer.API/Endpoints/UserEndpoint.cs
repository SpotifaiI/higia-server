using System.Security.Claims;

using AutoMapper;

using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;

namespace HigiaServer.API.Endpoints;

public static class UserEndpoint
{
    public static  IEndpointRouteBuilder AddUserEndpoint(this IEndpointRouteBuilder app)
    {
        var userEndpoint = app.MapGroup("higia-server/api/user").WithTags("User");

        // update info user
        userEndpoint.MapPut("", HandleUpdaterInfoUser);
        
        return app;
    }

    #region 
    
    public static async Task<IResult> HandleUpdaterInfoUser(
        HttpContext context,
        IUserRepository repository,
        IMapper mapper
    )
    {
        CheckAuthorizationAsAdministrator(context);
        return Results.Ok();
    }

        private static void CheckAuthorizationAsAdministrator(HttpContext context)
    {
        if (!context.User!.Identity!.IsAuthenticated)
        {
            throw new UnauthenticatedException();
        }

        if (context.User.FindFirstValue(ClaimTypes.Role) != "admin")
        {
            throw new UnauthorizedAccessException();
        }
    }

    #endregion
}