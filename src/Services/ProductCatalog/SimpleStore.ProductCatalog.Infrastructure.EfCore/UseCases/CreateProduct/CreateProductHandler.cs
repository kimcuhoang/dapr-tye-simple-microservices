using MediatR;
using SimpleStore.ProductCatalog.Domain.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class CreateProductHandler : AsyncRequestHandler<CreateProductRequest>
    {
        private readonly ProductCatalogDbContext _dbContext;

        public CreateProductHandler(ProductCatalogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #region Overrides of AsyncRequestHandler<CreateProductRequest>

        protected override async Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.ProductName);

            await this._dbContext.Set<Product>().AddAsync(product, cancellationToken);
        }

        #endregion
    }
}
