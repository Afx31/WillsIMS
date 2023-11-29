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

        public async Task<bool> Create(OutboundOrder outboundOrder)
        {
            try
            {
                int nextOutboundOrderId = _databaseUtility.GetNextAvailableId(outboundOrder.OutboundOrderTableName);

                string query = $@"
                            INSERT INTO OutboundOrder (OutboundOrderId, CustomerId, OrderDate)
                            VALUES ({nextOutboundOrderId}, {outboundOrder.CustomerId}, {outboundOrder.OrderDate}')     
                            ";

                var res = await _databaseUtility.QueryDatabase(query);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrder - Create");
            }
        }

        public async Task<OutboundOrder> Get(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM OutboundOrder
                            WHERE OutboundOrderId = {id}
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<OutboundOrder> outboundOrders = new List<OutboundOrder>();

                foreach (DataRow row in dt.Rows)
                {
                    OutboundOrder orderItem = new OutboundOrder
                    {
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        OrderDate = (DateTime)row["OrderDate"]
                    };
                    outboundOrders.Add(orderItem);
                }

                return outboundOrders.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrder - Get");
            }
        }

        public async Task<IEnumerable<OutboundOrder>> GetAll()
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
                    OutboundOrder orderItem = new OutboundOrder
                    {
                        OutboundOrderId = Convert.ToInt32(row["OutboundOrderId"]),
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        OrderDate = (DateTime)row["OrderDate"]
                    };
                    outboundOrders.Add(orderItem);
                }

                return outboundOrders;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrder - GetAll");
            }
        }

        public async Task<bool> Update(OutboundOrder outboundOrder)
        {
            try
            {
                string query = $@"
                            UPDATE OutboundOrder
                            SET CustomerId = {outboundOrder.CustomerId}, OrderDate = '{outboundOrder.OrderDate}'
                            WHERE OutboundOrderId = {outboundOrder.OutboundOrderId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrder - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM OutboundOrder
                            WHERE OutboundOrderId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: OutboundOrder - Delete");
            }
        }
    }
}
