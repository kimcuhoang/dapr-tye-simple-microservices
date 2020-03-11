using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Domain;
using SimpleStore.ProductCatalog.Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ProductDto>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        } 

        #region Implementation of IRequestHandler<in UpdateProductRequest,ProductDto>

        public async Task<ProductDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productDbSet = this._dbContext.Set<Product>();
            var product = await productDbSet.SingleOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken: cancellationToken);

            if (product == null)
            {
                throw CoreException.NotFound(request.ProductId.ToString());
            }

            product.ChangeName(request.NewProductName);

            var entity = productDbSet.Update(product);

            return this._mapper.Map<ProductDto>(entity.Entity);
        }

        #endregion
    }
}
