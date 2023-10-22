using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class CompanyRepository
    {
        private readonly string _connectionString;

        public CompanyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Company> GetAllCompanies()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM Company
                            ";

                DataTable dt = new DataTable();
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }

                List<Company> companies = new List<Company>();

                foreach (DataRow row in dt.Rows)
                {
                    Company company = new Company
                    {
                        CompanyId = Convert.ToInt32(row["CompanyId"]),
                        Name = row["Name"].ToString(),
                        Email = row["Email"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString()
                    };
                    companies.Add(company);
                }

                return companies;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Exception has occurred in the Company data operations.");
            }
        }
    }
}
