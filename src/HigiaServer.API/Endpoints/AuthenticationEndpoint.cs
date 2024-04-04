using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Entities;
using HigiaServer.Application.Errors;
using AutoMapper;
using HigiaServer.Application.Contracts.Responses;

namespace HigiaServer.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder authEndpoint = app.MapGroup("password-manager/api/");

        // register
        authEndpoint.MapPost("register", async (RegisterRequest request, IUserRepository repository, IMapper mapper) 
            => await HandleRegister(request, repository, mapper)
        )
        .WithName("Register")
        .Produces<StandardSuccessResponse<AuthenticationResponse>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Register to the Password Manager API";
            x.Description = "Register to the Password Manager API with your credentials";
            return x;
        });

        // login
        authEndpoint.MapPost("login", async (LoginRequest request, IUserRepository repository, IMapper mapper) 
            => await HandleLogin(request, repository, mapper)
        )
        .WithName("Login")
        .Produces<StandardSuccessResponse<AuthenticationResponse>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Login to the Password Manager API";
            x.Description = "Login to the Password Manager API with your credentials";
            return x;
        });

        return app;
    }

    public static async Task<IResult> HandleRegister(RegisterRequest request, IUserRepository repository, IMapper mapper)
    {
        if (repository.GetUserByEmail(request.Email) != null)
        {
            throw new DuplicateEmailException();
        }
        
        var user = mapper.Map<User>(request);
        var authResponse = mapper.Map<AuthenticationResponse>(user);

        repository.AddUser(user);
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }

    public static async Task<IResult> HandleLogin(LoginRequest request, IUserRepository repository, IMapper mapper)
    {
        if (repository.GetUserByEmail(request.Email) is not User user)
        {
            throw new EmailGivenNotFoundException();
        }

        var authResponse = mapper.Map<AuthenticationResponse>(user);
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }
}