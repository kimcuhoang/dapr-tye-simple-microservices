﻿using Dapr.Client;
using Dapr.Client.Http;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProductsByIds;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways
{
    public class DaprInventoriesGateway
    {
        private readonly ServiceOptions _serviceOptions;
        private readonly DaprClient _daprClient;

        private string InventoryAppId => this._serviceOptions.InventoriesApi.ServiceName;

        private HTTPExtension httpExtension => new HTTPExtension
        {
            Verb = HTTPVerb.Post
        };

        public DaprInventoriesGateway(DaprClient daprClient, IOptions<ServiceOptions> serviceOptions)
        {
            this._daprClient = daprClient;
            this._serviceOptions = serviceOptions.Value;
        } 

        public async Task<GetProductsByIdsResponse> GetProductsByIds(GetProductsByIdsRequest request)
        => await this._daprClient.InvokeMethodAsync<GetProductsByIdsRequest, GetProductsByIdsResponse>(this.InventoryAppId, "get-products-by-ids", request, this.httpExtension);
    }
}
