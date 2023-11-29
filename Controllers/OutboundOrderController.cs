using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class OutboundOrderController : ControllerBase
    {
        private readonly OutboundOrderRepository _outboundOrderRepository;

        public OutboundOrderController(IDatabaseUtility databaseUtility)
        {
            _outboundOrderRepository = new OutboundOrderRepository(databaseUtility);
        }

        [HttpPost(ApiEndpoints.OutboundOrder.Create)]
        public async Task<IActionResult> Create([FromBody] Models.OutboundOrder outboundOrder)
        {
            try
            {
                var res = await _outboundOrderRepository.Create(outboundOrder);

                if (!res)
                    return BadRequest(); // TODO: Handle this better

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.OutboundOrder.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var outboundOrder = await _outboundOrderRepository.Get(id);

                if (outboundOrder is null)
                    return NotFound();

                return Ok(outboundOrder);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.OutboundOrder.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var outboundOrder = await _outboundOrderRepository.GetAll();
                return Ok(outboundOrder);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpPut(ApiEndpoints.OutboundOrder.Update)]
        public async Task<IActionResult> Update([FromBody] Models.OutboundOrder outboundOrder)
        {
            try
            {
                var res = await _outboundOrderRepository.Update(outboundOrder);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.OutboundOrder.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _outboundOrderRepository.Delete(id);

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
