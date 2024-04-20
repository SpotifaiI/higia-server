using System.Text;
using HigiaServer.API.Endpoints;
using HigiaServer.API.Extensions;
using HigiaServer.Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomSwagger();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfra(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("collaborator", policy => policy.RequireRole("collaborator"));
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SecretKey")!);
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

app.UseHttpsRedirection();
app.AddAuthenticationEndpoint();
app.AddTaskEndpoint();
app.UseAuthentication();
app.UseAuthorization();
app.AddCustomErrors();
app.AddCustomSwagger();

app.Run();