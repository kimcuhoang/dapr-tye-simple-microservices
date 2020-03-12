using MediatR;
using SimpleStore.Inventory.Infrastructure.EfCore.Dto;

namespace SimpleStore.Inventory.Infrastructure.EfCore.UseCases.CreateInventory
{
    public class CreateInventoryRequest : IRequest<InventoryDto>
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
