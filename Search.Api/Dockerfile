FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Search.Api/Search.Api.csproj", "Search.Api/"]
RUN dotnet restore "Search.Api/Search.Api.csproj"
COPY . .
WORKDIR "/src/Search.Api"
RUN dotnet build "Search.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Search.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Search.Api.dll"]