using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Gourmet.Database
{
    public class RecipesRepository
    {
        public Boolean CreateRecipe(Recipe recipeToCreate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    if (recipeToCreate == null)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The recipe received is null");
                        return false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to create a new recipe...");
                        db.RecipesDbSet.Add(recipeToCreate);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The recipe was added to dataset. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipe could not be created");
                    return false;
                }
            }
        }

        public Recipe FindRecipeById(Recipe recipe)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (Recipe recipeIterator in appDatabaseContext.RecipesDbSet)
            {
                Debug.WriteLine("=======================================> Checking recipe " + recipeIterator.RecipeName);
                if (recipeIterator.RecipeID.Equals(recipe.RecipeID))
                {
                    return recipeIterator;
                }
            }
            return null;
        }

        public Recipe FindRecipeByName(Recipe recipe)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (Recipe recipeIterator in appDatabaseContext.RecipesDbSet)
            {
                Debug.WriteLine("=======================================> Checking recipe " + recipeIterator.RecipeName);
                if (recipeIterator.RecipeName.Equals(recipe.RecipeName))
                {
                    return recipeIterator;
                }
            }
            return null;
        }

        public string GetRecipeDescription(Recipe recipe)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (Recipe recipeIterator in appDatabaseContext.RecipesDbSet)
            {
                Debug.WriteLine("=======================================> Checking recipe " + recipeIterator.RecipeName);
                if (recipeIterator.RecipeID.Equals(recipe.RecipeID))
                {
                    return recipeIterator.RecipeDescription;
                }
            }
            return null;
        }

        public Product GetRecipeReference(Recipe recipe)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (Recipe recipeIterator in appDatabaseContext.RecipesDbSet)
            {
                Debug.WriteLine("=======================================> Checking recipe " + recipeIterator.RecipeName);
                if (recipeIterator.RecipeID.Equals(recipe.RecipeID))
                {
                    return recipeIterator.RecipeProductReference;
                }
            }
            return null;
        }

        public List<Recipe> GetRecipesList()
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            List<Recipe> recipesList = appDatabaseContext.RecipesDbSet.ToList();
            if (recipesList == null)
            {
                Debug.WriteLine("DECLINED => The recipe list is null. NULL will be returned");
                return null;
            }
            else if (recipesList.Count == 0)
            {
                Debug.WriteLine("DECLINED => The recipe list is empty. An empty list will be returned");
                return recipesList;
            }
            else
            {
                Debug.WriteLine("ACCEPTED => The product list returned");
                return recipesList;
            }
        }

        public Boolean DeleteRecipeById(Recipe recipe)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (Recipe recipeIterator in appDatabaseContext.RecipesDbSet)
            {
                Debug.WriteLine("=======================================> Checking recipe " + recipeIterator.RecipeName);
                if (recipeIterator.RecipeID == recipe.RecipeID)
                {
                    Debug.WriteLine("=======================================> The recipe " + recipeIterator.RecipeName + " has been found and will be deleted");
                    appDatabaseContext.RecipesDbSet.Remove(recipeIterator);
                    return true;
                }
            }
            return false;
        }

    }
}

