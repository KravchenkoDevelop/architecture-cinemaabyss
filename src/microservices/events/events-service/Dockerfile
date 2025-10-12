FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release
ARG DOTNET_ARCH=amd64

WORKDIR /src
COPY . .

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

RUN dotnet publish ./Events.API/Events.API.csproj -c Release -o /app/api
RUN dotnet publish ./Events.Producer/Events.Producer.csproj -c Release -o /app/producer
RUN dotnet publish ./Events.Consumer/Events.Consumer.csproj -c Release -o /app/consumer

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

WORKDIR /app
COPY --from=build /app /app
COPY --from=build /root/.dotnet /root/.dotnet

# запускаем сервис
ENTRYPOINT ["dotnet", "Events.API.dll"]
