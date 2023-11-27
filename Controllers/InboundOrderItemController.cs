using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class InboundOrderItemController : ControllerBase
    {
        private readonly InboundOrderItemRepository _inboundOrderItemRepository;

        public InboundOrderItemController(IDatabaseUtility databaseUtility)
        {
            _inboundOrderItemRepository = new InboundOrderItemRepository(databaseUtility);
        }

        [HttpPost(ApiEndpoints.InboundOrderItem.Create)]
        public async Task<IActionResult> Create([FromBody] Models.InboundOrderItem inboundOrderItem)
        {
            try
            {
                var res = await _inboundOrderItemRepository.Create(inboundOrderItem);

                if (!res)
                    return BadRequest(); // TODO: Handle this better

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InboundOrderItem.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var inboundOrderItem = await _inboundOrderItemRepository.Get(id);

                if (inboundOrderItem is null)
                    return NotFound();

                return Ok(inboundOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InboundOrderItem.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var inboundOrderItem = await _inboundOrderItemRepository.GetAll();
                return Ok(inboundOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpPut(ApiEndpoints.InboundOrderItem.Update)]
        public async Task<IActionResult> Update([FromBody] Models.InboundOrderItem inboundOrderItem)
        {
            try
            {
                var res = await _inboundOrderItemRepository.Update(inboundOrderItem);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.InboundOrderItem.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _inboundOrderItemRepository.Delete(id);

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
