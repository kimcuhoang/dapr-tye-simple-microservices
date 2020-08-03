using System.Collections.Generic;
using System.Linq;
using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class Product : AggregateRoot<ProductId>
    {
        public string Code { get; private set; }

        private readonly List<ProductInventory> _inventories = new List<ProductInventory>();

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

        public ProductInventory WithInventory(Inventory inventory, int quantity, bool canPurchase = true)
        {
            if (inventory == null)
            {
                throw CoreException.NullOrEmptyArgument(nameof(inventory));
            }

            if (this._inventories.Any(x => x.Inventory == inventory))
            {
                throw new CoreException($"{this} is existing in {inventory}");
            }

            var productInventory = ProductInventory.Create(this, inventory, quantity, canPurchase);
            this._inventories.Add(productInventory);
            return productInventory;
        }

        #endregion
    }
}
