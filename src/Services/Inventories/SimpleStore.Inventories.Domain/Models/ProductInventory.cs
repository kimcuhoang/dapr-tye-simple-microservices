using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class ProductInventory : EntityBase
    {
        public ProductInventoryId ProductInventoryId => (ProductInventoryId) this.Id;

        public ProductId ProductId { get; private set; }
        public InventoryId InventoryId { get; private set; }
        public int Quantity { get; private set; }
        public bool CanPurchase { get; private set; }

        #region Constructors

        private ProductInventory() { }

        private ProductInventory(ProductInventoryId productInventoryId, ProductId productId, InventoryId inventoryId, int quantity, bool canPurchase = true)
            : base(inventoryId)
        {
            if (productId == null)
            {
                throw CoreException.NullOrEmptyArgument(nameof(productId));
            }

            if (inventoryId == null)
            {
                throw CoreException.NullOrEmptyArgument(nameof(inventoryId));
            }
        }

        private ProductInventory(ProductId productId, InventoryId inventoryId, int quantity, bool canPurchase = true)
            : this(IdentityFactory.Create<ProductInventoryId>(), productId, inventoryId, quantity, canPurchase) { }

        #endregion

        #region Creations

        public static ProductInventory Create(ProductId productId, InventoryId inventoryId, int quantity, bool canPurchase = true)
            => new ProductInventory(productId, inventoryId, quantity, canPurchase);

        #endregion

        #region Behaviors

        public ProductInventory ChangeQuantity(int quantity)
        {
            this.Quantity = quantity;
            return this;
        }

        public ProductInventory SetCanPurchase(bool canPurchase = true)
        {
            this.CanPurchase = canPurchase;
            return this;
        }

        #endregion
    }
}
