using AutoMapper;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Application.Errors;
using HigiaServer.Application.Repositories;
using HigiaServer.Application.Services;
using HigiaServer.Domain.Entities;
using Microsoft.AspNetCore.Authentication;

namespace HigiaServer.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        var authEndpoint = app.MapGroup("higia-server/api/auth").WithTags("Authentication");

        // register
        authEndpoint
            .MapPost("register", HandleRegister)
            .WithName("Register")
            .Produces<StandardSuccessResponse<AuthenticationResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Register";
                x.Description = "Register to the Higia Server with your credentials";
                return x;
            });

        // login
        authEndpoint
            .MapPost("login", HandleLogin)
            .WithName("Login")
            .Produces<StandardSuccessResponse<AuthenticationResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Login";
                x.Description = "Login to the Higia Server with your credentials";
                return x;
            });

        return app;
    }

    private static async Task<IResult> HandleRegister(
        RegisterRequest request,
        IUserRepository repository,
        IMapper mapper,
        IJwtTokenService jwtTokenService
    )
    {
        if (await repository.GetUserByEmail(request.Email) != null)
            throw new DuplicateEmailException(request.Email);

        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = mapper.Map<User>(request);
        jwtTokenService.GenerateToken(user);

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user),
            jwtTokenService.GenerateToken(user)
        );

        repository.AddUser(user);
        return Results.Ok(new StandardSuccessResponse<AuthenticationResponse>(authResponse));
    }

    private static async Task<IResult> HandleLogin(
        LoginRequest request,
        IUserRepository repository,
        IMapper mapper,
        IJwtTokenService jwtTokenService
    )
    {
        if (await repository.GetUserByEmail(request.Email) is not { } user)
            throw new EmailGivenNotFoundException(request.Email);
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            throw new InvalidPasswordException();

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user),
            jwtTokenService.GenerateToken(user)
        );

        return Results.Ok(new StandardSuccessResponse<AuthenticationResponse>(authResponse));
    }
}
