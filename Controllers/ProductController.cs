using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(IDatabaseUtility databaseUtility)
        {
            _productRepository = new ProductRepository(databaseUtility);
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