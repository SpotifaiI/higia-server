build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
run:
	dotnet run --project ./src/HigiaServer.API
watch:
	dotnet watch --project ./src/HigiaServer.API