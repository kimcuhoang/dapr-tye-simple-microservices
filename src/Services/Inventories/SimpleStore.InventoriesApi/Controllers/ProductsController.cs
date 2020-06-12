using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds;
using System.Threading.Tasks;

namespace SimpleStore.InventoriesApi.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
            => this._mediator = mediator;

        [HttpPost("get-products")]
        public async Task<IActionResult> GetProducts([FromBody] GetProductsRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("get-products-by-ids")]
        public async Task<IActionResult> GetProductsByIds([FromBody] GetProductsByIdsRequest request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }
    }
}