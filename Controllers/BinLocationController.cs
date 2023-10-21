using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    public class BinLocationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BinLocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ApiEndpoints.BinLocation.GetAll)]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM BinLocation
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
                
                string query2 = @"
                            SELECT *
                            FROM InventoryItemBinLocation
                            ";

                DataTable dt2 = new DataTable();
                string sqlDataSource2 = _configuration.GetConnectionString("DatabaseConnection");
                SqlDataReader myReader2;

                using (SqlConnection myConnection = new SqlConnection(sqlDataSource2))
                {
                    myConnection.Open();

                    using (SqlCommand myCommand = new SqlCommand(query2, myConnection))
                    {
                        myReader2 = myCommand.ExecuteReader();
                        dt2.Load(myReader2);
                        myReader2.Close();
                        myConnection.Close();
                    }
                }

                var temp = dt2.Rows;

                List<BinLocation> binLocations = new List<BinLocation>();

                foreach (DataRow row in dt.Rows)
                {
                    BinLocation binLocation = new BinLocation
                    {
                        BinLocationId = Convert.ToInt32(row["BinLocationId"]),
                        Location = row["Location"].ToString()
                    };
                    binLocations.Add(binLocation);
                }

                return Ok(binLocations);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
        }
    }
}
