using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class BinLocationRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public BinLocationRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<bool> Create(BinLocation binLocation)
        {
            try
            {
                int nextBinLocationId = _databaseUtility.GetNextAvailableId(binLocation.BinLocationTableName);

                string query = $@"
                        INSERT INTO BinLocation (BinLocationId, Location, InventoryItemId)
                        VALUES ({nextBinLocationId}, '{binLocation.Location}', {binLocation.InventoryItemId})                        
                        ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: BinLocation - Create");
            }
        }

        public async Task<BinLocation> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM BinLocation
                            WHERE BinLocationId = {id}
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<BinLocation> binLocations = new List<BinLocation>();

                foreach (DataRow row in dt.Rows)
                {
                    BinLocation binLocation = new BinLocation
                    {
                        BinLocationId = Convert.ToInt32(row["BinLocationId"]),
                        Location = row["Location"].ToString(),
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"])
                    };
                    binLocations.Add(binLocation);
                }

                return binLocations.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: BinLocation - Get");
            }
        }

        public async Task<IEnumerable<BinLocation>> GetAll()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM BinLocation
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<BinLocation> binLocations = new List<BinLocation>();

                foreach (DataRow row in dt.Rows)
                {
                    BinLocation binLocation = new BinLocation
                    {
                        BinLocationId = Convert.ToInt32(row["BinLocationId"]),
                        Location = row["Location"].ToString(),
                        InventoryItemId = Convert.ToInt32(row["InventoryItemId"])
                    };
                    binLocations.Add(binLocation);
                }

                return binLocations;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: BinLocation - GetAll");
            }
        }

        public async Task<bool> Update(BinLocation binLocation)
        {
            try
            {
                string query = $@"
                            UPDATE BinLocation
                            SET Location = '{binLocation.Location}', InventoryItemId = '{binLocation.InventoryItemId}'
                            WHERE BinLocationId = {binLocation.BinLocationId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: BinLocation - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM BinLocation
                            WHERE BinLocationId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: BinLocation - Delete");
            }
        }
    }
}
