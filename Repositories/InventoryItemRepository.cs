using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class InventoryItemRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public InventoryItemRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllInventoryItems()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InventoryItem
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
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
                string queryInventoryItem = @"
                            SELECT *
                            FROM InventoryItem
                            ";
                string queryBinLocation = @"
                            SELECT *
                            FROM BinLocation
                            ";
                DataTable dtInventoryItem = await _databaseUtility.QueryDatabase(queryInventoryItem);
                DataTable dtBinLocation = await _databaseUtility.QueryDatabase(queryBinLocation);

                List<BinLocation> binLocations = new List<BinLocation>();
                foreach (DataRow row in dtBinLocation.Rows)
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
                foreach (DataRow row in dtInventoryItem.Rows)
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
