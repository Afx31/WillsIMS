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

        public async Task<bool> Create(Product product)
        {
            try
            {
                int nextProductId = _databaseUtility.GetNextAvailableId(product.ProductTableName);

                string query = $@"
                        INSERT INTO Product (ProductId, Name, Description, Category, SupplierId)
                        VALUES ({nextProductId}, '{product.Name}', '{product.Description}', {product.Category}, {product.SupplierId})
                        ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Product - Create");
            }
        }

        public async Task<Product> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM Product
                            WHERE ProductId = {id}
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

                return products.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Product - Get");
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
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
                throw new NotImplementedException("ERROR: Product - GetAll");
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                string query = $@"
                            UPDATE Product
                            SET Name = '{product.Name}', Description = '{product.Description}',
                            Category = {product.Category}, SupplierId = '{product.SupplierId}'
                            WHERE ProductId = {product.ProductId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Product - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM Product
                            WHERE ProductId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Product - Delete");
            }
        }
    }
}
