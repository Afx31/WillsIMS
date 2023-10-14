using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            string query = @"
                            SELECT PartId, PartName, CarModel, PhotoFilePath
                            FROM dbo.CarPart
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

            foreach (DataRow row in dt.Rows)
            {
                int partId = (int)row["PartId"];
                string partName = (string)row["PartName"];
                string carModel = (string)row["CarModel"];
                string photoFilePath = (string)row["PhotoFilePath"];
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }        
    }
}