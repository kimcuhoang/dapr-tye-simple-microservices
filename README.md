# simple-microservices

An example of building micro-services by .NET Core

## Business Rules

1. Create a **Inventory** in **Inventories** context => `InventoryId`
2. Create a **Product** in **ProductCatalog** context => `ProductId`
  - By using **Domain Event** within **Publish Subscribe Pattern** and Redis Pub/Sub; it's going to create a **Product** in **Inventories** context automatically
4. Assign **Product** to **Inventory** with `Quantity` and `CanPurchase`

## Getting started

### Step 1

```cmd
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

_To see the logs_

```cmd
docker-compose -f docker-compose.yml -f docker-compose.override.yml logs -f
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
- [Queries and Mutations](QueriesAndMutations.md)


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

## Notes

### Add migration for EntityFrameworkCore

1. Via **Package Manager Console**

```powershell
Add-Migration Add_Product -Project src\Services\ProductCatalog\SimpleStore.ProductCatalog.Infrastructure.EfCore -StartupProject src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
```

2. Via dotnet ef cli

```cmd
dotnet ef migrations add Init_DB --project src\Services\ProductCatalog\SimpleStore.ProductCatalog.Infrastructure.EfCore --startup-project src\Services\ProductCatalog\SimpleStore.ProductCatalogApi
```

3. Resources

- [Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell)