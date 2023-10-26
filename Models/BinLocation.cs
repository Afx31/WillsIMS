using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class BinLocation
    {
        [Key]
        public int BinLocationId { get; set; }
        public string Location { get; set; }
        public int InventoryItemId { get; set; }
    }
}
