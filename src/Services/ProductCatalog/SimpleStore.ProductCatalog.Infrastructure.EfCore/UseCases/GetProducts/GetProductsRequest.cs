using System.Collections.Generic;
using MediatR;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
