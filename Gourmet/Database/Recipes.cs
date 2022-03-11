using System.ComponentModel.DataAnnotations;

namespace Gourmet.Database
{
    internal sealed class Recipes
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string RecipeName { get; set; } = string.Empty;        
        
        [Required]
        [MaxLength(100)]
        public string RecipeDescription { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public byte[] RecipeImage { get; set; }
        
        [Required]
        [MaxLength(100)]
        public Products RecipeProductReference { get; set; }

    }
}
