using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class OutboundOrderItemRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public OutboundOrderItemRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<bool> Create(OutboundOrderItem outboundOrderItem)
        {
            try
            {
                int nextOutboundOrderItemId = _databaseUtility.GetNextAvailableId(outboundOrderItem.OutboundOrderItemTableName);

                string query = $@"
                            INSERT INTO OutboundOrderItem (OutboundOrderItemId, OutboundOrderId, ProductId, Quantity, UnitPrice)
                            VALUES ({nextOutboundOrderItemId}, {outboundOrderItem.OutboundOrderId}, {outboundOrderItem.ProductId}, {outboundOrderItem.Quantity}, '{outboundOrderItem.UnitPrice}')     
                            ";

                var res = await _databaseUtility.QueryDatabase(query);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrderItem - Create");
            }
        }

        public async Task<OutboundOrderItem> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM OutboundOrderItem
                            WHERE OutboundOrderItemId = {id}
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<OutboundOrderItem> outboundOrders = new List<OutboundOrderItem>();

                foreach (DataRow row in dt.Rows)
                {
                    OutboundOrderItem orderItem = new OutboundOrderItem
                    {
                        OutboundOrderItemId = Convert.ToInt32(row["OutboundOrderItemId"]),
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        UnitPrice = Convert.ToDouble(row["UnitPrice"].ToString())
                    };
                    outboundOrders.Add(orderItem);
                }

                return outboundOrders.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrderItem - Get");
            }
        }

        public async Task<IEnumerable<OutboundOrderItem>> GetAll()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM OutboundOrderItem
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<OutboundOrderItem> outboundOrders = new List<OutboundOrderItem>();

                foreach (DataRow row in dt.Rows)
                {
                    OutboundOrderItem orderItem = new OutboundOrderItem
                    {
                        OutboundOrderItemId = Convert.ToInt32(row["OutboundOrderItemId"]),
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        UnitPrice = Convert.ToDouble(row["UnitPrice"].ToString())
                    };
                    outboundOrders.Add(orderItem);
                }

                return outboundOrders;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrderItem - GetAll");
            }
        }

        public async Task<bool> Update(OutboundOrderItem outboundOrderItem)
        {
            try
            {
                string query = $@"
                            UPDATE OutboundOrderItem
                            SET OutboundOrderId = {outboundOrderItem.OutboundOrderId}, ProductId = {outboundOrderItem.ProductId},
                            Quantity = {outboundOrderItem.Quantity}, PurchasePrice = '{outboundOrderItem.UnitPrice}'
                            WHERE OutboundOrderItemId = {outboundOrderItem.OutboundOrderItemId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrderItem - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM OutboundOrderItem
                            WHERE OutboundOrderItemId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrderItem - Delete");
            }
        }
    }
}
