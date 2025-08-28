<<<<<<< HEAD
=======
# === Build stage ===
>>>>>>> b9aa4cc (1.1)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY . .

# Восстановление NuGet-пакетов с кэшированием
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

<<<<<<< HEAD
<<<<<<< HEAD
RUN dotnet publish . --ignore-failed-sources --disable-parallel -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
=======
=======
# Публикация self-contained для linux-x64
>>>>>>> 53b6f72 (it builds)
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c ${BUILD_CONFIGURATION} --self-contained true -r linux-x64 -o /app

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
>>>>>>> b9aa4cc (1.1)

WORKDIR /app
COPY --from=build /app /app

<<<<<<< HEAD
# запускаем сервис
ENTRYPOINT ["dotnet", "Events.API.dll"]
=======
ENV ASPNETCORE_URLS=http://+:8082
EXPOSE 8082

ENTRYPOINT ["dotnet", "events-service.dll"]
>>>>>>> b9aa4cc (1.1)
