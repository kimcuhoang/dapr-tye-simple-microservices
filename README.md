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

## Step 3

- Open browser with url `http://localhost:5000/api/product`

## Step 4

- Use `curl` tool to create a POST request like below

```cmd
curl -X POST -H "Content-Type:application/json" -d "{\"ProductName\":\"New-Product\"}" http://localhost:5000/api/product
```