#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Merzigo.ContentService/Merzigo.ContentService.Api/Merzigo.ContentService.Api.csproj", "src/Merzigo.ContentService/Merzigo.ContentService.Api/"]
COPY ["src/Merzigo.ContentService/Merzigo.ContentService.Application/Merzigo.ContentService.Application.csproj", "src/Merzigo.ContentService/Merzigo.ContentService.Application/"]
COPY ["src/Merzigo.ContentService/Merzigo.ContentService.Domain/Merzigo.ContentService.Domain.csproj", "src/Merzigo.ContentService/Merzigo.ContentService.Domain/"]
COPY ["src/Merzigo.ContentService/Merzigo.ContentService.Infrastructure/Merzigo.ContentService.Infrastructure.csproj", "src/Merzigo.ContentService/Merzigo.ContentService.Infrastructure/"]
RUN dotnet restore "./src/Merzigo.ContentService/Merzigo.ContentService.Api/Merzigo.ContentService.Api.csproj"
COPY . .
WORKDIR "/src/src/Merzigo.ContentService/Merzigo.ContentService.Api"
RUN dotnet build "./Merzigo.ContentService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Merzigo.ContentService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Merzigo.ContentService.Api.dll"]