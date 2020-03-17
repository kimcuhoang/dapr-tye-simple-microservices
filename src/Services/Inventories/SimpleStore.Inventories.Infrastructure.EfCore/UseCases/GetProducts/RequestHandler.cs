using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Inventories.Domain.Models;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts
{
    public class RequestHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        #region Implementation of IRequestHandler<in GetProductsRequest,GetProductsResponse>

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = this._dbContext.Set<Product>();

            var totalOfProducts = await query.CountAsync(cancellationToken);

            var products = await query.AsNoTracking()
                .OrderBy(x => x.Code)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(x => x.Inventories)
                .ThenInclude(x => x.Inventory)
                .ProjectTo<ProductDto>(this._mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var result = new GetProductsResponse
            {
                Products = products,
                TotalOfProducts = totalOfProducts
            };

            return result;
        }

        #endregion
    }
}
