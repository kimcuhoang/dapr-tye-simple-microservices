using System;
using System.Collections.Generic;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProductsByIds
{
    public class GetProductsByIdsRequest
    {
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
