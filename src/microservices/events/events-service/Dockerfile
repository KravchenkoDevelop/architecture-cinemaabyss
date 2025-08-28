# === Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY . .

# Восстановление NuGet-пакетов с кэшированием
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

# Публикация self-contained для linux-x64
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c ${BUILD_CONFIGURATION} --self-contained true -r linux-x64 -o /app

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app
COPY --from=build /app /app

ENV ASPNETCORE_URLS=http://+:8082
EXPOSE 8082

ENTRYPOINT ["dotnet", "events-service.dll"]
