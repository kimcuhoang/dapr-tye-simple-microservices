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

- These services can be also deployed to Kubernetes by following [this guide](Helm/README.md)

## Resources

- [HttpClientFactory .NET Core 2.1](https://danieldonbavand.com/httpclientfactory-net-core-2-1/)
- [Issue: Globalization Invariant Mode is not supported while using EntityFramework Core with dotnet core alpine images](https://github.com/dotnet/efcore/issues/18025)
- [Github Actions Documentation](https://help.github.com/en/actions)