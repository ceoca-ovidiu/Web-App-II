using System.ComponentModel.DataAnnotations;

namespace Gourmet.Database.Models

{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [MaxLength(10000)]
        public int ProductQuantity { get; set; } = 0;

        [Required]
        [MaxLength(10000)]
        public double ProductPrice { get; set; } = 0.0;

        [Required]
        [MaxLength(10000)]
        public string ProductDescription { get; set; } = string.Empty;

        [Required]
        public string ProductImage { get; set; }

    }
}
