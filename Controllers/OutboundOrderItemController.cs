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

        [HttpGet(ApiEndpoints.OutboundOrderItem.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var outboundOrderItems = await _outboundOrderItemRepository.GetAllOutboundOrderItems();
                return Ok(outboundOrderItems);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
