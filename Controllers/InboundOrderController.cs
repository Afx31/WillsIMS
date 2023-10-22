using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    public class InboundOrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly InboundOrderRepository _inboundOrderRepository;

        public InboundOrderController(IConfiguration configuration)
        {
            _configuration = configuration;
            _inboundOrderRepository = new InboundOrderRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.InboundOrder.GetAll)]
        public IActionResult Get()
        {
            try
            {
                List<InboundOrder> inboundOrders = _inboundOrderRepository.GetAllInboundOrders();
                return Ok(inboundOrders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
