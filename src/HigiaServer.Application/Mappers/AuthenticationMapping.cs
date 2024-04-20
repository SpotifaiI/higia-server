using AutoMapper;
using HigiaServer.Application.Contracts.Requests;
using HigiaServer.Application.Contracts.Responses;
using HigiaServer.Domain.Entities;

namespace HigiaServer.Application.Mappers;

public class AuthenticationMapping : Profile
{
    public AuthenticationMapping()
    {
        CreateMap<RegisterRequest, User>()
            .ConstructUsing(request => new User(
                request.IsAdmin,
                request.Name,
                request.Email,
                request.Password,
                null
            ));

        CreateMap<User, UserResponse>()
            .ConstructUsing(user => new UserResponse(
                user.Id, 
                user.Email, 
                user.Name,
                user.IsAdmin
            ));
    }
}
