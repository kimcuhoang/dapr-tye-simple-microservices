using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Inventories.Domain.Models;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories
{
    public class RequestHandler : IRequestHandler<GetInventoriesRequest, GetInventoriesResponse>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        #region Implementation of IRequestHandler<in GetInventoriesRequest,GetInventoriesResponse>

        public async Task<GetInventoriesResponse> Handle(GetInventoriesRequest request, CancellationToken cancellationToken)
        {
            var query = this._dbContext.Set<Inventory>();

            var totalOfInventories = await query.CountAsync(cancellationToken);

            var inventories = await query.AsNoTracking()
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .OrderBy(x => x.Name)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var inventoryDtos = inventories.Select(x => this._mapper.Map<InventoryDto>(x));

            return new GetInventoriesResponse
            {
                Inventories = inventoryDtos,
                TotalRecords = totalOfInventories
            };
        }

        #endregion
    }
}
