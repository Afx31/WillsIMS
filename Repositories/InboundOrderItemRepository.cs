using System.Data.SqlClient;
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

        public async Task<IEnumerable<InboundOrderItem>> GetAllInboundOrderItems()
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
                throw new NotImplementedException("Exception has occurred in the Inbound Order Item data operations.");
            }
        }
    }
}
