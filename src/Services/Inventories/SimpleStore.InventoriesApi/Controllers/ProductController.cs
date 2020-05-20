using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;
using System.Threading.Tasks;

namespace SimpleStore.InventoriesApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [Topic("ProductCreated")]
        [HttpPost("ProductCreated")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
        {
            var result =  await this._mediator.Send(request);

            this._logger.LogInformation($"[{nameof(ProductController)}] - Create a new product : {result.ProductId}");

            return Ok();
        }
    }
}