using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Domain;
using SimpleStore.ProductCatalog.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct
{
    public class UpdateProductHandler : AsyncRequestHandler<UpdateProductRequest>
    {
        private readonly DbContext _dbContext;

        public UpdateProductHandler(DbContext dbContext)
            => this._dbContext = dbContext;

        #region Overrides of AsyncRequestHandler<UpdateProductRequest>

        protected override async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productDbSet = this._dbContext.Set<Product>();
            var product = await productDbSet.SingleOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken: cancellationToken);

            if (product == null)
            {
                throw CoreException.NotFound(request.ProductId.ToString());
            }

            product = product.ChangeName(request.NewProductName);

            productDbSet.Update(product);
        }

        #endregion
    }
}
