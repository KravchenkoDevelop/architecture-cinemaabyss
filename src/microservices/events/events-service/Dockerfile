# === Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release
ARG DOTNET_ARCH=amd64

WORKDIR /src
COPY . .

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c ${BUILD_CONFIGURATION} --self-contained true -r linux-x64 -o /app

WORKDIR /src
RUN dotnet new tool-manifest --force
RUN dotnet tool install Swashbuckle.AspNetCore.Cli --version 9.0.3 --local
RUN dotnet tool run swagger tofile --output swagger.json /app/events-service.dll v1

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app
COPY --from=build /app /app
COPY --from=build /root/.dotnet /root/.dotnet

ENV ASPNETCORE_URLS=http://+:8082
EXPOSE 8082

ENTRYPOINT ["dotnet", "events-service.dll"]
