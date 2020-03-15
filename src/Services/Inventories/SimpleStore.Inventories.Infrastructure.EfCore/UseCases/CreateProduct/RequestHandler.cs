using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Inventories.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class RequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly DbContext _dbContext;

        public RequestHandler(DbContext dbContext)
            => this._dbContext = dbContext;

        #region Implementation of IRequestHandler<in CreateProductRequest,CreateProductResponse>

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = Product.Of((ProductId) request.ProductId, request.ProductCode);

            var entry = await this._dbContext.Set<Product>().AddAsync(product, cancellationToken);

            var response = new CreateProductResponse
            {
                ProductId = entry.Entity.ProductId,
                Code = entry.Entity.Code
            };

            return response;
        }

        #endregion
    }
}
