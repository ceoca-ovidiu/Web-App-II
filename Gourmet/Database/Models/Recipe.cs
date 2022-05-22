using System.ComponentModel.DataAnnotations;

namespace Gourmet.Database.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string RecipeName { get; set; }      
        
        [Required]
        [MaxLength(100000)]
        public string RecipeDescription { get; set; }

        [Required]
        [MaxLength(100000)]
        public string RecipeImage { get; set; }


        [Required]
        [MaxLength(100000)]
        public int RecipeProductReferenceProductId { get; set; }

        [MaxLength(1000000)]
        public string RecipeSuggest { get; set; }

    }
}
