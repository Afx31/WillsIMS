using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class OutboundOrderRepository
    {
        private readonly string _connectionString;

        public OutboundOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<OutboundOrder> GetAllOutboundOrders()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM OutboundOrder
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
