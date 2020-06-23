using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory;
using System.Threading.Tasks;

namespace SimpleStore.InventoriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator) => this._mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryRequest request)
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
