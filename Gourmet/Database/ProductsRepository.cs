using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    public class ProductsRepository
    {
        public List<Product> GetProductsList()
        {
            using (var db = new AppDatabaseContext())
            {
                List<Product> products = db.ProductsDbSet.ToList();
                if (products == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product list is null. NULL will be returned");
                    return null;
                }
                else if (products.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product list is empty. An empty list will be returned");
                    return products;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The product list returned");
                    return products;
                }
            }

        }

        public Product GetProductById(int productId)
        {
            using (var db = new AppDatabaseContext())
            {
                Product product = db.ProductsDbSet.FirstOrDefault(products => products.ProductId == productId);
                if (product == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product is null. NULL will be returned");
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The product with id : " + product.ProductId.ToString() + " and name : " + product.ProductName + " is returned");
                    return product;
                }
            }
        }

        public Product GetProductByName(String productName)
        {
            using (var db = new AppDatabaseContext())
            {
                Product product = db.ProductsDbSet.FirstOrDefault(products => products.ProductName == productName);
                if (product == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product is null. NULL will be returned");
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The product with id : " + product.ProductId.ToString() + " and name : " + product.ProductName + " is returned");
                    return product;
                }
            }
        }

        public Boolean CreateProduct(Product productToCreate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    if (productToCreate == null)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The product received is null");
                        return false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to create a new product...");
                        db.ProductsDbSet.Add(productToCreate);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The product was added to dataset. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product could not be created");
                    return false;
                }
            }
        }

        public Boolean UpdateProduct(Product productToUpdate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    if (productToUpdate == null)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The product received is null");
                        return false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to update a product...");
                        db.ProductsDbSet.Update(productToUpdate);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The product was updated. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product could not be updated");
                    return false;
                }
            }
        }

        public Boolean DeleteProduct(int productId)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to remove a product...");
                    Product productToDelete = GetProductById(productId);
                    if (productToDelete != null)
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Found the product with id : " + productId.ToString() + " and it is " + productToDelete.ProductName);
                        db.Remove(productToDelete);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The product was removed. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The product is null and could not be removed");
                        return false;
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product with id " + productId.ToString() + " could not be found or could not be removed");
                    return false;
                }
            }
        }

        public int GetProductQuantity(int productId)
        {
            using (var db = new AppDatabaseContext())
            {
                System.Diagnostics.Debug.WriteLine("ACCEPTED => Finding the product with product id : " + productId.ToString());
                Product product = GetProductById(productId);
                if (product != null)
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => Found the product with id : " + productId.ToString() + " and it is " + product.ProductName);
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The quantity is : " + product.ProductQuantity.ToString());
                    return product.ProductQuantity;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The product with id : " + productId.ToString() + " could not be found or is null. -1 will be returned");
                    return -1;
                }
            }
        }
    }
}
