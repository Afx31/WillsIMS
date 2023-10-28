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

        public async Task<IEnumerable<OutboundOrderItem>> GetAllOutboundOrderItems()
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
                throw new NotImplementedException("Exception has occurred in the Outbound Order Item data operations.");
            }
        }
    }
}
