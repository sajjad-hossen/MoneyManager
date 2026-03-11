# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MoneyManager.csproj", "./"]
RUN dotnet restore "MoneyManager.csproj"
COPY . .
RUN dotnet build "MoneyManager.csproj" -c Release -o /app/build
RUN dotnet publish "MoneyManager.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose standard port for Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

ENTRYPOINT ["dotnet", "MoneyManager.dll"]
