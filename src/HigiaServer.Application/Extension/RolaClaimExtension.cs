using System.Security.Claims;

using HigiaServer.Domain.Common;

namespace HigiaServer.Application.Extension;

public static class RolaClaimExtension
{
    public static IEnumerable<Claim> GetClaims<T>(this T user) where T : BaseUserEntity
    {
        string role = user is Administrator ? "Administrator" : user is Collaborator ? "Collaborator" : "Unknown";

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, role)
        };

        return claims;
    }
}