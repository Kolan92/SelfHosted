using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SelfHosted.Models;


namespace SelfHosted.Controllers {
    public class ProductsController : ApiController{
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetAllProducts() {
            return products;
        }

        public Product GetProductById(int id) {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string categpry) {
            return products.Where(x => string.Equals(x.Category, categpry, StringComparison.OrdinalIgnoreCase));
        }



    }
}
