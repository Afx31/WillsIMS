using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class InboundOrderRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public InboundOrderRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<bool> Create(InboundOrder inboundOrder)
        {
            try
            {
                int nextInventoryItemId = _databaseUtility.GetNextAvailableId(inboundOrder.InboundOrderTableName);

                string query = $@"
                        INSERT INTO InboundOrder (InboundOrderId, Company, PurchaseDate)
                        VALUES ({nextInventoryItemId}, {inboundOrder.CompanyId}, '{inboundOrder.PurchaseDate}')     
                        ";

                var res = await _databaseUtility.QueryDatabase(query);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrder - Create");
            }
        }

        public async Task<InboundOrder> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM InboundOrder
                            WHERE InboundOrderId = {id}
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<InboundOrder> inboundOrders = new List<InboundOrder>();

                foreach (DataRow row in dt.Rows)
                {
                    InboundOrder order = new InboundOrder
                    {
                        InboundOrderId = Convert.ToInt32(row["InboundOrderId"]),
                        CompanyId = Convert.ToInt32(row["CompanyId"]),
                        PurchaseDate = (DateTime)row["PurchaseDate"]
                    };
                    inboundOrders.Add(order);
                }

                return inboundOrders.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrder - Get");
            }
        }

        public async Task<IEnumerable<InboundOrder>> GetAll()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InboundOrder
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<InboundOrder> inboundOrders = new List<InboundOrder>();

                foreach (DataRow row in dt.Rows)
                {
                    InboundOrder order = new InboundOrder
                    {
                        InboundOrderId = Convert.ToInt32(row["InboundOrderId"]),
                        CompanyId = Convert.ToInt32(row["CompanyId"]),
                        PurchaseDate = (DateTime)row["PurchaseDate"]
                    };
                    inboundOrders.Add(order);
                }

                return inboundOrders;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrder - GetAll");
            }
        }

        public async Task<bool> Update(InboundOrder inboundOrder)
        {
            try
            {
                string query = $@"
                            UPDATE InboundOrder
                            SET CompanyId = {inboundOrder.CompanyId}, PurchaseDate = '{inboundOrder.PurchaseDate}'
                            WHERE InboundOrderId = {inboundOrder.InboundOrderId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrder - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM InboundOrder
                            WHERE InboundOrderId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrder - Delete");
            }
        }
    }
}
