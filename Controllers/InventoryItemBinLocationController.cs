using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    public class InventoryItemBinLocationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public InventoryItemBinLocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.InventoryItemBinLocation.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InventoryItemBinLocation
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


                List<InventoryItemBinLocation> inventoryItemBinLocations = new List<InventoryItemBinLocation>();

                foreach (DataRow row in dt.Rows)
                {
                    InventoryItemBinLocation inventoryItemBinLocation = new InventoryItemBinLocation
                    {
                        InventoryItemBinLocationId = Convert.ToInt32(row["InventoryItemBinLocationId"]),
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"]),
                        BinLocationId = Convert.ToInt32(row["BinLocationId"])
                    };

                    //inventoryItemBinLocation.InventoryItem = GetInventoryItem(inventoryItemBinLocation.InventoryItemId);
                    //inventoryItemBinLocation.BinLocation = GetBinLocation(inventoryItemBinLocation.BinLocationId);

                    inventoryItemBinLocations.Add(inventoryItemBinLocation);
                }

                return Ok(inventoryItemBinLocations);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
