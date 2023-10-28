using System.Data.SqlClient;
using System.Data;
using WillsIMS.Models;

namespace WillsIMS.Repositories
{
    public class InboundOrderItemRepository
    {
        private readonly string _connectionString;

        public InboundOrderItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<InboundOrderItem>> GetAllInboundOrderItems()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM InboundOrderItem
                            ";

                DataTable dt = new DataTable();
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }

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
