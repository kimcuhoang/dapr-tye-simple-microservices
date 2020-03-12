using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class Inventory : AggregateRoot
    {
        public InventoryId InventoryId => (InventoryId)this.Id;

        public string Location { get; private set; }
        public string Name { get; private set; }

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

        #endregion
    }
}
