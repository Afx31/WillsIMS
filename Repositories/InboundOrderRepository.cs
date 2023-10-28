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

        public async Task<IEnumerable<InboundOrder>> GetAllInboundOrders()
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
                throw new NotImplementedException("Exception has occurred in the Inbound Order data operations.");
            }
        }
    }
}
