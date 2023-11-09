using HigiaServer.Application.Interfaces;
using HigiaServer.Application.MappingDTO;
using HigiaServer.Application.Services;
using HigiaServer.Infra.Data;

namespace HigiaServer.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlite("DataSource=application.db;Cache=Shared"));

        services.AddAutoMapper(typeof(DomainDTOMapping));

        services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
        services.AddScoped<IAdministratorRepository, AdminsistratorRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        services.AddScoped<ICollaboratorService, CollaboratorService>();
        services.AddScoped<IAdministratorService, AdministratorService>();
        services.AddScoped<ITaskService, TaskService>();

        return services;
    }
}