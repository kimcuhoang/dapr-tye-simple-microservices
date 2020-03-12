using MediatR;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories
{
    public class GetInventoriesRequest : IRequest<GetInventoriesResponse>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
