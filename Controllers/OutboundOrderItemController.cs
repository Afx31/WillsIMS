using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class OutboundOrderItemController : ControllerBase
    {
        private readonly OutboundOrderItemRepository _outboundOrderItemRepository;

        public OutboundOrderItemController(IDatabaseUtility databaseUtility)
        {
            _outboundOrderItemRepository = new OutboundOrderItemRepository(databaseUtility);
        }

        [HttpPost(ApiEndpoints.OutboundOrderItem.Create)]
        public async Task<IActionResult> Create([FromBody] Models.OutboundOrderItem outboundOrderItem)
        {
            try
            {
                var res = await _outboundOrderItemRepository.Create(outboundOrderItem);

                if (!res)
                    return BadRequest(); // TODO: Handle this better

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.OutboundOrderItem.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var outboundOrderItem = await _outboundOrderItemRepository.Get(id);

                if (outboundOrderItem is null)
                    return NotFound();

                return Ok(outboundOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.OutboundOrderItem.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var outboundOrderItem = await _outboundOrderItemRepository.GetAll();
                return Ok(outboundOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpPut(ApiEndpoints.OutboundOrderItem.Update)]
        public async Task<IActionResult> Update([FromBody] Models.OutboundOrderItem outboundOrderItem)
        {
            try
            {
                var res = await _outboundOrderItemRepository.Update(outboundOrderItem);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.OutboundOrderItem.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _outboundOrderItemRepository.Delete(id);

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
