using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class InventoryItemBinLocationRepository
    {
        private readonly string _connectionString;

        public InventoryItemBinLocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<InventoryItemBinLocation> GetAllInventoryItemBinLocations()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InventoryItemBinLocation
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

                List<InventoryItemBinLocation> inventoryItemBinLocations = new List<InventoryItemBinLocation>();

                foreach (DataRow row in dt.Rows)
                {
                    InventoryItemBinLocation inventoryItemBinLocation = new InventoryItemBinLocation
                    {
                        InventoryItemBinLocationId = Convert.ToInt32(row["InventoryItemBinLocationId"]),
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"]),
                        BinLocationId = Convert.ToInt32(row["BinLocationId"])
                    };

                    //inventoryItemBinLocation.InventoryItem = GetInventoryItem(inventoryItemBinLocation.InventoryItemId);
                    //inventoryItemBinLocation.BinLocation = GetBinLocation(inventoryItemBinLocation.BinLocationId);

                    inventoryItemBinLocations.Add(inventoryItemBinLocation);
                }

                return inventoryItemBinLocations;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Exception has occurred in the Inventory Item Bin Location data operations.");
            }
        }
    }
}
