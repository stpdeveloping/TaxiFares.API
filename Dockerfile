FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY TaxiFares.API.sln ./
COPY TaxiFares.API/TaxiFares.API.csproj ./TaxiFares.API/
COPY TaxiFares.API.Domain/TaxiFares.API.Domain.csproj ./TaxiFares.API.Domain/
COPY TaxiFares.API.Infrastructure/TaxiFares.API.Infrastructure.csproj ./TaxiFares.API.Infrastructure/

RUN dotnet restore
COPY . .
WORKDIR /src/TaxiFares.API
RUN dotnet build -c Release -o /app

WORKDIR /src/TaxiFares.API.Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/TaxiFares.API.Infrastructure
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaxiFares.API.dll"]