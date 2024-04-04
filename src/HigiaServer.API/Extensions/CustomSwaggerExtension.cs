using Microsoft.OpenApi.Models;
namespace HigiaServer.API.Extensions;

public static class CustomSwaggerExtension
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Password Manager v2",
                Description = "Easily protect sensitive passwords with this API",
                Version = "v2"
            })
        );

        return services;
    }

    public static WebApplication AddCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Manager API"));
        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        return app;
    }
}