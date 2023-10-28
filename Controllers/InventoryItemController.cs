using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly InventoryItemRepository _inventoryItemRepository;

        public InventoryItemController(IDatabaseUtility databaseUtility)
        {
            _inventoryItemRepository = new InventoryItemRepository(databaseUtility);
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