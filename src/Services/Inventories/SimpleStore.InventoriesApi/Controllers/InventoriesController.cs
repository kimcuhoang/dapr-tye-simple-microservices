using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories;
using System.Threading.Tasks;

namespace SimpleStore.InventoriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoriesController(IMediator mediator)
            => this._mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> GetInventories(GetInventoriesRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }
    }
}