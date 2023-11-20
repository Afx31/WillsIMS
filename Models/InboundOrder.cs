using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class InboundOrder
    {
        public string InboundOrderTableName = "InboundOrder";
        [Key]
        public int InboundOrderId { get; set; }
        public int CompanyId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
