using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    public class RecipesRepository
    {
        public List<Recipe> GetRecipes()
        {
            using (var db = new AppDatabaseContext())
            {
                List<Recipe> recipes = db.RecipesDbSet.ToList();
                if (recipes == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipes list is null. NULL will be returned");
                    return null;
                }
                else if (recipes.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipes list is empty. An empty list will be returned");
                    return recipes;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The recipes list returned");
                    return recipes;
                }
            }
        }

        public Recipe GetRecipeById(int recipeId)
        {
            using (var db = new AppDatabaseContext())
            {
                Recipe recipe = db.RecipesDbSet.FirstOrDefault(recipes => recipes.RecipeID == recipeId);
                if (recipe == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipe is null. NULL will be returned");
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The recipe with id : " + recipe.RecipeID.ToString() + " and name : " + recipe.RecipeName + " is returned");
                    return recipe;
                }
            }
        }

        public Recipe GetRecipeByName(String recipeName)
        {
            using (var db = new AppDatabaseContext())
            {
                Recipe recipe = db.RecipesDbSet.FirstOrDefault(recipes => recipes.RecipeName == recipeName);
                if (recipe == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipe is null. NULL will be returned");
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The recipe with id : " + recipe.RecipeID.ToString() + " and name : " + recipe.RecipeName + " is returned");
                    return recipe;
                }
            }
        }

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

        public Boolean UpdateRecipe(Recipe recipeToUpdate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    if (recipeToUpdate == null)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The recipe received is null");
                        return false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to update a recipe...");
                        db.RecipesDbSet.Update(recipeToUpdate);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The recipe was updated. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipe could not be updated");
                    return false;
                }
            }
        }

        public Boolean DeleteRecipe(int recipeId)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to remove a recipe...");
                    Recipe recipeToDelete = GetRecipeById(recipeId);
                    if (recipeToDelete != null)
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Found the recipe with id : " + recipeId.ToString() + " and it is " + recipeToDelete.RecipeName);
                        db.Remove(recipeToDelete);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The recipe was removed. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The recipe is null and could not be removed");
                        return false;
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The recipe with id " + recipeId.ToString() + " could not be found or could not be removed");
                    return false;
                }
            }
        }
    }
}
