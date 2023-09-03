using System.ComponentModel.DataAnnotations;
namespace CustomerDataProject.Models
{
    public class CustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ImageData { get; set; }
    }
}
