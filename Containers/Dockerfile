FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Srcs/PocketWarz.Web/PocketWarz.Web.csproj", "Srcs/PocketWarz.Web/"]
RUN dotnet restore "Srcs/PocketWarz.Web/PocketWarz.Web.csproj"
COPY . .
WORKDIR "/src/Srcs/PocketWarz.Web"
RUN dotnet build "./PocketWarz.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PocketWarz.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
ARG APP_UID=1000
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PocketWarz.Web.dll"]