using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    internal static class ProductsRepository
    {
        internal async static Task<List<Products>> GetProductsAsync(AppDatabaseContext db)
        {
            Console.WriteLine("Calling GetProductsAsync from ProductRepository");
            Console.WriteLine(db.ProductsDbSet.ToListAsync());
            return await db.ProductsDbSet.ToListAsync();
        }

        internal async static Task<Products> GetProductsByIdAsync(int productId, AppDatabaseContext db)
        {
            return await db.ProductsDbSet.FirstOrDefaultAsync(products => products.ProductId == productId);
        }

        internal async static Task<bool> CreateProductAsync(Products productToCreate, AppDatabaseContext db)
        {
            try
            {
                await db.ProductsDbSet.AddAsync(productToCreate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateProductAsync(Products productToUpdate, AppDatabaseContext db)
        {
            try
            {
                db.ProductsDbSet.Update(productToUpdate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteProductAsync(int productId, AppDatabaseContext db)
        {
            try
            {
                Products productToDelete = await GetProductsByIdAsync(productId, db);

                db.Remove(productToDelete);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
