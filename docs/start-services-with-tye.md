# Start services with Tye

## Getting Started

1. In this mode, we don't need to run `dapr init` before run `tye run`. Therefore, if we already init Dapr before, we have to uninstall first by `darp uninstall --all`.

1. Then, copy the following files from `.\components` into `%UserProdfile%\.dapr\components` (create it manually if it has not existed yet).
    - **pubsub.yaml**
    - **statestore.yaml**
    - **zipkin.yaml**

1. Start with `tye run` command

    ```bash
    tye run --dashboard
    ```

1. It'll open web browser automatically with the dashboard at `http://127.0.0.1:8000/`

    ![tye's dashboard](images\Tye_Dashboard.png)

## Experience our services via graphql

- Now, let open the `graphql-api` by clicking on the link `http://localhost:63010` in the screenshot; then enjoy with some examples in [here](examples-graphql-query-mutation.md), for example

    ![GraphQL Example](images\Tye-GraphQL-Api.png)

## For Observability

### Tracing

- By clicking on the zipkin's address in dashboard - `http://localhost:9411`, we come to the zipkin's dashboard

    ![Zipkin dashboard](images\Tye-Zipkin-Dashboard.png)

### Logging

- Open the seq's dashboard at - `http://localhost:9431`

    ![Seq dashboard](images\Tye-Seq-Dashboard.png)



