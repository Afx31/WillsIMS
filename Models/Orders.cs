using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class Orders
    {
        [Key]
        public int OrdersId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
