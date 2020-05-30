# Prerequisites

1. Install Docker for Desktop within Kubernetes
2. Download [Dapr CLI (currently is 0.6.0)](https://github.com/dapr/cli/releases/download/v0.6.0/dapr_windows_amd64.zip)

    ```powershell
    λ  dapr --version
    ```

3. Install Dapr to Kubernetes

    ```powershell
    dapr init --kubernetes
    ```

4. Install [Helm 3 (currently is 3.1.2)](https://get.helm.sh/helm-v3.1.2-windows-amd64.zip)

    ```powershell
    λ  helm version
    ```

## Build docker images for Apis

1. Build with `docker-compose`

    ```powershell
    docker-compose build
    ```

2. Verify

    ```powershell
    λ  docker images "simplestore-*" --format "table {{.ID}}\t{{.Size}}\t{{.Repository}}\t{{.Tag}}"
    ```

## Start Installing

```powershell
cd .\Helm
```

### Install Redis

```powershell
λ  helm install redis .\redis\
```

### Configure Statestore & PubSub for Dapr

```powershell
λ  kubectl apply -f .\redis-components\
```

### Install simplestore-sqlserver

```powershell
λ  helm install simplestore-sqlserver .\simplestore-sqlserver\
```

### Install ProductCatalogApi

```powershell
λ  helm install simplestore-productcatalogapi .\product-catalog-api\ --set service.port=5101
```

### Install InventoriesApi

```powershell
λ  helm install simplestore-inventoriesapi .\inventories-api\ --set service.port=5102
```

### Install GraphQLApi

```powershell
λ  helm install simplestore-graphqlapi .\graphql\ --set service.port=5100 --set services.productcatalog="http://simplestore-productcatalogapi:5101" --set services.inventories="http://simplestore-inventoriesapi:5102"
```

### Verify how PubSub work

- Open browser `http://localhost:5100`
- **[Create a Product by a mutation of GraphQL](../QueriesAndMutations.md#create-product-in-catalog)**

## Cleanup

```powershell
λ  helm uninstall redis simplestore-productcatalogapi simplestore-inventoriesapi simplestore-graphqlapi simplestore-sqlserver
```

```powershell
λ  kubectl delete -f .\redis-components\
```

```powershell
λ  dapr uninstall --kubernetes
```