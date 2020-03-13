using System.Collections.Generic;
using System.Linq;
using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class Product : AggregateRoot
    {
        public ProductId ProductId => (ProductId) this.Id;

        public string Code { get; private set; }

        private List<ProductInventory> _inventories = new List<ProductInventory>();

        public IEnumerable<ProductInventory> Inventories => this._inventories;

        #region Constructors

        private Product() { }

        private Product(ProductId productId, string code) : base(productId)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw CoreException.NullOrEmptyArgument(nameof(code));
            }
            this.Code = code;
        }

        private Product(string code) : this(IdentityFactory.Create<ProductId>(), code) { }

        #endregion

        #region Creations

        public static Product Of(string code) => new Product(code);

        public static Product Of(ProductId productId, string code) => new Product(productId, code);

        #endregion

        #region Behaviors

        public Product AssignToInventory(InventoryId inventoryId, int quantity, bool canPurchase = true)
        {
            if (this._inventories.Any(x => x.InventoryId == inventoryId))
            {
                throw new CoreException($"Product-{this.ProductId} has been assigned to Inventory-{inventoryId}.");
            }

            var productInventory = ProductInventory.Create(this.ProductId, inventoryId, quantity, canPurchase);
            this._inventories.Add(productInventory);
            return this;
        }

        public Product RevokeFromInventory(InventoryId inventoryId)
        {
            var productInventory = this._inventories.SingleOrDefault(x => x.InventoryId == inventoryId);

            if (productInventory == null)
            {
                throw new CoreException($"Product-{this.ProductId} has not been assigned to Inventory-{inventoryId}.");
            }

            this._inventories = this._inventories.Where(x => x.InventoryId != inventoryId).ToList();
            return this;
        }

        #endregion
    }
}
