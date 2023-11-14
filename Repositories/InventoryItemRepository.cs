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

        public async Task<bool> Create(InventoryItem inventoryItem)
        {
            try
            {
                int nextInventoryItemId = _databaseUtility.GetNextAvailableId(inventoryItem.InventoryItemTableName);

                string query = $@"
                        INSERT INTO InventoryItem (InventoryItemId, ProductId, CurrentStockQuantity, MinStockThreshold, ReorderPoint)
                        VALUES ({nextInventoryItemId}, {inventoryItem.ProductId}, {inventoryItem.CurrentStockQuantity}, {inventoryItem.MinStockThreshold}, {inventoryItem.ReorderPoint})
                        ";
                var res = await _databaseUtility.QueryDatabase(query);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InventoryItem - Create");
            }
        }

        public async Task<InventoryItem> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM InventoryItem
                            WHERE InventoryItemId = {id}
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

                return inventoryItems.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InventoryItem - Get");
            }
        }

        public async Task<IEnumerable<InventoryItem>> GetAll()
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
                throw new NotImplementedException("ERROR: InventoryItem - GetAll");
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

        public async Task<bool> Update(InventoryItem inventoryItem)
        {
            try
            {
                string query = $@"
                            UPDATE InventoryItem
                            SET InventoryItemId = {inventoryItem.InventoryItemId}, CurrentStockQuantity = {inventoryItem.CurrentStockQuantity},
                            MinStockThreshold = {inventoryItem.MinStockThreshold}, ReorderPoint = {inventoryItem.ReorderPoint}
                            WHERE InventoryItemId = {inventoryItem.InventoryItemId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InventoryItem - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM InventoryItem
                            WHERE InventoryItemId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InventoryItem - Delete");
            }
        }
    }
}
