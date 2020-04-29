# simple-microservices

![price](https://github.com/kimcu-on-thenet/simple-microservices/blob/master/LICENSE)
![ci](https://github.com/kimcu-on-thenet/simple-microservices/workflows/ci-simple-microservices/badge.svg)

An example of building micro-services by .NET Core

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

### Step 1

```cmd
docker-compose -f docker-compose-dev.yml up -d
```

_To see the logs_

```cmd
docker-compose -f docker-compose-dev.yml logs -f
```

To exit the interactive mode use `Ctrl + C`

### Step 2

```cmd
dotnet run -p .\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi\SimpleStore.ProductCatalogApi.csproj
```

```cmd
dotnet run -p .\src\Services\Inventories\SimpleStore.InventoriesApi\SimpleStore.InventoriesApi.csproj
```

```cmd
dotnet run -p .\src\Services\GraphQL\SimpleStore.GraphQLApi\SimpleStore.GraphQLApi.csproj
```

### Step 3

- Go to `http://localhost:5000`
- Then use the examples at [Queries and Mutations](QueriesAndMutations.md)


## Deploy to Kubernetes

- Please see the [guide](Helm/README.md)

## Notes

### Add migration for EntityFrameworkCore

1. Via **Package Manager Console**

- For Product Catalog

    ```powershell
    Add-Migration Init_DB -Project src\Services\ProductCatalog\SimpleStore.ProductCatalog.Infrastructure.EfCore -StartupProject src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
    ```

- For Inventories

    ```powershell
    Add-Migration Init_DB -Project src\Services\Inventories\SimpleStore.Inventories.Infrastructure.EfCore -StartupProject src\Services\Inventories\SimpleStore.InventoriesApi
    ```

2. Via dotnet ef cli

- For Product Catalog

    ```cmd
    dotnet ef migrations add Init_DB --project src\Services\ProductCatalog\SimpleStore.ProductCatalog.Infrastructure.EfCore --startup-project src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
    ```

- For Inventories

    ```cmd
    dotnet ef migrations add Init_DB --project src\Services\Inventories\SimpleStore.Inventories.Infrastructure.EfCore --startup-project src\Services\Inventories\SimpleStore.InventoriesApi
    ```

3. Resources

- [Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell)

### How to use IHttpClientFactory

- [HttpClientFactory .NET Core 2.1](https://danieldonbavand.com/httpclientfactory-net-core-2-1/)

### Some useful docker commands

1. Remove un-tagged images

```powershell
docker images | ConvertFrom-String | where {$_.P2 -eq "<none>"} | % { docker rmi $_.P3 -f}
```

2. Remove all images of **simplestore**

```powershell
docker images --format "{{.ID}}\t{{.Repository}}" | ConvertFrom-String | where { $_.P2 -match 'simplestore-' } | % { docker rmi $_.P1 }
```

### Issue: Globalization Invariant Mode is not supported

- EntityFramework Core has this issue while working with dotnet core alpine images. See the solution at [here](https://github.com/dotnet/efcore/issues/18025)