using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
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
        public IActionResult Get()
        {
            try
            {
                List<InventoryItem> inventoryItems = _inventoryItemRepository.GetAllInventoryItems();
                return Ok(inventoryItems);
            }
            catch(Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}