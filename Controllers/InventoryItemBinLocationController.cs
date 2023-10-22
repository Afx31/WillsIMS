using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    public class InventoryItemBinLocationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly InventoryItemRepository _inventoryItemBinLocationRepository;

        public InventoryItemBinLocationController(IConfiguration configuration)
        {
            _configuration = configuration;
            _inventoryItemBinLocationRepository = new InventoryItemRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.InventoryItemBinLocation.GetAll)]
        public IActionResult Get()
        {
            try
            {
                List<InventoryItem> inventoryItemBinLocations = _inventoryItemBinLocationRepository.GetAllInventoryItemBinLocations();
                return Ok(inventoryItemBinLocations);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
