using HigiaServer.Application.Mappers;
using HigiaServer.Application.Repositories;
using HigiaServer.Application.Services;
using HigiaServer.Infra.Configurations;
using HigiaServer.Infra.DbContext;
using HigiaServer.Infra.Repositories;
using HigiaServer.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HigiaServer.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddAutoMapper(typeof(TaskMapping));
        services.AddAutoMapper(typeof(AuthenticationMapping));

        services.AddDbContext<HigiaServerContext>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
