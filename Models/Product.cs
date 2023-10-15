namespace WillsIMS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int SupplierId { get; set; }
    }
}
