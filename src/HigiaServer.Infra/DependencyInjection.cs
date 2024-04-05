using HigiaServer.Application.Mappers;
using HigiaServer.Application.Repositories;
using HigiaServer.Application.Services;

using HigiaServer.Infra.Repositories;
using HigiaServer.Infra.Utils;
using HigiaServer.Infra.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace HigiaServer.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddAutoMapper(typeof(AuthenticationMapping));

        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}