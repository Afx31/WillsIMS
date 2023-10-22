using System.Data;
using System.Data.SqlClient;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class InboundOrderRepository
    {
        private readonly string _connectionString;

        public InboundOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<InboundOrder> GetAllInboundOrders()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InboundOrder
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
