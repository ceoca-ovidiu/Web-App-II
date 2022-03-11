using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    internal sealed class RecipesRepository
    {
        internal async static Task<List<Recipes>> GetRecipesAsync(AppDatabaseContext db)
        {
            return await db.RecipesDbSet.ToListAsync();
        }

        internal async static Task<Recipes> GetRecipeByIdAsync(int recipeId, AppDatabaseContext db)
        {
            return await db.RecipesDbSet.FirstOrDefaultAsync(recipes => recipes.RecipeID == recipeId);
        }

        internal async static Task<bool> CreateRecipeAsync(Recipes recipeToCreate, AppDatabaseContext db)
        {
            try
            {
                await db.RecipesDbSet.AddAsync(recipeToCreate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateRecipeAsync(Recipes recipeToUpdate, AppDatabaseContext db)
        {
            try
            {
                db.RecipesDbSet.Update(recipeToUpdate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteRecipeAsync(int recipeId, AppDatabaseContext db)
        {
            try
            {
                Recipes recipeToDelete = await GetRecipeByIdAsync(recipeId, db);

                db.Remove(recipeToDelete);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
