using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class OutboundOrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly OutboundOrderRepository _outboundOrderRepository;

        public OutboundOrderController(IConfiguration configuration)
        {
            _configuration = configuration;
            _outboundOrderRepository = new OutboundOrderRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.OutboundOrder.GetAll)]
        public IActionResult Get()
        {
            try
            {
                List<OutboundOrder> outboundOrders = _outboundOrderRepository.GetAllOutboundOrders();
                return Ok(outboundOrders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
