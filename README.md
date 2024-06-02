# Higia Server

🌎 Server do app que ajuda o meio ambiente enquanto registra sua produtividade. 

# Integrantes

- [x] Cristian Prochnow
- [x] Gustavo Henrique Dias
- [x] Lucas Willian de Souza Serpa
- [x] Marlon de Souza
- [x] Ryan Gabriel Mazzei Bromati

# Rodando o projeto

Para rodar o projeto, o primeiro passo é [instalar o Docker][docker-desktop] na sua máquina. Após isso, abra o projeto e na raiz rode os comandos de _build_ do Docker.

```shell
$ docker build --tag higia-server:latest -f /caminho/ate/projeto/Dockerfile .
$ docker run -it -d -p "8080:8080" -v "/caminho/ate/raiz/project:/app" higia-server:latest bash
```

# Estrutura de Arquivos

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

[docker-desktop]: https://docs.docker.com/desktop/install/windows-install/
