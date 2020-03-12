﻿using System.Threading.Tasks;
using MediatR;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories;

namespace SimpleStore.InventoriesApi.GraphQL.Objects
{
    public class QueryInventories
    {
        private readonly IMediator _mediator;

        public QueryInventories(IMediator mediator)
            => this._mediator = mediator;

        public async Task<GetInventoriesResponse> GetInventories(GetInventoriesRequest request)
            => await this._mediator.Send(request);
    }
}