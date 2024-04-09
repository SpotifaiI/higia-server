using HigiaServer.Domain.Entities;

namespace HigiaServer.Application.Services;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}