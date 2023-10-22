using Microsoft.AspNetCore.Mvc;
using WillsIMS.Models;
using WillsIMS.Repositories;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CompanyRepository _companyRepository;

        public CompanyController(IConfiguration configuration)
        {
            _configuration = configuration;
            _companyRepository = new CompanyRepository(_configuration.GetConnectionString("DatabaseConnection"));
        }

        [HttpGet(ApiEndpoints.Company.GetAll)]
        public IActionResult Get()
        {
            try
            {
                List<Company> companies = _companyRepository.GetAllCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
