using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
using WillsIMS.Repositories;
using WillsIMS.Utilities;
using static WillsIMS.ApiEndpoints;

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

        [HttpPut(ApiEndpoints.Company.Update)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Models.Company company)
        {
            try
            {
                if (id != company.CompanyId.ToString())
                    return BadRequest("Company Id mismatch");

                var updatedCompany = await _companyRepository.UpdateCompany(id, company);

                if (updatedCompany == null)
                    return NotFound();

                return Ok(updatedCompany);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }

        [HttpDelete(ApiEndpoints.Company.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var deletedCompany = await _companyRepository.DeleteCompany(id);

                if (!deletedCompany)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
