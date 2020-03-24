# Get the current inventories

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

## Result

```json
{
  "data": {
    "inventories": {
      "totalRecords": 3,
      "inventories": [
        {
          "inventoryId": "7aa9115d-00d9-4215-98fa-cbd9aceb0744",
          "location": "Inventory-1-Location",
          "name": "Inventory-1",
          "products": [
            {
              "productId": "15f110f6-38e8-4a21-a344-e5f164f233d6",
              "code": "PRD-1",
              "quantity": 10,
              "canPurchase": true
            },
            {
              "productId": "cc04b8ae-01cb-4233-8c82-73e77b21e980",
              "code": "PRD-3",
              "quantity": 5,
              "canPurchase": true
            },
            {
              "productId": "98dd4f6c-bc3b-4a4c-abaf-4edb83aecceb",
              "code": "NEWPRD",
              "quantity": 5,
              "canPurchase": true
            }
          ]
        },
        {
          "inventoryId": "db9af98a-2a0e-4888-9cab-2b9d018bdf88",
          "location": "Inventory-2-Location",
          "name": "Inventory-2",
          "products": [
            {
              "productId": "3d7c9d9b-d889-40f0-963c-643f9ec28d0c",
              "code": "PRD-2",
              "quantity": 1,
              "canPurchase": true
            },
            {
              "productId": "15f110f6-38e8-4a21-a344-e5f164f233d6",
              "code": "PRD-1",
              "quantity": 3,
              "canPurchase": true
            }
          ]
        },
        {
          "inventoryId": "2bd3355c-e658-4973-9c30-008f85d103bb",
          "location": "Inventory-3-Location",
          "name": "Inventory-3",
          "products": [
            {
              "productId": "3d7c9d9b-d889-40f0-963c-643f9ec28d0c",
              "code": "PRD-2",
              "quantity": 9,
              "canPurchase": true
            },
            {
              "productId": "cc04b8ae-01cb-4233-8c82-73e77b21e980",
              "code": "PRD-3",
              "quantity": 8,
              "canPurchase": true
            }
          ]
        }
      ]
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
mutation createProductInCatalog($request: product_catalog_api_CreateProductRequest!){
  product_catalog_api_CreateProduct(request:$request){
    productId,
    name,
    code
  }
}
```

## Result

```json
{
  "data": {
    "product_catalog_api_CreateProduct": {
      "productId": "b1bdfa34-3fa2-4314-89be-52b671039c47",
      "name": "New Product - 4",
      "code": "N-PRD-4"
    }
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

## Result

```json
{
  "data": {
    "addOrUpdateProductInventory": {
      "inventoryId": "7aa9115d-00d9-4215-98fa-cbd9aceb0744",
      "productId": "b1bdfa34-3fa2-4314-89be-52b671039c47",
      "code": "N-PRD-4",
      "inventoryName": "Inventory-1",
      "quantity": 5,
      "canPurchase": true
    }
  }
}
```