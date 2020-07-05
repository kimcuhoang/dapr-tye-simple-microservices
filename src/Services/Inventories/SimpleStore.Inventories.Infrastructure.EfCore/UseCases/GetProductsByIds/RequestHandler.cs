using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Inventories.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds
{
    public class RequestHandler : IRequestHandler<GetProductsByIdsRequest, GetProductsByIdsResponse>
    {
        private readonly DbContext _dbContext;

        public RequestHandler(DbContext dbContext) => this._dbContext = dbContext;

        #region Implementation of IRequestHandler<in GetProductsByIdsRequest,GetProductsByIdsResponse>

        public async Task<GetProductsByIdsResponse> Handle(GetProductsByIdsRequest request, CancellationToken cancellationToken)
        {
            var query = this._dbContext.Set<Product>();

            var products = await query.AsNoTracking()
                .Include(p => p.Inventories)
                .ThenInclude(x => x.Inventory)
                .Where(p => request.ProductIds.Any(id => p.ProductId == id))
                .Select(x => new GetProductsByIdsResponse.ProductResult
                {
                    Id = x.ProductId,
                    Code = x.Code,
                    Inventories = x.Inventories.Select(i => new GetProductsByIdsResponse.ProductInventoryResult
                    {
                        InventoryId = i.Inventory.InventoryId,
                        Name = i.Inventory.Name,
                        Location = i.Inventory.Location,
                        CanPurchase = i.CanPurchase,
                        Quantity = i.Quantity
                    })
                }).ToListAsync(cancellationToken);

            var response = new GetProductsByIdsResponse
            {
                Products = products
            };

            return response;
        }

        #endregion
    }
}
