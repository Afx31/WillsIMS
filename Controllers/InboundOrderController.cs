using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    public class InboundOrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public InboundOrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.InboundOrder.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InboundOrder
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

                List<InboundOrder> inboundOrders = new List<InboundOrder>();

                foreach (DataRow row in dt.Rows)
                {
                    InboundOrder order = new InboundOrder
                    {
                        InboundOrderId = Convert.ToInt32(row["InboundOrderId"]),
                        CompanyId = Convert.ToInt32(row["CompanyId"]),
                        PurchaseDate = (DateTime)row["PurchaseDate"]
                    };
                    inboundOrders.Add(order);
                }

                return Ok(inboundOrders);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
