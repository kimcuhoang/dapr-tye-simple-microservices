using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Inventory.Infrastructure.EfCore.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Inventory.Infrastructure.EfCore.UseCases.CreateInventory
{
    public class RequestHandler : IRequestHandler<CreateInventoryRequest, InventoryDto>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestHandler(DbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        #region Implementation of IRequestHandler<in CreateInventoryRequest,InventoryDto>

        public async Task<InventoryDto> Handle(CreateInventoryRequest request, CancellationToken cancellationToken)
        {
            var inventory = Domain.Models.Inventory.Create(request.Name, request.Location);

            var entity = await this._dbContext.Set<Domain.Models.Inventory>().AddAsync(inventory, cancellationToken);

            return this._mapper.Map<InventoryDto>(entity.Entity);
        }

        #endregion
    }
}
