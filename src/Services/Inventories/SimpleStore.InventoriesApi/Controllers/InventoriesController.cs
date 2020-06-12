using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories;
using System.Threading.Tasks;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;

namespace SimpleStore.InventoriesApi.Controllers
{
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoriesController(IMediator mediator)
            => this._mediator = mediator;

        [HttpPost("get-inventories")]
        public async Task<IActionResult> GetInventories([FromBody] GetInventoriesRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("add-or-update-product")]
        public async Task<IActionResult> AddOrUpdateProduct([FromBody] AddOrdUpdateProductInventoryRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }
    }
}