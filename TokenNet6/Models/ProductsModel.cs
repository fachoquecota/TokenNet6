using System.ComponentModel.DataAnnotations;

namespace TokenNet6.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
