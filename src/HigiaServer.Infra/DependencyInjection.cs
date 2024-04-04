using HigiaServer.Application.Mappers;
using HigiaServer.Application.Repositories;
using HigiaServer.Infra.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace HigiaServer.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AuthenticationMapping));
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}