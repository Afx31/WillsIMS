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

        [HttpGet(ApiEndpoints.Company.Get)]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            try
            {
                var company = await _companyRepository.GetCompany(id);

                if (company is null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpGet(ApiEndpoints.Company.GetAll)]
        public async Task<IActionResult> GetAll()
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
