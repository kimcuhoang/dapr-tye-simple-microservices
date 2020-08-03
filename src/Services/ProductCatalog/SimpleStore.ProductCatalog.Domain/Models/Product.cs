using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.ProductCatalog.Domain.Models
{
    public class Product : AggregateRoot<ProductId>
    {
        public string Name { get; private set; }

        public string Code { get; private set; }

        #region Constructors

        private Product(ProductId productId, string productCode, string productName) : base(productId)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                throw CoreException.NullOrEmptyArgument(nameof(productCode));
            }

            if (string.IsNullOrWhiteSpace(productName))
            {
                throw CoreException.NullOrEmptyArgument(nameof(productName));
            }

            this.Name = productName;
            this.Code = productCode;
        }

        private Product(string productCode, string productName) : this(IdentityFactory.Create<ProductId>(), productCode, productName)
        {
            this.AddUncommittedEvent(new ProductCreated
            {
                ProductId = this.Id,
                ProductCode = this.Code
            });
        }

        private Product() { }

        #endregion

        #region Creations

        public static Product Create(ProductId productId, string productCode, string productName) => new Product(productId, productCode, productName);

        public static Product Create(string productCode, string productName) => new Product(productCode, productName);

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
