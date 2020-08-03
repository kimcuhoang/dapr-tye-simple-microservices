using System.Collections.Generic;
using System.Linq;
using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class Inventory : AggregateRoot<InventoryId>
    {
        public string Location { get; private set; }
        public string Name { get; private set; }

        private readonly List<ProductInventory> _products = new List<ProductInventory>();

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

        public ProductInventory WithProduct(Product product, int quantity, bool canPurchase = true)
        {
            if (this._products.Any(x => x.Product == product))
            {
                throw new CoreException($"{product} is existing in {this}.");
            }
            
            var productInventory = ProductInventory.Create(product, this, quantity, canPurchase);

            this._products.Add(productInventory);
            return productInventory;
        }

        #endregion
    }
}
