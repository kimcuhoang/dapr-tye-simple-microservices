using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.ProductCatalog.Domain.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProductsByIds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts
{
    internal class RequestHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DaprInventoriesGateway _inventoriesGateway;

        public RequestHandler(DbContext dbContext, IMapper mapper, DaprInventoriesGateway inventoriesGateway)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._inventoriesGateway = inventoriesGateway ?? throw new ArgumentNullException(nameof(inventoriesGateway));
        }

        #region Implementation of IRequestHandler<in GetProductsRequest,IEnumerable<ProductDto>>

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await this._dbContext.Set<Product>()
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<ProductDto>(this._mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var totalOfProducts = await this._dbContext.Set<Product>().CountAsync(cancellationToken: cancellationToken);

            var getProductsByIdsRequest = new GetProductsByIdsRequest
            {
                ProductIds = products.Select(x => x.ProductId)
            };
            var productsFromInventories = await this._inventoriesGateway.GetProductsByIds(getProductsByIdsRequest, cancellationToken);

            foreach (var productInventory in productsFromInventories.Products)
            {
                var product = products.FirstOrDefault(x => x.ProductId == productInventory.Id);
                if (product != null)
                {
                    product.Inventories = productInventory.Inventories?.Select(x => new InventoryDto
                    {
                        Name = x.Name,
                        Location = x.Location,
                        Quantity = x.Quantity,
                        CanPurchase = x.CanPurchase,
                        InventoryId = x.InventoryId
                    });
                }
            }

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
