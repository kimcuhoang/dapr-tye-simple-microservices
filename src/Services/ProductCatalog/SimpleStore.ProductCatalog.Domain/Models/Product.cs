using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.ProductCatalog.Domain.Models
{
    public class Product : AggregateRoot
    {
        public ProductId ProductId => (ProductId)this.Id;

        public string Name { get; private set; }

        #region Constructors

        private Product(ProductId productId, string productName) : base(productId)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw CoreException.NullOrEmptyArgument(nameof(productName));
            }

            this.Name = productName;
        }

        private Product(string productName) : this(IdentityFactory.Create<ProductId>(), productName)
        {
            this.AddUncommittedEvent(new ProductCreated
            {
                ProductId = this.ProductId
            });
        }

        private Product() { }

        #endregion

        #region Creations

        public static Product Create(string productName) => new Product(productName);

        #endregion

        #region Behaviors

        public Product ChangeName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw CoreException.NullOrEmptyArgument(nameof(productName));
            }

            this.Name = productName;
            return this;
        }

        #endregion
    }
}
