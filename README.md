# simple-microservices

An example of building micro-services by .NET Core

![ci](https://github.com/kimcu-on-thenet/simple-microservices/workflows/ci-simple-microservices/badge.svg)

## Business Rules

1. Create a **Inventory** in **Inventories** context => `InventoryId` by using _GraphQL Mutation_
2. Create a **Product** in **ProductCatalog** context => `ProductId` by using _GraphQL Mutation_
    - By using **Domain Event** within **Publish Subscribe Pattern** and Redis Pub/Sub; it's going to create a **Product** in **Inventories** context automatically
4. Assign **Product** to **Inventory** with `Quantity` and `CanPurchase` by using _GraphQL Mutation_
5. Ability to retrieve all products in **ProductCatalog** within the **Inventories** that they've been assigned which can be retrieved from **Inventories** context
    - Since we're developing microservices; the integration must be accomplished by Restful (communicate over HTTP protocol)

## Give a Star! :star:

If you liked this project or if it helped you, please give a star :star: for this repository. Thank you!!!

## Starting from local with Dapr Cli

### Step 1: Init Dapr

- Follow [this link](https://github.com/dapr/docs/blob/master/getting-started/environment-setup.md#installing-dapr-cli) to install [Dapr](https://dapr.io/)
- Start initializing Dapr

    ```powershell
    λ  dapr init
    ```

### Step 2: Start zipkin

```powershell
docker-compose -f docker-compose-dev.yml up -d
```

### Step 3: Update configuration

- We may want to change the sqlserver information in the following `appsettings.json`

    - `.\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi\appsettings.json`
    - `.\src\Services\Inventories\SimpleStore.InventoriesApi\appsettings.json`

### Step 4: Firing Apis

#### Starting ProductCatalog Api

```powershell
dapr run --app-id simplestore-productcatalogapi --app-port 5001 `
--log-level debug --components-path ./components `
--config ./components/tracing.yaml `
dotnet run dotnet -- -p src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
```

#### Starting Inventories Api

```powershell
dapr run --app-id simplestore-inventoriesapi --app-port 5002 `
--log-level debug --components-path ./components `
--config ./components/tracing.yaml `
dotnet run dotnet -- -p src\Services\Inventories\SimpleStore.InventoriesApi
```

#### Starting GraphQL Api

```powershell
dapr run --app-id simplestore-graphqlapi --log-level debug --app-port 5000 `
--log-level debug --components-path ./components `
--config ./components/tracing.yaml `
dotnet run dotnet -- -p src\Services\GraphQL\SimpleStore.GraphQLApi
```

### Step 5: Open browser and use

- Go to `http://localhost:5000`
- Then, use the examples at [Queries and Mutations](QueriesAndMutations.md)

## Cleanup

```powershell
dapr uninstall --all

docker-compose -f docker-compose-dev.yml down -v
```

## Deploy to Kubernetes

- These services can be also deployed to Kubernetes by following [this guide](Helm/README.md)

## Resources

- [HttpClientFactory .NET Core 2.1](https://danieldonbavand.com/httpclientfactory-net-core-2-1/)
- [Issue: Globalization Invariant Mode is not supported while using EntityFramework Core with dotnet core alpine images](https://github.com/dotnet/efcore/issues/18025)
- [Github Actions Documentation](https://help.github.com/en/actions)
- [Dapr](https://github.com/dapr/dapr)
    - [Darp Doc](https://github.com/dapr/docs)