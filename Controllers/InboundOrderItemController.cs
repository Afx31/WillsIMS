using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    public class InboundOrderItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly InboundOrderItemRepository _inboundOrderItemRepository;

        public InboundOrderItemController(IConfiguration configuration)
        {
            _configuration = configuration;
            _inboundOrderItemRepository = new InboundOrderItemRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.InboundOrderItem.GetAll)]
        public IActionResult Get()
        {
            try
            {
                List<InboundOrderItem> inboundOrderItems = _inboundOrderItemRepository.GetAllInboundOrderItems();
                return Ok(inboundOrderItems);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
