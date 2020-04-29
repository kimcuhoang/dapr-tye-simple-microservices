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

    ```powershell
    Making the jump to hyperspace...
    WARNING: could not delete run data file
    Downloading binaries and setting up components...
    Installing Dapr to c:\dapr
    Success! Dapr is up and running. To get started, go here: https://aka.ms/dapr-getting-started
    ```

### Step 2

- We may want to change the sqlserver information in the following `appsettings.json`

    - `.\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi\appsettings.json`
    - `.\src\Services\Inventories\SimpleStore.InventoriesApi\appsettings.json`

### Step 3

#### Starting ProductCatalog Api

```powershell
cd .\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
```


```powershell
dapr run --app-id product-catalog-api --app-port 5001 dotnet run
```

#### Starting Inventories Api

```powershell
cd .\src\Services\Inventories\SimpleStore.InventoriesApi
```

```powershell
dapr run --app-id inventories-api --app-port 5002 dotnet run
```

#### Starting GraphQL Api

```powershell
cd .\src\Services\GraphQL\SimpleStore.GraphQLApi
```

```powershell
dapr run --app-id graphql-api --app-port 5000 dotnet run
```

### Step 4

- Go to `http://localhost:5000`
- Then use the examples at [Queries and Mutations](QueriesAndMutations.md)

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