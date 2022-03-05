using System.ComponentModel.DataAnnotations;

namespace Gourmet.Database

{
    internal sealed class Products
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

    }
}
