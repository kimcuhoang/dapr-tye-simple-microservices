using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds;
using System.Threading.Tasks;

namespace SimpleStore.InventoriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => this._mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("get-by-ids")]
        public async Task<IActionResult> GetProductsByIds([FromBody] GetProductsByIdsRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }
    }
}