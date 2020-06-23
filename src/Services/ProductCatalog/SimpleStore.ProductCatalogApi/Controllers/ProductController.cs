using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
