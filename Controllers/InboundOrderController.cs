using Microsoft.AspNetCore.Mvc;
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
