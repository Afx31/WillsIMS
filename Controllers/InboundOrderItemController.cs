using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    public class InboundOrderItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public InboundOrderItemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.InboundOrderItem.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InboundOrderItem
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

                List<InboundOrderItem> inboundOrderItems = new List<InboundOrderItem>();

                foreach (DataRow row in dt.Rows)
                {
                    InboundOrderItem item = new InboundOrderItem
                    {
                        InboundOrderItemId = Convert.ToInt32(row["InboundOrderItemId"]),
                        InboundOrderId = Convert.ToInt32(row["InboundOrderId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        PurchasePrice = Convert.ToDouble(row["PurchasePrice"].ToString())
                    };
                    inboundOrderItems.Add(item);
                }

                return Ok(inboundOrderItems);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
