using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Domain;
using SimpleStore.Inventories.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddProductToInventory
{
    public class RequestHandler : IRequestHandler<AddProductToInventoryRequest, AddProductToInventoryResponse>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        #region Implementation of IRequestHandler<in AddProductToInventoryRequest,AddProductToInventoryResponse>

        public async Task<AddProductToInventoryResponse> Handle(AddProductToInventoryRequest request, CancellationToken cancellationToken)
        {
            var queryInventory = this._dbContext.Set<Inventory>();

            var inventory = await queryInventory.SingleOrDefaultAsync(x => x.InventoryId == request.InventoryId, cancellationToken);

            if (inventory == null)
            {
                throw new CoreException($"Could not find Inventory-{request.InventoryId}.");
            }

            var product = await this._dbContext.Set<Product>()
                .SingleOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);

            if (product == null)
            {
                throw new CoreException($"Could not find Product-{request.ProductId}.");
            }

            var productInventory = inventory.WithProduct(product, request.Quantity, request.CanPurchase);

            var entry = queryInventory.Update(inventory);

            return new AddProductToInventoryResponse
            {
                ProductInventoryId = productInventory.ProductInventoryId
            };
        }

        #endregion
    }
}
