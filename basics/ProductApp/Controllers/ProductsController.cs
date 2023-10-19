using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger; //readonly :  CTOR,Tanımlandığı yer.
         
        public ProductsController(ILogger<ProductsController> logger)
        {//Newlendiği anda CTOR'dan çıktığımdda logger ifadesinin concmmmMrete hali elimde olacak IoC.
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product(){Id=1, ProductName="Computer"},
                new Product(){Id=2, ProductName="Phone"},
                new Product(){Id=3, ProductName="Mouse"}  
            };
            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            _logger.LogWarning("Product has been created.");
            return StatusCode(201);
        }
    }
}
