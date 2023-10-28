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

        [HttpGet(ApiEndpoints.InboundOrder.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var inboundOrders = await _inboundOrderRepository.GetAllInboundOrders();
                return Ok(inboundOrders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
