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

        [HttpGet(ApiEndpoints.OutboundOrder.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var outboundOrders = await _outboundOrderRepository.GetAllOutboundOrders();
                return Ok(outboundOrders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
