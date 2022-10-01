#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["host/InstaRent.Login.HttpApi.Host/InstaRent.Login.HttpApi.Host.csproj", "host/InstaRent.Login.HttpApi.Host/"]
COPY ["src/InstaRent.Login.HttpApi/InstaRent.Login.HttpApi.csproj", "src/InstaRent.Login.HttpApi/"]
COPY ["src/InstaRent.Login.Application.Contracts/InstaRent.Login.Application.Contracts.csproj", "src/InstaRent.Login.Application.Contracts/"]
COPY ["src/InstaRent.Login.Domain.Shared/InstaRent.Login.Domain.Shared.csproj", "src/InstaRent.Login.Domain.Shared/"]
COPY ["src/InstaRent.Login.Application/InstaRent.Login.Application.csproj", "src/InstaRent.Login.Application/"]
COPY ["src/InstaRent.Login.Domain/InstaRent.Login.Domain.csproj", "src/InstaRent.Login.Domain/"]
COPY ["src/InstaRent.Login.EntityFrameworkCore/InstaRent.Login.EntityFrameworkCore.csproj", "src/InstaRent.Login.EntityFrameworkCore/"]
COPY ["host/InstaRent.Login.Host.Shared/InstaRent.Login.Host.Shared.csproj", "host/InstaRent.Login.Host.Shared/"]
RUN dotnet restore "host/InstaRent.Login.HttpApi.Host/InstaRent.Login.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/host/InstaRent.Login.HttpApi.Host"
RUN dotnet build "InstaRent.Login.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstaRent.Login.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaRent.Login.HttpApi.Host.dll"]