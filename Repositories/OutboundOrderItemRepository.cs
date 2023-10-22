using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class OutboundOrderItemRepository
    {
        private readonly string _connectionString;

        public OutboundOrderItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<OutboundOrderItem> GetAllOutboundOrderItems()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM OutboundOrderItem
                            ";

                DataTable dt = new DataTable();
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }

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
