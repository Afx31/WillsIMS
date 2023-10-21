using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class InboundOrderItem
    {
        [Key]
        public int InboundOrderItemId { get; set; }
        public int InboundOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
    }
}
