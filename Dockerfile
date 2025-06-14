# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CopilotWs/CarRentalWebApp/CarRentalWebApp.csproj", "./"]
RUN dotnet restore "CarRentalWebApp.csproj"
COPY CopilotWs/CarRentalWebApp/ .
RUN dotnet publish "CarRentalWebApp.csproj" -c Release -o /app/publish

# Use the official ASP.NET runtime image for the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "CarRentalWebApp.dll"]
