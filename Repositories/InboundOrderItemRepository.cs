using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class InboundOrderItemRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public InboundOrderItemRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<bool> Create(InboundOrderItem inboundOrderItem)
        {
            try
            {
                int nextInventoryItemId = _databaseUtility.GetNextAvailableId(inboundOrderItem.InboundOrderItemTableName);

                string query = $@"
                        INSERT INTO InboundOrderItem (InboundOrderItemId, InboundOrderId, ProductId, Quantity, PurchasePrice)
                        VALUES ({nextInventoryItemId}, {inboundOrderItem.InboundOrderId}, {inboundOrderItem.ProductId}, {inboundOrderItem.Quantity}, {inboundOrderItem.PurchasePrice})     
                        ";

                var res = await _databaseUtility.QueryDatabase(query);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrderItem - Create");
            }
        }

        public async Task<InboundOrderItem> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM InboundOrderItem
                            WHERE InboundOrderItemId = {id}
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<InboundOrderItem> inboundOrderItems = new List<InboundOrderItem>();

                foreach (DataRow row in dt.Rows)
                {
                    InboundOrderItem orderItem = new InboundOrderItem
                    {
                        InboundOrderItemId = Convert.ToInt32(row["InboundOrderItemId"]),
                        InboundOrderId = Convert.ToInt32(row["InboundOrderId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        PurchasePrice = Convert.ToDouble(row["PurchasePrice"].ToString())
                    };
                    inboundOrderItems.Add(orderItem);
                }

                return inboundOrderItems.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrderItem - Get");
            }
        }

        public async Task<IEnumerable<InboundOrderItem>> GetAll()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InboundOrderItem
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<InboundOrderItem> inboundOrderItems = new List<InboundOrderItem>();

                foreach (DataRow row in dt.Rows)
                {
                    InboundOrderItem orderItem = new InboundOrderItem
                    {
                        InboundOrderItemId = Convert.ToInt32(row["InboundOrderItemId"]),
                        InboundOrderId = Convert.ToInt32(row["InboundOrderId"]),
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        PurchasePrice = Convert.ToDouble(row["PurchasePrice"].ToString())
                    };
                    inboundOrderItems.Add(orderItem);
                }

                return inboundOrderItems;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrderItem - GetAll");
            }
        }

        public async Task<bool> Update(InboundOrderItem inboundOrderItem)
        {
            try
            {
                string query = $@"
                            UPDATE InboundOrderItem
                            SET InboundOrderId = {inboundOrderItem.InboundOrderId}, ProductId = {inboundOrderItem.ProductId},
                            Quantity = {inboundOrderItem.Quantity}, PurchasePrice = {inboundOrderItem.PurchasePrice}
                            WHERE InventoryItemId = {inboundOrderItem.InboundOrderItemId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrderItem - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM InboundOrderItem
                            WHERE InboundOrderItemId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: InboundOrderItem - Delete");
            }
        }
    }
}
