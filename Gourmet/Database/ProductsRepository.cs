using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    internal static class ProductsRepository
    {
        internal async static Task<List<Products>> GetProductsAsync()
        {
            using (var db = new AppDatabaseContext())
            {
                return await db.Products.ToListAsync();
            }
        }

        internal async static Task<Products> GetProductsByIdAsync(int productId)
        {
            using (var db = new AppDatabaseContext())
            {
                return await db.Products.FirstOrDefaultAsync(products => products.ProductId == productId);
            }
        }

        internal async static Task<bool> CreatePostAsync(Products productToCreate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    await db.Products.AddAsync(productToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdatePostAsync(Products productToUpdate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    db.Products.Update(productToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostAsync(int productId)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    Products productToDelete = await GetProductsByIdAsync(productId);

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
}
