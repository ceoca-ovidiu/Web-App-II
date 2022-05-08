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
        const string DECLINE = "The recipe could not be found";

        [HttpGet]
        [Route("findRecipeById")]
        public string FindRecipeById([FromBody] Recipe recipe)
        {
            if (recipesRepository == null)
            {
                recipesRepository = new RecipesRepository();
            }
            Recipe recipeToBeReturned = recipesRepository.FindRecipeById(recipe);
            if (recipeToBeReturned == null)
            {
                return DECLINE;
            }
            else
            {
                return recipeToBeReturned.ToString();
            }
        }

        [HttpGet]
        [Route("getRecipeName")]
        public string GetRecipeName([FromBody] Recipe recipe)
        {
            if (recipesRepository == null)
            {
                recipesRepository = new RecipesRepository();
            }
            Recipe recipeToBeReturned = recipesRepository.FindRecipeByName(recipe);
            if (recipeToBeReturned == null)
            {
                return DECLINE;
            }
            else
            {
                return recipeToBeReturned.ToString();
            }
        }

        [HttpGet]
        [Route("getRecipeDescription")]
        public string GetRecipeDescription([FromBody] Recipe recipe)
        {
            if (recipesRepository == null)
            {
                recipesRepository = new RecipesRepository();
            }
            string recipeDescription = recipesRepository.GetRecipeDescription(recipe);
            if (recipeDescription == null)
            {
                return DECLINE;
            }
            else
            {
                return recipeDescription;
            }
        }

        [HttpGet]
        [Route("getRecipeProductReference")]
        public string GetRecipeProductReference([FromBody] Recipe recipe)
        {
            if (recipesRepository == null)
            {
                recipesRepository = new RecipesRepository();
            }
            Product recipeReference = recipesRepository.GetRecipeReference(recipe);
            if (recipeReference == null)
            {
                return DECLINE;
            }
            else
            {
                return recipeReference.ToString();
            }
        }

        [HttpGet]
        [Route("getAllRecipies")]
        public string GetAllRecipies([FromBody] Recipe recipe)
        {
            if (recipesRepository == null)
            {
                recipesRepository = new RecipesRepository();
            }
            List<Recipe> recipeList = recipesRepository.GetRecipesList();
            if (recipeList == null || recipeList.Count == 0)
            {
                return DECLINE;
            }
            else
            {
                return recipeList.ToString();
            }
        }

        [HttpDelete]
        [Route("deleteRecipeById")]
        public string DeleteRecipeById([FromBody] Recipe recipe)
        {
            if (recipesRepository == null)
            {
                recipesRepository = new RecipesRepository();
            }
            if (recipesRepository.DeleteRecipeById(recipe))
            {
                return "The recipe has been deleted successfully";
            }
            else
            {
                return DECLINE;
            }
            
        }

    }
}
