using AutoMapper;

using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;

namespace HigiaServer.API.Endpoints;

public static class UserEndpoint
{
    public static  IEndpointRouteBuilder AddUserEndpoint(this IEndpointRouteBuilder app)
    {
        var userEndpoint = app.MapGroup("higia-server/api/user").WithTags("User");

        // update info user
        userEndpoint.MapPut("/{userId:guid}", HandleUpdaterInfoUser)
            .WithName("Update user information")
            .WithOpenApi(x =>
            {
                x.Summary = "Update user information";
                return x;
            });
        
        return app;
    }

    #region 
    
    public static async Task<IResult> HandleUpdaterInfoUser(
        Guid userId,
        UpdateInfoUserRequest request,
        HttpContext context,
        IUserRepository userRepository,
        IMapper mapper
    )
    {
        if (!context.User!.Identity!.IsAuthenticated) throw new UnauthenticatedException();
        if (await userRepository.GetUserById(userId) is not { } user)
        {
            return Results.BadRequest(new BaseResponse($"User with id {userId} was not found!", false));
        }
        
        // update user information
        user.UpdateInfoUser(
            name: request.Name,
            email: request.Email,
            number: request.Number
        );

        await userRepository.UpdateUser(user);
        return Results.Ok(new BaseResponse("user information updated successfully", false));
    }

    #endregion
}