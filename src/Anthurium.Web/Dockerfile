FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Anthurium.Web/Anthurium.Web.csproj", "src/Anthurium.Web/"]
COPY ["src/Anthurium.API/Anthurium.API.csproj", "src/Anthurium.API/"]
COPY ["src/Anthurium.Shared/Anthurium.Shared.csproj", "src/Anthurium.Shared/"]
RUN dotnet restore "src/Anthurium.Web/Anthurium.Web.csproj"
COPY . .
WORKDIR "/src/src/Anthurium.Web"
RUN dotnet build "Anthurium.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Anthurium.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Anthurium.Web.dll"]