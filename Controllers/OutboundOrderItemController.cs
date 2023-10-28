﻿using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class OutboundOrderItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly OutboundOrderItemRepository _outboundOrderItemRepository;

        public OutboundOrderItemController(IConfiguration configuration)
        {
            _configuration = configuration;
            _outboundOrderItemRepository = new OutboundOrderItemRepository(_configuration.GetConnectionString("DatabaseConnection"));
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
