FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Production


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ./ ./


WORKDIR /src/
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Themis.API.dll"]
