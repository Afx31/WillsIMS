using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class OutboundOrder
    {
        public string OutboundOrderTableName = "OutboundOrder";
        [Key]
        public int OutboundOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
