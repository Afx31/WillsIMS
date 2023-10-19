using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public InventoryItemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.InventoryItem.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InventoryItem
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

                List<InventoryItem> inventoryItems = new List<InventoryItem>();

                foreach (DataRow row in dt.Rows)
                {
                    InventoryItem inventoryItem = new InventoryItem
                    {
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        CurrentStockQuantity = Convert.ToInt32(row["CurrentStockQuantity"]),
                        MinStockThreshold = Convert.ToInt32(row["MinStockThreshold"]),
                        ReorderPoint = Convert.ToInt32(row["ReorderPoint"]),
                        WarehouseLocation = row["WarehouseLocation"].ToString()
                    };
                    inventoryItems.Add(inventoryItem);
                }

                return Ok(inventoryItems);
            }
            catch(Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}