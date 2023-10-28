using Microsoft.AspNetCore.Mvc;
using WillsIMS.Repositories;
using WillsIMS.Utilities;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyController(IDatabaseUtility databaseUtility)
        {
            _companyRepository = new CompanyRepository(databaseUtility);
        }

        [HttpGet(ApiEndpoints.Company.GetAll)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companies = await _companyRepository.GetAllCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
