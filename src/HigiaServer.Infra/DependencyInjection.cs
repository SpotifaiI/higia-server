using HigiaServer.Application.Interfaces;
using HigiaServer.Application.MappingDTO;
using HigiaServer.Application.Services;
using HigiaServer.Infra.Data;

using Microsoft.Extensions.Configuration;

namespace HigiaServer.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            string? stringConnection = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(stringConnection);
        });

        services.AddAutoMapper(typeof(DomainDTOMapping));

        services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
        services.AddScoped<IAdministratorRepository, AdministratorRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        services.AddScoped<ICollaboratorService, CollaboratorService>();
        services.AddScoped<IAdministratorService, AdministratorService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddTransient<AuthenticationService>();
        services.AddAuthorization();

        return services;
    }
}