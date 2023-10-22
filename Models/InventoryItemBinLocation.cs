using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class InventoryItemBinLocation
    {
        [Key]
        public int InventoryItemBinLocationId { get; set; }
        public int InventoryItemId { get; set; }
        public int BinLocationId { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public BinLocation BinLocation { get; set; }
    }
}
