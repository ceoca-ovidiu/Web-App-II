using Gourmet.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private RecipesRepository recipesRepository;

        public RecipesController(RecipesRepository recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public List<Recipe> GetRecipesAsList()
        {
            return recipesRepository.GetRecipes();
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return recipesRepository.GetRecipeById(recipeId);
        }

        public Recipe GetRecipeByName(String recipeName)
        {
            return recipesRepository.GetRecipeByName(recipeName);
        }

        [HttpGet]
        public void CreateRecipe(Recipe recipe)
        {
            recipesRepository.CreateRecipe(recipe);
        }

        public void DeleteRecipe(int recipeId)
        {
            recipesRepository.DeleteRecipe(recipeId);
        }

        public void UpdateRecipe(int recipeId)
        {
            recipesRepository.DeleteRecipe(recipeId);
        }
    }
}
