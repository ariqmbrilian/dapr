FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5004

ENV ASPNETCORE_URLS=http://+:5004

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet build "BasicWorkflowSamples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicWorkflowSamples.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "BasicWorkflowSamples.dll" ]

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
# WORKDIR /App

# # Copy everything
# COPY . ./
# # Restore as distinct layers
# # RUN dotnet restore
# # Build and publish a release
# RUN dotnet build "BasicWorkflowSamples.csproj" -c Release -o /App/build

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0
# WORKDIR /App
# COPY --from=build-env /App/out .
# ENTRYPOINT ["dotnet", "BasicWorkflowSamples.dll"]