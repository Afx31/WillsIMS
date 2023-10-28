using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class OutboundOrderRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public OutboundOrderRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<IEnumerable<OutboundOrder>> GetAllOutboundOrders()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM OutboundOrder
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<OutboundOrder> outboundOrders = new List<OutboundOrder>();

                foreach (DataRow row in dt.Rows)
                {
                    OutboundOrder order = new OutboundOrder
                    {
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        OrderDate = (DateTime)row["OrderDate"]
                    };
                    outboundOrders.Add(order);
                }

                return outboundOrders;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Exception has occurred in the Outbound Order data operations.");
            }
        }
    }
}
