FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Adjusted paths based on your directory structure
COPY ["Core/proDuck.Application/proDuck.Application.csproj", "Core/proDuck.Application/"]
COPY ["Core/proDuck.Domain/proDuck.Domain.csproj", "Core/proDuck.Domain/"]
COPY ["Infrastructure/proDuck.Infrastructure/proDuck.Infrastructure.csproj", "Infrastructure/proDuck.Infrastructure/"]
COPY ["Presistence/proDuck.Presistence/proDuck.Presistence.csproj", "Presistence/proDuck.Presistence/"]
COPY ["Presentation/proDuck.WebApi/proDuck.WebApi.csproj", "Presentation/proDuck.WebApi/"]

RUN dotnet restore "./Presentation/proDuck.WebApi/proDuck.WebApi.csproj"

COPY . .

WORKDIR "/src/Presentation/proDuck.WebApi"
RUN dotnet build "./proDuck.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./proDuck.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "proDuck.WebApi.dll"]
