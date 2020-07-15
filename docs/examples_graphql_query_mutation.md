# Get inventories

## Variable

```json
{
  "request": {
    "pageIndex":1,
    "pageSize": 10
  }
}
```

## Query

```js
query getInventories($request: GetInventoriesRequestInput) {
  inventories(request: $request) {
    totalRecords,
    inventories {
      inventoryId,
      location,
      name,
      products {
        productId,
        code,
        quantity,
        canPurchase
      }
    }
  }
}
```

# Get Products from Catalog

## Variables

```json
{
  "request": {
    "pageIndex":1,
    "pageSize": 100
  }
}
```

## Query

```js
query getProductsInCatalog($request: ProductCatalogApi_GetProductsRequest!) {
  ProductCatalogApi_GetProducts(request: $request) {
    totalOfProducts,
    products {
      productId, 
      name,
      code,
      totalAvailability,
      inventories {
        inventoryId,
        name,
        location,
        quantity,
        canPurchase
      }
    }
  }
}
```

# Create Product in Catalog

## Variable

```json
{
  "request": {
    "productName": "New Product - 4",
    "productCode": "N-PRD-4"
  }
}
```

## Mutation

```js
mutation createProductInCatalog($request: ProductCatalogApi_CreateProductRequest!){
  ProductCatalogApi_CreateProduct(request:$request){
    productId,
    name,
    code
  }
}
```

# Add Product to Inventory

## Variable

```json
{
  "request": {
    "productId": "b1bdfa34-3fa2-4314-89be-52b671039c47",
    "inventoryId": "7aa9115d-00d9-4215-98fa-cbd9aceb0744",
    "quantity": 5,
    "canPurchase": true
  }
}
```

## Mutation

```js
mutation addOrUpdateProductInventory($request: AddOrdUpdateProductInventoryRequestInput){
  addOrUpdateProductInventory(request: $request) {
    inventoryId,
    productId,
    code,
    inventoryName,
    quantity,
    canPurchase
  }
}
```

