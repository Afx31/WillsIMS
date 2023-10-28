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

        public async Task<IEnumerable<InventoryItem>> GetAllInventoryItems()
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
                    await connection.OpenAsync();
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

        public async Task<IEnumerable<InventoryItem>> GetAllInventoryItemsWithBinLocations()
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
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                
                string query2 = @"
                            SELECT *
                            FROM BinLocation
                            ";
                DataTable dt2 = new DataTable();
                SqlDataReader reader2;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        reader2 = command.ExecuteReader();
                        dt2.Load(reader2);
                        reader2.Close();
                        connection.Close();
                    }
                }

                List<BinLocation> binLocations = new List<BinLocation>();
                foreach (DataRow row in dt2.Rows)
                {
                    BinLocation binLocation = new BinLocation
                    {
                        BinLocationId = Convert.ToInt32(row["BinLocationId"]),
                        Location = row["Location"].ToString(),
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"])
                    };
                    binLocations.Add(binLocation);
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

                    inventoryItem.BinLocations = binLocations
                                                            .Where(x => x.InventoryItemId == inventoryItem.InventoryItemId)
                                                            .Select(x => x.Location)
                                                            .ToList();

                    inventoryItems.Add(inventoryItem);
                }

                return inventoryItems;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Exception has occurred in the Inventory Item with Bin Location data operations.");
            }
        }
    }
}
