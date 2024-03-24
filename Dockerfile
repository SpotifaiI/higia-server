FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-stage

WORKDIR /src
COPY . .
RUN dotnet restore --disable-parallel
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build-stage /app ./

EXPOSE 8080
ENTRYPOINT [ "dotnet", "HigiaServer.API.dll" ]