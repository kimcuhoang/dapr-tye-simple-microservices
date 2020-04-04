## Install Dapr Kubernetes

1. Initialize

    ```powershell
    ❯ dapr init --kubernetes
    Making the jump to hyperspace...
    Note: this installation is recommended for testing purposes. For production environments, please use Helm

    Deploying the Dapr Operator to your cluster...
    Success! Dapr has been installed. To verify, run 'kubectl get pods -w' in your terminal. To get started, go here: https://aka.ms/dapr-getting-started
    ```
2. Config Redis

    - [Setup Redis](https://github.com/dapr/docs/blob/master/howto/setup-state-store/setup-redis.md)

        ```powershell
        helm repo add bitnami https://charts.bitnami.com/bitnami

        helm install redis bitnami/redis
        ```

    - [Configure Redis](https://github.com/dapr/docs/tree/master/howto/configure-redis)

        ```powershell
        kubectl get secret --namespace default redis -o jsonpath="{.data.redis-password}" > encoded.b64

        certutil -decode encoded.b64 password.txt
        ```

        [Tutorial: First Look at Dapr for Microservices Running in Kubernetes](https://thenewstack.io/tutorial-first-look-at-dapr-for-microservices-running-in-kubernetes/)

    - Open `password.txt` from previous step; copy & paste this value to **redisPassword** in `.\redis-components\*.yaml` 

3. Install Dapr components

    ```powershell
    kubectl apply -f .\redis-components
    ```

## Install Helm packages

### simplestore-sqlserver

    ```powershell
    λ  helm install inventories-api .\inventories-api\
    NAME: inventories-api
    LAST DEPLOYED: Sun Apr  5 12:33:23 2020
    NAMESPACE: default
    STATUS: deployed
    REVISION: 1
    ```

### product-catalog-api

    ```powershell
    λ  helm install product-catalog-api .\product-catalog-api\
    NAME: product-catalog-api
    LAST DEPLOYED: Sun Apr  5 12:38:25 2020
    NAMESPACE: default
    STATUS: deployed
    REVISION: 1
    ```

### graphql

    ```powershell
    λ  helm install graphql .\graphql
    NAME: graphql
    LAST DEPLOYED: Sun Apr  5 12:42:49 2020
    NAMESPACE: default
    STATUS: deployed
    REVISION: 1
    ```

## Start using

- Open browser `http://localhost:5100`
- Use graphql's queries and mutation from [here](../QueriesAndMutations.md)