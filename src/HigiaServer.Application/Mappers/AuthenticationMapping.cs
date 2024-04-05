using AutoMapper;

using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Domain.Entities;
namespace HigiaServer.Application.Mappers;

public class AuthenticationMapping : Profile
{
    public AuthenticationMapping()
    {
        CreateMap<AuthenticationResponse, StandardSuccessResponse<AuthenticationResponse>>()
            .ConstructUsing(authResponse => new StandardSuccessResponse<AuthenticationResponse>(
                authResponse
                ));
            
        CreateMap<RegisterRequest, User>()
            .ConstructUsing(request => new User(
                request.IsAdmin, 
                request.Email, 
                request.Name, 
                request.Number, 
                request.Password
            ));

        CreateMap<User, UserResponse>()
            .ConstructUsing(user => new UserResponse(
                user.Email, 
                user.Name, 
                user.Number, 
                user.IsAdmin
            ));
    }
}