FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestWebAppNet10.API/TestWebAppNet10.API.csproj", "TestWebAppNet10.API/"]
RUN dotnet restore "TestWebAppNet10.API/TestWebAppNet10.API.csproj"
COPY . .
WORKDIR "/src/TestWebAppNet10.API"
RUN dotnet build "./TestWebAppNet10.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestWebAppNet10.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebAppNet10.API.dll"]
