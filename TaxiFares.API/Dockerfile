#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TaxiFares.API/TaxiFares.API.csproj", "TaxiFares.API/"]
COPY ["TaxiFares.API.Infrastructure/TaxiFares.API.Infrastructure.csproj", "TaxiFares.API.Infrastructure/"]
COPY ["TaxiFares.API.Domain/TaxiFares.API.Domain.csproj", "TaxiFares.API.Domain/"]
RUN dotnet restore "TaxiFares.API/TaxiFares.API.csproj"
COPY . .
WORKDIR "/src/TaxiFares.API"
RUN dotnet build "TaxiFares.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxiFares.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxiFares.API.dll"]