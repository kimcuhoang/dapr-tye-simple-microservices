# simple-microservices
An example of building micro-services by .NET Core

## Step 1

```cmd
docker-compose -f docker-compose.yml -f docker-compose.override.yml up
```

## Step 2

```cmd
dotnet run -p .\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi\SimpleStore.ProductCatalogApi.csproj
```