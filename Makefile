build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project ./src/HigiaServer.API/HigiaServer.API.csproj
run:
	dotnet run --project ./src/HigiaServer.API/HigiaServer.API.csproj
test:
	dotnet test