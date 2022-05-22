using Gourmet.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gourmet.Database.Models;
using Gourmet.Database.Repositories;
namespace Gourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsRepository productsRepository;
        const string DECLINED = "The product could not be found";
        [HttpGet]
        [Route("findProductByName")]
        public string GetProductByName([FromBody] Product product)
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            Product productToBeReturned = productsRepository.GetProductByName(product.ProductName);
            if (productToBeReturned != null)
            {
                return productToBeReturned.ToString();
            }
            else
            {
                return DECLINED;
            }
        }

        [HttpGet]
        [Route("findProductById")]
        public string GetProductById([FromBody] Product product)
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            Product productToBeReturned = productsRepository.GetProductById(product.ProductId);
            if (productToBeReturned != null)
            {
                return productToBeReturned.ToString();
            }
            else
            {
                return DECLINED;
            }
        }

        [HttpGet]
        [Route("getAllProducts")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            return productsRepository.GetProductsList();

        }

        [HttpGet]
        [Route("getProductPrice")]
        public string GetProductPrice(Product product)
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            double price = productsRepository.GetProductPrice(product.ProductId);
            if (price == -1)
            {
                return DECLINED;
            }
            else
            {
                return price.ToString();
            }

        }

        [HttpGet]
        [Route("getProductQuantity")]
        public string GetProductQuantity(Product product)
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            int quantity = productsRepository.GetProductQuantity(product.ProductId);
            if (quantity == -1)
            {
                return DECLINED;
            }
            else
            {
                return quantity.ToString();
            }
        }

        [HttpPut]
        [Route("decreaseProductQuantity")]
        public string DecreaseProductQuantity(Product product)
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            return productsRepository.DecreaseProductQuantity(product.ProductId);
        }

        [HttpPut]
        [Route("increaseProductQuantity")]
        public string IncreaseProductQuantity(Product product)
        {
            if (productsRepository == null)
            {
                productsRepository = new ProductsRepository();
            }
            return productsRepository.IncreaseProductQuantity(product.ProductId);
        }
    }
}
