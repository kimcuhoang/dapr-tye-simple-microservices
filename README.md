# simple-microservices

![ci](https://github.com/kimcu-on-thenet/simple-microservices/workflows/ci-simple-microservices/badge.svg)

An example of building micro-services by .NET Core

- Utilize [Dapr](https://github.com/dapr/dapr) for [Pub/Sub](https://github.com/dapr/docs/blob/master/concepts/publish-subscribe-messaging/README.md) and [Service Invocation (aka Service Discovery)](https://github.com/dapr/docs/blob/master/concepts/service-invocation/README.md); 
- Expose services via GraphQL and Restful
- Oservability
    - Logging: Use [serilog](https://serilog.net/) and [seq](https://datalust.co/seq)
    - Tracing: Use [Zipkin](https://zipkin.io/) 
    - Metric: [TBD]

## Starting from local with Dapr Cli

### Step 1: Init Dapr

- Follow [this link](https://github.com/dapr/docs/blob/master/getting-started/environment-setup.md#installing-dapr-cli) to install [Dapr](https://dapr.io/)
- Start initializing Dapr

    ```powershell
    λ  dapr init
    ```

### Step 2: Install & Run tye

- [Install dotnet tye](https://github.com/dotnet/tye/blob/master/docs/getting_started.md)
- Run `tye` command

    ```powershell
    tye run --dtrace zipkin=http://localhost:9411 --logs seq=http://localhost:5340
    ```

### Step 3: Update configuration

- We may want to change the sqlserver information in the following `appsettings.json`

    - `.\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi\appsettings.json`
    - `.\src\Services\Inventories\SimpleStore.InventoriesApi\appsettings.json`

### Step 4: Firing Apis

#### Starting ProductCatalog Api

```powershell
dapr run --app-id simplestore-productcatalog-api --app-port 5001 --log-level debug `
--components-path .\components --config .\components\tracing.yaml `
dotnet run dotnet -- -p src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
```

#### Starting Inventories Api

```powershell
dapr run --app-id simplestore-inventories-api --app-port 5002 --log-level debug `
--components-path .\components --config .\components\tracing.yaml `
dotnet run dotnet -- -p src\Services\Inventories\SimpleStore.InventoriesApi
```

#### Starting GraphQL Api

```powershell
dapr run --app-id simplestore-graphql-api --app-port 5000 --log-level debug `
--components-path .\components --config .\components\tracing.yaml `
dotnet run dotnet -- -p src\Services\GraphQL\SimpleStore.GraphQLApi
```

### Step 5: Open browser and use

- Go to `http://localhost:5000`
- Then, use the examples at [Queries and Mutations](QueriesAndMutations.md)

## Cleanup

```powershell
dapr uninstall --all
```

## Deploy to Kubernetes

- These services can be also deployed to Kubernetes by following [this guide](Helm/README.md)

## Resources

- [HttpClientFactory .NET Core 2.1](https://danieldonbavand.com/httpclientfactory-net-core-2-1/)
- [Issue: Globalization Invariant Mode is not supported while using EntityFramework Core with dotnet core alpine images](https://github.com/dotnet/efcore/issues/18025)
- [Github Actions Documentation](https://help.github.com/en/actions)
- [Dapr](https://github.com/dapr/dapr)
    - [Darp Doc](https://github.com/dapr/docs)
- [Serilog Best Practices](https://benfoster.io/blog/serilog-best-practices/)
- [5 ways to set the URLs for an ASP.NET Core app](https://andrewlock.net/5-ways-to-set-the-urls-for-an-aspnetcore-app/)

https://thecodebuzz.com/header-propagation-middleware-net-core/

## Give a Star! :star:

If you liked this project or if it helped you, please give a star :star: for this repository. Thank you!!!