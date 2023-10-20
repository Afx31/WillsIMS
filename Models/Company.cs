using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public int CompanyType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
