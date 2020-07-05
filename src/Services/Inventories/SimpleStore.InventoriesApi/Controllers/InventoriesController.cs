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
        [HttpGet]
        public async Task<IActionResult> GetInventories([FromQuery] GetInventoriesRequest request, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}