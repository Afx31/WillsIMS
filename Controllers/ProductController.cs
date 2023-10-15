using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;
using System.Net.Http.Headers;

namespace WillsIMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM Product
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

                // Convert DataTable to a list of Product objects
                List<Product> products = new List<Product>();
                foreach (DataRow row in dt.Rows)
                {
                    Product product = new Product
                    {
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        ProductName = row["ProductName"].ToString(),
                        Description = row["Description"].ToString(),
                        Category = Convert.ToInt32(row["Category"]),
                        SupplierId = Convert.ToInt32(row["SupplierId"])
                    };
                    products.Add(product);
                }

                // Return the JSON representation of the products
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: [ " + ex + " ]");
            }
}

        //[Route("SavePhoto")]
        //[HttpPost]
        //public JsonResult SavePhoto()
        //{
        //    try
        //    {
        //        var httpRequest = Request.Form;
        //        var postedFile = httpRequest.Files[0];
        //        string filename = postedFile.FileName;
        //        var physicalPath = _webHostEnv.ContentRootPath + "/Photos/" + filename;

        //        using (var stream = new FileStream(physicalPath, FileMode.Create))
        //            postedFile.CopyTo(stream);

        //        return new JsonResult(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult("Error: " + ex.Message);
        //    }
        //}

        //[HttpPost]
        //public JsonResult Post(Product part)
        //{
        //    try
        //    {
        //        string query = @"
        //                    INSERT INTO dbo.CarPart
        //                    (PartName, CarModel, PhotoFilePath)
        //                    VALUES (@PartName, @CarModel, @PhotoFilePath)
        //                    ";

        //        DataTable dt = new DataTable();
        //        string sqlDataSource = _configuration.GetConnectionString("PlaygroundAppCon");
        //        SqlDataReader myReader;

        //        using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
        //        {
        //            myConnection.Open();

        //            using (SqlCommand myCommand = new SqlCommand(query, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@PartName", part.PartName);
        //                myCommand.Parameters.AddWithValue("@CarModel", part.CarModel);
        //                myCommand.Parameters.AddWithValue("@PhotoFilePath", part.PhotoFilePath);
        //                myReader = myCommand.ExecuteReader();
        //                dt.Load(myReader);
        //                myReader.Close();
        //                myConnection.Close();
        //            }
        //        }

        //        return new JsonResult("Added successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult("Error: " + ex.Message);
        //    }
        //}

        //[HttpPut]
        //public JsonResult Put(Product part)
        //{
        //    try
        //    {
        //        string query = @"
        //                    UPDATE dbo.CarPart
        //                    SET PartName=@PartName,
        //                        CarModel=@CarModel,
        //                        PhotoFilePath=@PhotoFilePath
        //                    WHERE PartId=@PartId
        //                    ";

        //        DataTable dt = new DataTable();
        //        string sqlDataSource = _configuration.GetConnectionString("PlaygroundAppCon");
        //        SqlDataReader myReader;

        //        using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
        //        {
        //            myConnection.Open();

        //            using (SqlCommand myCommand = new SqlCommand(query, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@PartId", part.PartId);
        //                myCommand.Parameters.AddWithValue("@PartName", part.PartName);
        //                myCommand.Parameters.AddWithValue("@CarModel", part.CarModel);
        //                myCommand.Parameters.AddWithValue("@PhotoFilePath", part.PhotoFilePath);
        //                myReader = myCommand.ExecuteReader();
        //                dt.Load(myReader);
        //                myReader.Close();
        //                myConnection.Close();
        //            }
        //        }

        //        return new JsonResult("Updated succesfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult("Error: " + ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    try
        //    {
        //        string query = @"
        //                    DELETE FROM dbo.CarPart
        //                    WHERE PartId=@PartId
        //                    ";

        //        DataTable dt = new DataTable();
        //        string sqlDataSource = _configuration.GetConnectionString("PlaygroundAppCon");
        //        SqlDataReader myReader;

        //        using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
        //        {
        //            myConnection.Open();

        //            using (SqlCommand myCommand = new SqlCommand(query, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@PartId", id);
        //                myReader = myCommand.ExecuteReader();
        //                dt.Load(myReader);
        //                myReader.Close();
        //                myConnection.Close();
        //            }
        //        }

        //        return new JsonResult("Deleted successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult("Error: " + ex.Message);
        //    }
        //}

    }
}
