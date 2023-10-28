using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ProductRepository _productRepository;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _productRepository = new ProductRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.Product.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}