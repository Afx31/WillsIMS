using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class InboundOrderController : ControllerBase
    {
        private readonly InboundOrderRepository _inboundOrderRepository;

        public InboundOrderController(IDatabaseUtility databaseUtility)
        {
            _inboundOrderRepository = new InboundOrderRepository(databaseUtility);
        }

        [HttpPost(ApiEndpoints.InboundOrder.Create)]
        public async Task<IActionResult> Create([FromBody] Models.InboundOrder inboundOrder)
        {
            try
            {
                var res = await _inboundOrderRepository.Create(inboundOrder);

                if (!res)
                    return BadRequest(); // TODO: Handle this better

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InboundOrder.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var inboundOrder = await _inboundOrderRepository.Get(id);

                if (inboundOrder is null)
                    return NotFound();

                return Ok(inboundOrder);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.InboundOrder.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var inboundOrders = await _inboundOrderRepository.GetAll();
                return Ok(inboundOrders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpPut(ApiEndpoints.InboundOrder.Update)]
        public async Task<IActionResult> Update([FromBody] Models.InboundOrder inboundOrder)
        {
            try
            {
                var res = await _inboundOrderRepository.Update(inboundOrder);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.InboundOrder.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _inboundOrderRepository.Delete(id);

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
