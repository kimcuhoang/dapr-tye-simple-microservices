using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
using CloudNative.CloudEvents;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

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

        [HttpPost(nameof(ProductCreated))]
        public async Task<IActionResult> ProductCreated(CloudEvent request)
        {
            var createProductRequest = JsonSerializer.Deserialize<CreateProductRequest>(request.Data.ToString(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true
            });

            var result =  await this._mediator.Send(createProductRequest);

            this._logger.LogInformation($"[{nameof(ProductController)}] - Create a new product : {result.ProductId}");

            return Ok();
        }
    }
}