FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app

#HTTP
EXPOSE 5189

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ControlePedidos.API/ControlePedidos.API.csproj", "src/ControlePedidos.API/"]
COPY ["src/Modules/Produto/CadastroPedidos.Produto.Application/CadastroPedidos.Produto.Application.csproj", "src/Modules/Produto/CadastroPedidos.Produto.Application/"]
COPY ["src/Modules/Produto/ControlePedidos.Produto.Domain/ControlePedidos.Produto.Domain.csproj", "src/Modules/Produto/ControlePedidos.Produto.Domain/"]
COPY ["src/Modules/Produto/ControlePedidos.Produto.Infrastructure/ControlePedidos.Produto.Infrastructure.csproj", "src/Modules/Produto/ControlePedidos.Produto.Infrastructure/"]
RUN dotnet restore "./src/ControlePedidos.API/ControlePedidos.API.csproj"
COPY . .
WORKDIR "/src/src/ControlePedidos.API"
RUN dotnet build "./ControlePedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ControlePedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5189

ENTRYPOINT ["dotnet", "ControlePedidos.API.dll"]