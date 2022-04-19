using Gourmet.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private Database.ProductsRepository productsRepository;

        public ProductsController(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<Product> GetProductsAsList()
        {
            return productsRepository.GetProductsList();
        }

        public Product GetProductById(int productId)
        {
            return productsRepository.GetProductById(productId);
        }

        public Product GetProductByName(String productName)
        {
            return productsRepository.GetProductByName(productName);
        }

        public void CreateProduct(Product product)
        {
            productsRepository.CreateProduct(product);
        }

        public void UpdateProduct(Product productToUpdate)
        {
            productsRepository.UpdateProduct(productToUpdate);
        }

        public void DeleteProduct(int productId)
        {
            productsRepository.DeleteProduct(productId);
        }

        public int GetProductQuantity(int productId)
        {
            return productsRepository.GetProductQuantity(productId);
        }

        public void SetProductQuantity(int productId, int quantity)
        {
            GetProductById(productId).ProductQuantity = quantity;
        }

    }
}
