using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Domain;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory
{
    public class RequestHandler : IRequestHandler<AddOrdUpdateProductInventoryRequest, AddOrUpdateProductInventoryResponse>
    {
        private readonly DbContext _dbContext;

        public RequestHandler(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #region Implementation of IRequestHandler<in UpdateProductInventoryRequest,UpdateProductInventoryResponse>

        public async Task<AddOrUpdateProductInventoryResponse> Handle(AddOrdUpdateProductInventoryRequest request, CancellationToken cancellationToken)
        {
            var inventoryQuery = this._dbContext.Set<Inventory>();
            
            var inventory =
                await inventoryQuery.SingleOrDefaultAsync(x => x.InventoryId == request.InventoryId, cancellationToken);

            if (inventory == null)
            {
                throw new CoreException($"Could not find Inventory-{request.InventoryId}.");
            }

            var product = await this._dbContext.Set<Product>()
                .SingleOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);

            if (product == null)
            {
                throw new CoreException($"Could not find Product-{request.ProductId}");
            }

            var productInventory = inventory.Products.SingleOrDefault(x => x.Product == product);

            if (productInventory == null)
            {
                productInventory = inventory.WithProduct(product, request.Quantity, request.CanPurchase);
            }
            else
            {
                productInventory
                    .ChangeQuantity(request.Quantity)
                    .SetCanPurchase(request.CanPurchase);
            }

            inventoryQuery.Update(inventory);

            return new AddOrUpdateProductInventoryResponse
            {
                ProductId = product.ProductId,
                InventoryId = inventory.InventoryId,
                Code = product.Code,
                InventoryName = inventory.Name,
                Quantity = productInventory.Quantity,
                CanPurchase = productInventory.CanPurchase
            };
        }

        #endregion
    }
}
