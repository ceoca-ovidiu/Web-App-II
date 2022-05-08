using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            if (String.IsNullOrEmpty(productId.ToString()))
            {
                return null;
            }
            else
            {
                AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                foreach (Product productIterator in appDatabaseContext.ProductsDbSet)
                {
                    Debug.WriteLine("=======================================> Checking product " + productIterator.ProductName);
                    if (productIterator.ProductId == productId)
                    {
                        Debug.WriteLine("=======================================> The product has been found " + productIterator.ProductName);
                        return productIterator;
                    }
                }
                return null;
            }

        }

        public Product GetProductByName(String productName)
        {
            if (String.IsNullOrEmpty(productName))
            {
                return null;
            }
            else
            {
                AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                foreach (Product productIterator in appDatabaseContext.ProductsDbSet)
                {
                    Debug.WriteLine("=======================================> Checking product " + productIterator.ProductName);
                    if (productIterator.ProductName.Equals(productName))
                    {
                        Debug.WriteLine("=======================================> The product has been found " + productIterator.ProductName);
                        return productIterator;
                    }
                }
                return null;
            }
        }

        public double GetProductPrice(int productId)
        {
            Product product = GetProductById(productId);
            if (product != null)
            {
                return GetProductById(productId).ProductPrice;
            }
            else
            {
                return -1.0;
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

        internal string IncreaseProductQuantity(int productId)
        {
            Product product = GetProductById(productId);
            if (product != null)
            {
                changeQuantity(product, 1);
                return "The quantity of the " + product.ProductName + " has been increased successfully";
            }
            else
            {
                return "The quantity could not be changed. The product does not exists";
            }
        }

        public string DecreaseProductQuantity(int productId)
        {
            Product product = GetProductById(productId);
            if (product != null)
            {
                changeQuantity(product, -1);
                return "The quantity of the " + product.ProductName + " has been decreased successfully";
            }
            else
            {
                return "The quantity could not be changed. The product does not exists";
            }
        }

        private void changeQuantity(Product product, int value)
        {
            Product productToChange = new Product();
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            productToChange.ProductId = product.ProductId;
            productToChange.ProductQuantity = product.ProductQuantity + value;
            productToChange.ProductPrice = product.ProductPrice;
            productToChange.ProductName = product.ProductName;
            productToChange.ProductImage = product.ProductImage;
            productToChange.ProductDescription = product.ProductDescription;
            appDatabaseContext.ProductsDbSet.Remove(product);
            appDatabaseContext.ProductsDbSet.Add(productToChange);
            appDatabaseContext.SaveChanges();
        }

        public Boolean DeleteProduct(Product product)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (Product productIterator in appDatabaseContext.ProductsDbSet)
            {
                Debug.WriteLine("=======================================> Checking product " + productIterator.ProductName);
                if (productIterator.ProductId.Equals(product.ProductId))
                {
                    Debug.WriteLine("=======================================> The product " + productIterator.ProductName + " has been found and will be deleted");
                    appDatabaseContext.ProductsDbSet.Remove(productIterator);
                    return true;
                }
            }
            return false;
        }

        public int GetProductQuantity(int productId)
        {
            Product product = GetProductById(productId);
            if (product != null)
            {
                return GetProductById(productId).ProductQuantity;
            }
            else
            {
                return -1;
            }
        }
    }
}
