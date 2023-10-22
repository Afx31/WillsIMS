using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class InventoryItemRepository
    {
        private readonly string _connectionString;

        public InventoryItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<InventoryItem> GetAllInventoryItems()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InventoryItem
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

                List<InventoryItem> inventoryItems = new List<InventoryItem>();

                foreach (DataRow row in dt.Rows)
                {
                    InventoryItem inventoryItem = new InventoryItem
                    {
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        CurrentStockQuantity = Convert.ToInt32(row["CurrentStockQuantity"]),
                        MinStockThreshold = Convert.ToInt32(row["MinStockThreshold"]),
                        ReorderPoint = Convert.ToInt32(row["ReorderPoint"])
                    };
                    inventoryItems.Add(inventoryItem);
                }

                return inventoryItems;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Exception has occurred in the Inventory Item data operations.");
            }
        }
    }
}
