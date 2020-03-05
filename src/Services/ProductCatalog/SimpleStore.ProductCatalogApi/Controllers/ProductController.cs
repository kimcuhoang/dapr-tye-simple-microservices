using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.ProductCatalog.Domain.Models;
using System.Threading.Tasks;
using MediatR;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbContext _dbContext;
        private readonly IMediator _mediator;

        public ProductController(DbContext dbContext, IMediator mediator)
        {
            this._dbContext = dbContext;
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await this._dbContext.Set<Product>().ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request)
        {
            await this._mediator.Send(request);
            return Ok();
        }
    }
}