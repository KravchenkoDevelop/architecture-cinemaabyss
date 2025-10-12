<<<<<<< HEAD
<<<<<<< HEAD
=======
# === Build stage ===
>>>>>>> b9aa4cc (1.1)
=======
>>>>>>> d01950b ()
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release
ARG DOTNET_ARCH=amd64

WORKDIR /src
COPY . .

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

<<<<<<< HEAD
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
=======
RUN dotnet publish ./Events.API/Events.API.csproj -c Release -o /app/api
RUN dotnet publish ./Events.Producer/Events.Producer.csproj -c Release -o /app/producer
RUN dotnet publish ./Events.Consumer/Events.Consumer.csproj -c Release -o /app/consumer
>>>>>>> d01950b ()

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
<<<<<<< HEAD
>>>>>>> b9aa4cc (1.1)
=======
WORKDIR /app
>>>>>>> d01950b ()

WORKDIR /app
COPY --from=build /app /app
COPY --from=build /root/.dotnet /root/.dotnet

<<<<<<< HEAD
<<<<<<< HEAD
# запускаем сервис
ENTRYPOINT ["dotnet", "Events.API.dll"]
=======
ENV ASPNETCORE_URLS=http://+:8082
EXPOSE 8082

ENTRYPOINT ["dotnet", "events-service.dll"]
>>>>>>> b9aa4cc (1.1)
=======
# запускаем сервис
ENTRYPOINT ["dotnet", "Events.API.dll"]
>>>>>>> d01950b ()
