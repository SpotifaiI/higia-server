using AutoMapper;

using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Entities;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Application.Services;

namespace HigiaServer.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder authEndpoint = app.MapGroup("higia-server/api/");

        // register
        authEndpoint.MapPost("register", async (RegisterRequest request, IUserRepository repository, IMapper mapper, IJwtTokenService jwtTokenService)
            => await HandleRegister(request, repository, mapper, jwtTokenService)
        )
        .WithName("Register")
        .Produces<StandardSuccessResponse<AuthenticationResponse>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Register to the Higia Server";
            x.Description = "Register to the Higia Server with your credentials";
            return x;
        });

        // login
        authEndpoint.MapPost("login", async (LoginRequest request, IUserRepository repository, IMapper mapper, IJwtTokenService jwtTokenService) 
            => await HandleLogin(request, repository, mapper, jwtTokenService)
        )
        .WithName("Login")
        .Produces<StandardSuccessResponse<AuthenticationResponse>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Login to the Higia Server";
            x.Description = "Login to the Higia Server with your credentials";
            return x;
        });

        return app;
    }

    public static async Task<IResult> HandleRegister(RegisterRequest request, IUserRepository repository, IMapper mapper, IJwtTokenService jwtTokenService)
    {
        if (repository.GetUserByEmail(request.Email) != null)
        {
            throw new DuplicateEmailException();
        }
        
        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = mapper.Map<User>(request);
        jwtTokenService.GenerateToken(user);
        
        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user), 
            jwtTokenService.GenerateToken(user)
        );

        repository.AddUser(user);
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }

    public static async Task<IResult> HandleLogin(LoginRequest request, IUserRepository repository, IMapper mapper, IJwtTokenService jwtTokenService)
    {
        if (repository.GetUserByEmail(request.Email) is not User user)
        {
            throw new EmailGivenNotFoundException();
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new InvalidPasswordException();
        }

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user), 
            jwtTokenService.GenerateToken(user)
        );
        
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }
}