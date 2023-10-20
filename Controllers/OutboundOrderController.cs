using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class OutboundOrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public OutboundOrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.OutboundOrder.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM OutboundOrder
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

                List<OutboundOrder> orders = new List<OutboundOrder>();

                foreach (DataRow row in dt.Rows)
                {
                    OutboundOrder order = new OutboundOrder
                    {
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        OrderDate = (DateTime)row["OrderDate"]
                    };
                    orders.Add(order);
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
