using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.ProductCatalog.Domain.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts
{
    internal class GetProductsRequestHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public GetProductsRequestHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        #region Implementation of IRequestHandler<in GetProductsRequest,IEnumerable<ProductDto>>

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await this._dbContext.Set<Product>()
                .OrderBy(x => x.Name)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var totalOfProducts = await this._dbContext.Set<Product>().CountAsync(cancellationToken: cancellationToken);

            var result = new GetProductsResponse
            {
                Products = products.Select(x => this._mapper.Map<ProductDto>(x)),
                TotalOfProducts = totalOfProducts
            };

            return result;
        }

        #endregion
    }
}
