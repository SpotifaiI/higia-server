using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using HigiaServer.Application.Extension;
using HigiaServer.Domain.Common;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HigiaServer.Application.Services;

public class AuthenticationService
{
    private readonly IConfiguration _configuration;

    public AuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken<T>(T user) where T : BaseUserEntity
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        string? keyconfig = _configuration.GetValue<string>("Jwt:Key");
        byte[] key = Encoding.ASCII.GetBytes(keyconfig!);
        IEnumerable<Claim> claims = user.GetClaims();
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}