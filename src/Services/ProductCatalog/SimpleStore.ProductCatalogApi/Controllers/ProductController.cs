using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.ProductCatalog.Domain.Models;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public ProductController(DbContext dbContext)
            => this._dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await this._dbContext.Set<Product>().ToListAsync();

            return Ok(products);
        }
    }
}