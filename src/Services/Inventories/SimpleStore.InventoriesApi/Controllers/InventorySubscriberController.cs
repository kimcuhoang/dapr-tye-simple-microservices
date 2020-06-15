using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;
using System.Threading.Tasks;

namespace SimpleStore.InventoriesApi.Controllers
{
    [ApiController]
    public class InventorySubscriberController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InventorySubscriberController> _logger;

        public InventorySubscriberController(IMediator mediator, ILogger<InventorySubscriberController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [Topic("ProductCreated")]
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
        {
            this._logger.LogInformation($"Received Product - {request.ProductId}");

            var result =  await this._mediator.Send(request);

            this._logger.LogInformation($"[{nameof(InventorySubscriberController)}] - Create a new product : {result.ProductId}");

            return Ok();
        }
    }
}