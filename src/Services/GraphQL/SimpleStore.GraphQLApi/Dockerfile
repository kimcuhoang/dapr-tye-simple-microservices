FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.1-alpine3.10 AS base
WORKDIR /app
# https://github.com/dotnet/efcore/issues/18025
RUN apk add --no-cache icu-libs
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

COPY ["src/Services/GraphQL/SimpleStore.GraphQLApi/SimpleStore.GraphQLApi.csproj", "Services/GraphQL/SimpleStore.GraphQLApi/SimpleStore.GraphQLApi.csproj"]

RUN dotnet restore "Services/GraphQL/SimpleStore.GraphQLApi/SimpleStore.GraphQLApi.csproj"

COPY ./src .

WORKDIR "/src/Services/GraphQL/SimpleStore.GraphQLApi"

RUN dotnet build "SimpleStore.GraphQLApi.csproj" --nologo --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleStore.GraphQLApi.csproj" --nologo --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleStore.GraphQLApi.dll"]