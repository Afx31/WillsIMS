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

        [HttpPost(ApiEndpoints.Product.Create)]
        public async Task<IActionResult> Create([FromBody] Models.Product product)
        {
            var res = await _productRepository.Create(product);

            if (!res)
                return BadRequest(); // TODO: Handle this better

            return Ok();
        }

        [HttpGet(ApiEndpoints.Product.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var product = await _productRepository.Get(id);

                if (product is null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.Product.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productRepository.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpPut(ApiEndpoints.Product.Update)]
        public async Task<IActionResult> Update([FromBody] Models.Product product)
        {
            try
            {
                var res = await _productRepository.Update(product);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.Product.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _productRepository.Delete(id);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}