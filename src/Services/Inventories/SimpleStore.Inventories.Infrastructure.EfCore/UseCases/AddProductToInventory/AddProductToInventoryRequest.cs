using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddProductToInventory
{
    public class AddProductToInventoryRequest : IRequest<AddProductToInventoryResponse>
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; } = true;
    }
}
