using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.ProductCatalog.Domain.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, ProductDto>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateProductHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        #region Implementation of IRequestHandler<in CreateProductRequest,ProductDto>

        public async Task<ProductDto> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.ProductName);

            var entity = await this._dbContext.Set<Product>().AddAsync(product, cancellationToken);

            return this._mapper.Map<ProductDto>(entity.Entity);
        }

        #endregion
    }
}
