using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class InboundOrder
    {
        [Key]
        public int InboundOrderId { get; set; }
        public int CompanyId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
