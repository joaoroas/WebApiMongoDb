using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoDb.Interfaces.Services;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
                _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() 
        {
            List<Product> product = await _productService.GetAsync(); ;

            if (product is null)
                return BadRequest(new { Erro = "No products found" });

            return Ok(product);
        }
    }
}
