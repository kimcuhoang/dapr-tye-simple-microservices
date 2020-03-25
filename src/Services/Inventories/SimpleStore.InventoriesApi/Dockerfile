FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.1-alpine3.10 AS base
WORKDIR /app
EXPOSE 80 5002
RUN apk add icu-libs
# https://www.abhith.net/blog/docker-sql-error-on-aspnet-core-alpine/
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101-alpine3.10 AS build
ENV GLIBC_REPO=https://github.com/sgerrand/alpine-pkg-glibc
ENV GLIBC_VERSION=2.30-r0
RUN set -ex && \
    apk --update add libstdc++ curl ca-certificates && \
    for pkg in glibc-${GLIBC_VERSION} glibc-bin-${GLIBC_VERSION}; \
    do curl -sSL ${GLIBC_REPO}/releases/download/${GLIBC_VERSION}/${pkg}.apk -o /tmp/${pkg}.apk; done && \
    apk add --allow-untrusted /tmp/*.apk && \
    rm -v /tmp/*.apk && \
    /usr/glibc-compat/sbin/ldconfig /lib /usr/glibc-compat/lib

COPY ./services.json .
WORKDIR /src

COPY ["src/BuildingBlocks/SimpleStore.Domain/SimpleStore.Domain.csproj", "BuildingBlocks/SimpleStore.Domain/SimpleStore.Domain.csproj"]
COPY ["src/BuildingBlocks/SimpleStore.Infrastructure.Common/SimpleStore.Infrastructure.Common.csproj", "BuildingBlocks/SimpleStore.Infrastructure.Common/SimpleStore.Infrastructure.Common.csproj"]
COPY ["src/BuildingBlocks/SimpleStore.Infra.RedisPubSub/SimpleStore.Infra.RedisPubSub.csproj", "BuildingBlocks/SimpleStore.Infra.RedisPubSub/SimpleStore.Infra.RedisPubSub.csproj"]
COPY ["src/BuildingBlocks/SimpleStore.Infrastructure.EfCore/SimpleStore.Infrastructure.EfCore.csproj", "BuildingBlocks/SimpleStore.Infrastructure.EfCore/SimpleStore.Infrastructure.EfCore.csproj"]

COPY ["src/Services/Inventories/SimpleStore.Inventories.Domain/SimpleStore.Inventories.Domain.csproj", "Services/Inventories/SimpleStore.Inventories.Domain/SimpleStore.Inventories.Domain.csproj"]
COPY ["src/Services/Inventories/SimpleStore.Inventories.Infrastructure.EfCore/SimpleStore.Inventories.Infrastructure.EfCore.csproj", "Services/Inventories/SimpleStore.Inventories.Infrastructure.EfCore/SimpleStore.Inventories.Infrastructure.EfCore.csproj"]
COPY ["src/Services/Inventories/SimpleStore.InventoriesApi/SimpleStore.InventoriesApi.csproj", "Services/Inventories/SimpleStore.InventoriesApi/SimpleStore.InventoriesApi.csproj"]

RUN dotnet restore "Services/Inventories/SimpleStore.InventoriesApi/SimpleStore.InventoriesApi.csproj"

COPY ./src .

WORKDIR "/src/Services/Inventories/SimpleStore.InventoriesApi"

RUN dotnet build "SimpleStore.InventoriesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleStore.InventoriesApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleStore.InventoriesApi.dll"]