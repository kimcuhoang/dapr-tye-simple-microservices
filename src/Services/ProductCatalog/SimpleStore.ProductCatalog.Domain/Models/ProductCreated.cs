using SimpleStore.Domain.Models;
using System;

namespace SimpleStore.ProductCatalog.Domain.Models
{
    public class ProductCreated : IDomainEvent
    {
        #region Implementation of IDomainEvent

        public DateTime CreatedOn => DateTime.UtcNow;

        #endregion

        public Guid ProductId { get; set; }

        public string ProductCode { get; set; } = "PRODUCT";
    }
}
