using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly InventoryItemRepository _inventoryItemRepository;

        public InventoryItemController(IConfiguration configuration)
        {
            _configuration = configuration;
            _inventoryItemRepository = new InventoryItemRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.InventoryItem.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var inventoryItems = await _inventoryItemRepository.GetAllInventoryItems();
                return Ok(inventoryItems);
            }
            catch(Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InventoryItem.GetAllWithBinLocations)]
        public async Task<IActionResult> GetAllWithBinLocations()
        {
            try
            {
                var inventoryItems = await _inventoryItemRepository.GetAllInventoryItemsWithBinLocations();
                return Ok(inventoryItems);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}