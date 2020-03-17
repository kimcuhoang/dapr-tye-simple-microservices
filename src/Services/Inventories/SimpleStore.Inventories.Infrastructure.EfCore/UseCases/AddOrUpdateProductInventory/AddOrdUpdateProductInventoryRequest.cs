using System;
using MediatR;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory
{
    public class AddOrdUpdateProductInventoryRequest : IRequest<AddOrUpdateProductInventoryResponse>
    {
        public Guid ProductId { get; set; }
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
