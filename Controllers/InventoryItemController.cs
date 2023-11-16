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

        [HttpPost(ApiEndpoints.InventoryItem.Create)]
        public async Task<IActionResult> Create([FromBody] Models.InventoryItem inventoryItem)
        {
            try
            {
                var res = await _inventoryItemRepository.Create(inventoryItem);

                if (!res)
                    return BadRequest(); // TODO: Handle this better

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InventoryItem.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var inventoryItem = await _inventoryItemRepository.Get(id);

                if (inventoryItem is null)
                    return NotFound();

                return Ok(inventoryItem);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InventoryItem.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var inventoryItems = await _inventoryItemRepository.GetAll();
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

        [HttpPut(ApiEndpoints.InventoryItem.Update)]
        public async Task<IActionResult> Update([FromBody] Models.InventoryItem inventoryItem)
        {
            try
            {
                var res = await _inventoryItemRepository.Update(inventoryItem);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.InventoryItem.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _inventoryItemRepository.Delete(id);

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