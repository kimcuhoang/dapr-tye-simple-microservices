using MediatR;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory
{
    public class CreateInventoryRequest : IRequest<InventoryDto>
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
