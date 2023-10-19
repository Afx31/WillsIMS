using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.Customer.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM Customer
                            ";

                DataTable dt = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DatabaseConnection");
                SqlDataReader myReader;

                using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
                {
                    myConnection.Open();

                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        myReader = myCommand.ExecuteReader();
                        dt.Load(myReader);
                        myReader.Close();
                        myConnection.Close();
                    }
                }

                List<Customer> customers = new List<Customer>();

                foreach (DataRow row in dt.Rows)
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Email = row["Email"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString()
                    };
                    customers.Add(customer);
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
