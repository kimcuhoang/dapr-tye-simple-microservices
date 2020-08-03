using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class ProductInventory : EntityBase<ProductInventoryId>
    {
        public int Quantity { get; private set; }
        public bool CanPurchase { get; private set; }

        public Product Product { get; private set; }
        public Inventory Inventory { get; private set; }

        #region Constructors

        private ProductInventory() { }

        private ProductInventory(ProductInventoryId productInventoryId, Product product, Inventory inventory, int quantity, bool canPurchase = true)
            : base(productInventoryId)
        {
            if (product == null) throw CoreException.NullOrEmptyArgument(nameof(product));
            if (inventory == null) throw CoreException.NullOrEmptyArgument(nameof(inventory));

            this.Product = product;
            this.Inventory = inventory;
            this.Quantity = quantity;
            this.CanPurchase = canPurchase;
        }

        private ProductInventory(Product product, Inventory inventory, int quantity, bool canPurchase = true)
            : this(IdentityFactory.Create<ProductInventoryId>(), product, inventory, quantity, canPurchase) { }

        #endregion

        #region Creations

        public static ProductInventory Create(Product product, Inventory inventory, int quantity, bool canPurchase = true)
            => new ProductInventory(product, inventory, quantity, canPurchase);

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
