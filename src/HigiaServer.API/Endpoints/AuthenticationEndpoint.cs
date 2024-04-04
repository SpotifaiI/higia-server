using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Repositories;

namespace HigiaServer.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder authEndpoint = app.MapGroup("password-manager/api/");

        // register
        authEndpoint.MapPost("register", async (RegisterRequest request, IUserRepository repository) 
            => await HandleRegister(request, repository)
        )
        .WithName("Register")
        // .Produces<StandardSuccessResponse<AuthenticationResult>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Register to the Password Manager API";
            x.Description = "Register to the Password Manager API with your credentials";
            return x;
        });

        // login
        authEndpoint.MapPost("login", async (LoginRequest request, IUserRepository repository) 
            => await HandleLogin(request, repository)
        )
        .WithName("Login")
        // .Produces<StandardSuccessResponse<AuthenticationResult>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Login to the Password Manager API";
            x.Description = "Login to the Password Manager API with your credentials";
            return x;
        });

        return app;
    }

    public static async Task<IResult> HandleRegister(RegisterRequest request, IUserRepository repository)
    {
        return Results.Ok();
    }

    public static async Task<IResult> HandleLogin(LoginRequest request, IUserRepository repository)
    {
        return Results.Ok();
    }
}