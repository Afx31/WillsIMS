using System.Data;
using System.Data.SqlClient;

namespace WillsIMS.Utilities
{
    public class DatabaseUtility : IDatabaseUtility
    {
        private readonly IConfiguration _configuration;
        public DatabaseUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DataTable> QueryDatabase(string query)
        {
            try
            {
                DataTable dataTable = new DataTable();
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        dataTable.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Database Utility");
            }
        }
    }
}
