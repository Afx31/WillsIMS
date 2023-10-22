using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM Product
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
            
                List<Product> products = new List<Product>();
                foreach (DataRow row in dt.Rows)
                {
                    Product product = new Product
                    {
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString(),
                        Category = Convert.ToInt32(row["Category"]),
                        SupplierId = Convert.ToInt32(row["SupplierId"])
                    };
                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Exception has occurred in the Product data operations.");
            }
        }
    }
}
