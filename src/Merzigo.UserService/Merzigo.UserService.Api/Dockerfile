#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Merzigo.UserService/Merzigo.UserService.Api/Merzigo.UserService.Api.csproj", "src/Merzigo.UserService/Merzigo.UserService.Api/"]
COPY ["src/Merzigo.UserService/Merzigo.UserService.Application/Merzigo.UserService.Application.csproj", "src/Merzigo.UserService/Merzigo.UserService.Application/"]
COPY ["src/Merzigo.UserService/Merzigo.UserService.Domain/Merzigo.UserService.Domain.csproj", "src/Merzigo.UserService/Merzigo.UserService.Domain/"]
COPY ["src/Merzigo.UserService/Merzigo.UserService.Infrastructure/Merzigo.UserService.Infrastructure.csproj", "src/Merzigo.UserService/Merzigo.UserService.Infrastructure/"]
RUN dotnet restore "./src/Merzigo.UserService/Merzigo.UserService.Api/Merzigo.UserService.Api.csproj"
COPY . .
WORKDIR "/src/src/Merzigo.UserService/Merzigo.UserService.Api"
RUN dotnet build "./Merzigo.UserService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Merzigo.UserService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Merzigo.UserService.Api.dll"]