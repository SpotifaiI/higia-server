using Microsoft.OpenApi.Models;

namespace HigiaServer.API.Extensions;

public static class CustomSwaggerExtension
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Higia Server",
            Version = "v2"
        })
        );

        return services;
    }

    public static WebApplication AddCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Higia Server"));
        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        return app;
    }
}