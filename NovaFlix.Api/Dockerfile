FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Configure Kestrel to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution projects
COPY ["NovaFlix.Api/NovaFlix.Api.csproj", "NovaFlix.Api/"]
COPY ["NovaFlix.Application/NovaFlix.Application.csproj", "NovaFlix.Application/"]
COPY ["NovaFlix.Domain/NovaFlix.Domain.csproj", "NovaFlix.Domain/"]
COPY ["NovaFlix.Infrastructure/NovaFlix.Infrastructure.csproj", "NovaFlix.Infrastructure/"]

RUN dotnet restore "NovaFlix.Api/NovaFlix.Api.csproj"

# Copy the rest of the source
COPY . .

WORKDIR "/src/NovaFlix.Api"
RUN dotnet publish "NovaFlix.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "NovaFlix.Api.dll"]

