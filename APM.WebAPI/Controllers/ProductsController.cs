using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
   
    [EnableCorsAttribute("http://localhost:60133/", "*","*")]
    public class ProductsController : ApiController
    {
        [EnableQuery()]
        // GET: api/Products
        public IQueryable<Product> Get()
        {

            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }
        //public IEnumerable<Product> Get(string search)
        //{

        //    var productRepository = new ProductRepository();
        //    var products= productRepository.Retrieve();
        //    return products.Where(p => p.ProductCode.Contains(search));
        //}
        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();
            if(id>0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }
            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var updateProduct = productRepository.Save(id,product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
