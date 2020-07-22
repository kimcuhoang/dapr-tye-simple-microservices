# simple-microservices

An example of building .NET Core microservices with [Dapr](https://github.com/dapr/dapr) and [Tye](https://github.com/dotnet/tye)

![ci](https://github.com/kimcu-on-thenet/simple-microservices/workflows/ci-simple-microservices/badge.svg)


## Overview

- There are 3 services in this repo `products-api`, `inventories-api`, `graphql-api` run as Dapr clients which can be started by `dapr run` or `tye run`.
- Observability
    - Distributed tracing: [zipkin](https://zipkin.io/)
    - Distributed logging: [seq](https://datalust.co/seq)
    - Metrics: **TODO**

## Dapr Building Block

1. Services Communication
    - [Pub/Sub](https://github.com/dapr/docs/blob/master/concepts/publish-subscribe-messaging/README.md) : Redis
        - Create a product at `products-api` then publish an event to `inventories-api` to create a product as well.
    - [Service Invocation (aka Service Discovery)](https://github.com/dapr/docs/blob/master/concepts/service-invocation/README.md)
        - Listing products at `products-api` within inventories information from `inventories-api`
        
1. Observability
    - [Distributed Tracing](https://github.com/dapr/samples/blob/master/8.observability/README.md) with [zipkin](https://zipkin.io/)

1. [Ingress](https://github.com/dotnet/tye/blob/0.4/docs/recipes/ingress.md)

## Prerequisites

1. .NET Core 3.1
1. Docker for desktop
1. [Install Dapr 0.9](https://github.com/dapr/docs/blob/master/getting-started/environment-setup.md#installing-dapr-cli)
1. [Install Tye 0.4](https://github.com/dotnet/tye/blob/master/docs/getting_started.md)


## Running Locally

There are **2 options** to start services

1. [Starts Services with Tye](/docs/start_services_with_tye.md) which is default mode

    - In this mode, all of services has been started by [Tye](https://github.com/dotnet/tye). Also, we utilize the extensions which are supported out-of-the-box.

1. [Starts Services with Darp](/docs/start_services_with_dapr.md)

    - By running this mode, we use **Tye** as **docker-compose** to start the infrastructure, i.e. **seq** and **sqlserver**. Then, all services will be started manually with `dapr run` command.

### Why do we need an option to start services with Dapr while Tye can start with only one command?

Perhaps, this question maybe rise up when every one touch this repository. It just because this repo aims to apply purely Dapr before apply Tye in order to understand

1. How Dapr works
2. Without Tye
    - We have to plug **serilog** and its extension for **seq** to implement **Distributed Logging**
    - The services need to be predefined with specific port number
3. If we apply Tye, we do not need to do the above stuffs, because [it simplify microservices development by making it easy to](https://github.com/dotnet/tye#project-tye):
    > - Run many services with one command
    > - Use dependencies in containers
    > - Discover addresses of other services using simple conventions

## Deploy to Kubernetes

After experience on locally and see how Tye is useful, then we may want to step up by deploy to Kubernetes, of course with Tye as well. [This guide](/.helm/README.md) is step-by-step of: 

- Install infrastructure via Helm: SqlServer, Redis, Seq, Zipkin and even Dapr
- Using `tye deploy` to deploy our micro-services to Kubernetes
- Using **NGINX Ingress Controller** to avoid `kubectl port-forward`


## Resources

- [HttpClientFactory .NET Core 2.1](https://danieldonbavand.com/httpclientfactory-net-core-2-1/)
- [Issue: Globalization Invariant Mode is not supported while using EntityFramework Core with dotnet core alpine images](https://github.com/dotnet/efcore/issues/18025)
- [Github Actions Documentation](https://help.github.com/en/actions)
- [Dapr](https://github.com/dapr/dapr)
    - [Darp Doc](https://github.com/dapr/docs)
- [Serilog Best Practices](https://benfoster.io/blog/serilog-best-practices/)
- [5 ways to set the URLs for an ASP.NET Core app](https://andrewlock.net/5-ways-to-set-the-urls-for-an-aspnetcore-app/)
- [Introduction Project Tye](https://devblogs.microsoft.com/aspnet/introducing-project-tye/)
- [MediatR Pipeline Behaviour in ASP.NET Core – Logging and Validation](https://www.codewithmukesh.com/blog/mediatr-pipeline-behaviour/)


## Give a Star! :star:

If you liked this project or if it helped you, please give a star :star: for this repository. Thank you!!!