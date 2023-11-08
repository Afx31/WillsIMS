using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class BinLocationController : ControllerBase
    {
        private readonly BinLocationRepository _binLocationRepository;

        public BinLocationController(IDatabaseUtility databaseUtility)
        {
            _binLocationRepository = new BinLocationRepository(databaseUtility);
        }

        [HttpPost(ApiEndpoints.BinLocation.Create)]
        public async Task<IActionResult> Create([FromBody] Models.BinLocation binLocation)
        {
            try
            {
                var res = await _binLocationRepository.Create(binLocation);

                if (!res)
                    return BadRequest(); // TODO: Handle this better

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.BinLocation.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var binLocation = await _binLocationRepository.Get(id);

                if (binLocation is null)
                    return NotFound();

                return Ok(binLocation);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.BinLocation.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var binLocation = await _binLocationRepository.GetAll();
                return Ok(binLocation);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpPut(ApiEndpoints.BinLocation.Update)]
        public async Task<IActionResult> Update([FromBody] Models.BinLocation binLocation)
        {
            try
            {
                var res = await _binLocationRepository.Update(binLocation);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.BinLocation.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _binLocationRepository.Delete(id);

                if (!res)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
