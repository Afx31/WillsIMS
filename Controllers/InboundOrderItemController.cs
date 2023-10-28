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

        [HttpGet(ApiEndpoints.InboundOrderItem.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var inboundOrderItems = await _inboundOrderItemRepository.GetAllInboundOrderItems();
                return Ok(inboundOrderItems);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
