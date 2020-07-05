using MediatR;
using System;
using System.Collections.Generic;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds
{
    public class GetProductsByIdsRequest : IRequest<GetProductsByIdsResponse>
    {
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
