using SimpleStore.Domain;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class Product : AggregateRoot
    {
        public ProductId ProductId => (ProductId) this.Id;

        public string Code { get; private set; }

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

        #endregion
    }
}
