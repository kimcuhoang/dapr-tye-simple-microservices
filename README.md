# simple-microservices

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

## Getting started

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

## Use docker-compose to spin up images

### Step 1

1. Build images

```cmd
docker-compose -f docker-compose.yml build
```

2. Starting containers

```cmd
docker-compose -f docker-compose.yml -f docker-compose-deploy.yml up -d
```

3. View the logs until all containers start successfully

```cmd
docker-compose -f docker-compose.yml -f docker-compose-deploy.yml logs -f
```

4. Exit the interactive mode by using `Ctrl + C` combination keys

### Step 2

- Let play with GraphQL by going to `http://localhost:5010`
- Then use the examples at [Queries and Mutations](QueriesAndMutations.md)

## Histories

1. [Resolve Issue #1](https://github.com/kimcu-on-thenet/simple-microservices/issues/1)
    - Add [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore)
    - Implement a custom TypeConverter & JsonConverter in order to serve for StronglyType-Id => see the issue [#3](https://github.com/kimcu-on-thenet/simple-microservices/issues/3)

2. [Resolve Issue #6](https://github.com/kimcu-on-thenet/simple-microservices/issues/6) => Enable GraphQL for **ProductCatalogApi** and define **GraphQLApi**
    - ProductCatalog
        - Define the following requests:
          - GetProductsRequest
          - CreateProductRequest
          - UpdateProductRequest
        - Define `InputObject`, `ObjectType`, `QueryType` & `MutationType` classes
    - GraphQL
        - Use **StitchedSchema** functionality
    - Use sharing Settings by following the [blog](https://andrewlock.net/sharing-appsettings-json-configuration-files-between-projects-in-asp-net-core/)

3. [Resolve Issue #8](https://github.com/kimcu-on-thenet/simple-microservices/issues/8)
    - Define **InventoryApi**

4. [Resolve Issue #10](https://github.com/kimcu-on-thenet/simple-microservices/issues/10)
    - Integration between **ProductCatalog** and **Inventories**
        - Create a **Product** in **ProductCatalog** also create a **Product** in **Inventories** context => Pub/Sub
        - When retrieves Products from **ProductCatalog**, it also includes their assignments in **Inventories** context => Gateway

5. [Resolve Issue #12](https://github.com/kimcu-on-thenet/simple-microservices/issues/12)
    - Write `Dockerfile` for services: ProductCatalog, Inventories and GraphQL
    - Separating `docker-compose-dev.yaml` in order to work with development mode
    - Re-write `docker-compose.yaml` and write new `docker-compose-deploy.yaml` for container orchestrating purpose
    - Notes:
        - Use **mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11** for build stage
        - Use **mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine3.11** for runtime
 

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