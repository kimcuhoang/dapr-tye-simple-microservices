FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine3.11 AS base
WORKDIR /app
# https://github.com/dotnet/efcore/issues/18025
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

#######################################
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11 AS build

COPY ./services.json .

WORKDIR /src

COPY ["src/BuildingBlocks/SimpleStore.Domain/SimpleStore.Domain.csproj", "BuildingBlocks/SimpleStore.Domain/SimpleStore.Domain.csproj"]
COPY ["src/BuildingBlocks/SimpleStore.Infrastructure.Common/SimpleStore.Infrastructure.Common.csproj", "BuildingBlocks/SimpleStore.Infrastructure.Common/SimpleStore.Infrastructure.Common.csproj"]
COPY ["src/BuildingBlocks/SimpleStore.Infrastructure.EfCore/SimpleStore.Infrastructure.EfCore.csproj", "BuildingBlocks/SimpleStore.Infrastructure.EfCore/SimpleStore.Infrastructure.EfCore.csproj"]

COPY ["src/Services/Inventories/SimpleStore.Inventories.Domain/SimpleStore.Inventories.Domain.csproj", "Services/Inventories/SimpleStore.Inventories.Domain/SimpleStore.Inventories.Domain.csproj"]
COPY ["src/Services/Inventories/SimpleStore.Inventories.Infrastructure.EfCore/SimpleStore.Inventories.Infrastructure.EfCore.csproj", "Services/Inventories/SimpleStore.Inventories.Infrastructure.EfCore/SimpleStore.Inventories.Infrastructure.EfCore.csproj"]
COPY ["src/Services/Inventories/SimpleStore.InventoriesApi/SimpleStore.InventoriesApi.csproj", "Services/Inventories/SimpleStore.InventoriesApi/SimpleStore.InventoriesApi.csproj"]

RUN dotnet restore "Services/Inventories/SimpleStore.InventoriesApi/SimpleStore.InventoriesApi.csproj"

COPY ./src .

WORKDIR "/src/Services/Inventories/SimpleStore.InventoriesApi"

RUN dotnet build "SimpleStore.InventoriesApi.csproj" --nologo --no-restore -c Release -o /app/build

#######################################
FROM build AS publish
RUN dotnet publish "SimpleStore.InventoriesApi.csproj" --nologo --no-restore -c Release -o /app/publish

#######################################
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleStore.InventoriesApi.dll"]