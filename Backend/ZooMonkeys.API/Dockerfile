FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src

# Install dependencies required for Native AOT
RUN apk add --no-cache clang build-base zlib-dev

# Copy sln and csproj files for restore
COPY ["Backend/ZooMonkeys.API/ZooMonkeys.API.csproj", "Backend/ZooMonkeys.API/"]
COPY ["Backend/ZooMonkeys.Domain/ZooMonkeys.Domain.csproj", "Backend/ZooMonkeys.Domain/"]
COPY ["Backend/ZooMonkeys.slnx", "Backend/"]

RUN dotnet restore "Backend/ZooMonkeys.API/ZooMonkeys.API.csproj"

# Copy everything else
COPY Backend/ Backend/

WORKDIR "/src/Backend/ZooMonkeys.API"
RUN dotnet publish "ZooMonkeys.API.csproj" -c Release -r linux-musl-arm64 --self-contained true -p:PublishAot=true -p:OptimizationPreference=Size -o /app/publish

# Use the chiseled runtime for Native AOT (Alpine/Musl based)
FROM mcr.microsoft.com/dotnet/nightly/runtime-deps:10.0-alpine-chiseled-aot
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["./ZooMonkeys.API"]
