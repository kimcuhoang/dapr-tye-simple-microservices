using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.ProductCatalog.Domain.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models;
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
        private readonly InventoriesGateway _inventoriesGateway;

        public RequestHandler(DbContext dbContext, IMapper mapper, InventoriesGateway inventoriesGateway)
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

            var inventoriesResponse = await this._inventoriesGateway.GetInventories(new GetInventoriesRequest());

            var inventories = inventoriesResponse?.Inventories;

            var temp = inventoriesResponse?.Inventories?.SelectMany(inventory =>
            {
                return inventory.Products.Select(product => new
                    {
                        ProductId = product.ProductId,
                        Quantity = product.Quantity,
                        CanPurchase = product.CanPurchase,
                        InventoryId = inventory.InventoryId,
                        InventoryName = inventory.Name,
                        InventoryLocation = inventory.Location
                    })
                    .Cast<dynamic>()
                    .ToList();
            }).ToList();

            var temp1 = temp.GroupBy(x => (Guid) x.ProductId)
                .Select(x =>
                {
                    return new
                    {
                        ProductId = x.Key,
                        Inventories = x.DefaultIfEmpty().Select(x => new InventoryDto
                        {
                            InventoryId = x.InventoryId,
                            Location = x.InventoryLocation,
                            Name = x.InventoryName,
                            Quantity = x.Quantity,
                            CanPurchase = x.CanPurchase
                        })
                    };
                }).ToList();

            var inventoriesByProducts = this.InventoriesPerProduct(inventoriesResponse?.Inventories);

            products.ForEach(product =>
            {
                if (inventoriesByProducts != null && inventoriesByProducts.ContainsKey(product.ProductId))
                {
                    product.Inventories = inventoriesByProducts[product.ProductId];
                }
            });

            var result = new GetProductsResponse
            {
                Products = products,
                TotalOfProducts = totalOfProducts
            };

            return result;
        }

        #endregion

        private readonly Func<IEnumerable<Inventory>, Dictionary<Guid, IEnumerable<InventoryDto>>> InventoriesPerProduct 
            = inventories => inventories.SelectMany(inventory =>
                {
                    return inventory.Products.Select(product => new
                        {
                            ProductId = product.ProductId,
                            Quantity = product.Quantity,
                            CanPurchase = product.CanPurchase,
                            InventoryId = inventory.InventoryId,
                            InventoryName = inventory.Name,
                            InventoryLocation = inventory.Location
                        })
                        .Cast<dynamic>()
                        .ToList();
                })
                .GroupBy(x => (Guid) x.ProductId)
                .Select(x =>
                {
                    return new
                    {
                        ProductId = x.Key,
                        Inventories = x.DefaultIfEmpty().Select(x => new InventoryDto
                        {
                            InventoryId = x.InventoryId,
                            Location = x.InventoryLocation,
                            Name = x.InventoryName,
                            Quantity = x.Quantity,
                            CanPurchase = x.CanPurchase
                        })
                    };
                }).ToDictionary(x => x.ProductId, x => x.Inventories);
    }
}
