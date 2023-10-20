using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class OutboundOrderItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public OutboundOrderItemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.OutboundOrderItem.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM OutboundOrderItem
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

                List<OutboundOrderItem> orderItems = new List<OutboundOrderItem>();

                foreach (DataRow row in dt.Rows)
                {
                    OutboundOrderItem orderItem = new OutboundOrderItem
                    {
                        OutboundOrderItemId = Convert.ToInt32(row["OutboundOrderItemId"]),
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        UnitPrice = Convert.ToDouble(row["UnitPrice"].ToString())
                    };
                    orderItems.Add(orderItem);
                }

                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
