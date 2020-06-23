using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductsRequest request, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
