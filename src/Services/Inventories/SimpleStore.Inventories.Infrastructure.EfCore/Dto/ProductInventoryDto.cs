using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class ProductInventoryDto
    {
        public Guid ProductInventoryId { get; set; }
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
