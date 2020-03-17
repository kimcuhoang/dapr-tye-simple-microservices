using MediatR;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
