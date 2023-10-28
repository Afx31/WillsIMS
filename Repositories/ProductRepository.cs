using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class ProductRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public ProductRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM Product
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);            
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
