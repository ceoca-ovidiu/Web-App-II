using System.ComponentModel.DataAnnotations;

namespace Gourmet.Database
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string RecipeName { get; set; }      
        
        [Required]
        [MaxLength(100)]
        public string RecipeDescription { get; set; }

        [Required]        
        [MaxLength(100)]
        public byte[] RecipeImage { get; set; }

        [Required]
        [MaxLength(100)]
        public Product RecipeProductReference { get; set; }

    }
}
