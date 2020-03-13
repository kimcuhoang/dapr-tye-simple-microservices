using System.Collections.Generic;
using System.Linq;
using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class Inventory : AggregateRoot
    {
        public InventoryId InventoryId => (InventoryId)this.Id;

        public string Location { get; private set; }
        public string Name { get; private set; }

        private List<ProductInventory> _products = new List<ProductInventory>();

        public IEnumerable<ProductInventory> Products => this._products;

        #region Constructors

        private Inventory() { }

        private Inventory(InventoryId inventoryId, string name, string location) : base(inventoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw CoreException.NullOrEmptyArgument(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw CoreException.NullOrEmptyArgument(nameof(location));
            }

            this.Name = name;
            this.Location = location;
        }

        private Inventory(string name, string location) : this(IdentityFactory.Create<InventoryId>(), name, location) { }

        #endregion

        #region Creations

        public static Inventory Create(string name, string location) => new Inventory(name, location);

        #endregion

        #region Behaviors

        public Inventory ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw CoreException.NullOrEmptyArgument(nameof(name));
            }

            this.Name = name;
            return this;
        }

        public Inventory ChangeLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw CoreException.NullOrEmptyArgument(nameof(location));
            }

            this.Location = location;
            return this;
        }

        public Inventory AddProduct(ProductId productId, int quantity, bool canPurchase = true)
        {
            if (this._products.Any(x => x.ProductId == productId))
            {
                throw new CoreException($"Product-{productId} has been existing in Inventory-{this.InventoryId}");
            }

            var productInventory = ProductInventory.Create(productId, this.InventoryId, quantity, canPurchase);
            this._products.Add(productInventory);
            return this;
        }

        public Inventory RemoveProduct(ProductId productId)
        {
            var productInventory = this._products.SingleOrDefault(x => x.ProductId == productId);

            if (productInventory == null)
            {
                throw new CoreException($"Could not find Product-{productId} in Inventory-{this.InventoryId}");
            }

            this._products = this._products.Where(x => x.ProductId != productId).ToList();

            return this;
        }

        #endregion
    }
}
