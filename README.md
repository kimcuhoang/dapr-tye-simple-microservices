# simple-microservices
An example of building micro-services by .NET Core

## Getting started

### Step 1

```cmd
docker-compose -f docker-compose.yml -f docker-compose.override.yml up
```

### Step 2

```cmd
dotnet run -p .\src\Services\ProductCatalog\SimpleStore.ProductCatalogApi\SimpleStore.ProductCatalogApi.csproj
```

### Step 3

#### Get all products

- Open browser with url `http://localhost:5000/api/product`

#### Create a new product

- Use `curl` tool to create a POST request like below

```cmd
curl -X POST -H "Content-Type:application/json" -d "{\"ProductName\":\"New-Product\"}" http://localhost:5000/api/product
```

#### Update existing product

- Use `curl` tool to create a PUT request like below

```cmd
curl -X PUT -H "Content-Type:application/json" -d "{\"ProductId\":\"8300d0f7-c54c-420a-b9da-afb1213fef79\",\"NewProductName\":\"updated-product\"}" http://localhost:5000/api/product
```

## Histories

- Add [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore) => see the issue [#1](https://github.com/kimcu-on-thenet/simple-microservices/issues/1)
- Implement a custom TypeConverter & JsonConverter in order to serve for StronglyType-Id => see the issue [#3](https://github.com/kimcu-on-thenet/simple-microservices/issues/3)