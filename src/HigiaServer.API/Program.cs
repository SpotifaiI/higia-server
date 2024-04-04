using HigiaServer.Infra;
using HigiaServer.API.Extensions;
using HigiaServer.API.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCustomSwagger()
    .AddEndpointsApiExplorer()
    .AddInfra();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.AddAuthenticationEndpoint();
app.AddCustomErrors();
app.AddCustomSwagger();

app.Run();