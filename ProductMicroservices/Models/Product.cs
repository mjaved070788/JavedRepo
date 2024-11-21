using System.ComponentModel.DataAnnotations;

namespace ProductMicroservices.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }       
        public string CategoryId { get; set; }
    }
}
