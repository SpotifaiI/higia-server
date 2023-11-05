using HigiaServer.Application.MappingDTO;

namespace HigiaServer.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainDTOMapping));
        services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
        services.AddScoped<IAdministratorRepository, AdminsistratorRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}