using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
   
    [EnableCorsAttribute("http://localhost:60133/", "*","*")]
    public class ProductsController : ApiController
    {
        [EnableQuery()]
        [ResponseType(typeof(Product))]
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
        public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                }
                else
                {
                    product = productRepository.Create();
                }
                if (product == null)
                {
                   
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {

              return InternalServerError(ex);
            }

        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product can not be null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productRepository = new Models.ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product can not be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productRepository = new Models.ProductRepository();
                var updateProduct = productRepository.Save(id, product);
                if (updateProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
