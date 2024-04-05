# Higia Server

```
├── Dockerfile
├── docs
│   ├── Requests
│   │   ├── Authentication.http
│   │   ├── Task.http
│   │   └── User.http
│   └── Responses
│       └── Authentication.md
├── fly.toml
├── HigiaServer.sln
├── Makefile
├── README.md
└── src
    ├── HigiaServer.API
    │   ├── appsettings.Development.json
    │   ├── appsettings.json
    │   ├── Endpoints
    │   │   └── AuthenticationEndpoint.cs
    │   ├── Extensions
    │   │   ├── CustomErrorsExtension.cs
    │   │   └── CustomSwaggerExtension.cs
    │   ├── HigiaServer.API.csproj
    │   ├── Program.cs
    │   └── Properties
    │       └── launchSettings.json
    ├── HigiaServer.Application
    │   ├── Contracts
    │   │   ├── Requests
    │   │   │   ├── LoginRequest.cs
    │   │   │   └── RegisterRequest.cs
    │   │   └── Responses
    │   │       ├── AuthenticationResponse.cs
    │   │       ├── StandardSuccessResponse.cs
    │   │       └── UserResponse.cs
    │   ├── Errors
    │   │   ├── DuplicateEmailException.cs
    │   │   ├── EmailGivenNotFoundException.cs
    │   │   ├── InvalidPasswordException.cs
    │   │   └── IServiceException.cs
    │   ├── HigiaServer.Application.csproj
    │   ├── Mappers
    │   │   └── AuthenticationMapping.cs
    │   ├── Repositories
    │   │   └── IUserRepository.cs
    │   └── Services
    │       └── IJwtTokenService.cs
    ├── HigiaServer.Domain
    │   ├── Entities
    │   │   ├── Tasks.cs
    │   │   └── User.cs
    │   ├── Enums
    │   │   ├── Status.cs
    │   │   └── UrgencyLevel.cs
    │   └── HigiaServer.Domain.csproj
    └── HigiaServer.Infra
        ├── DependencyInjection.cs
        ├── HigiaServer.Infra.csproj
        ├── Repositories
        │   └── UserRepository.cs
        ├── Services
        │   └── JwtTokenService.cs
        └── Utils
            └── JwtSettings.cs
```