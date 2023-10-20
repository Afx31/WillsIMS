using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class OutboundOrderItem
    {
        [Key]
        public int OutboundOrderItemId { get; set; }
        public int OutboundOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
