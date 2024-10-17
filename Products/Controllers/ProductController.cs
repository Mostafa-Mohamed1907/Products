using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System.Net;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //[HttpGet]
        //public List<Product> GetAll() 
        //{
        //    var products = Context.Products.ToList();
        //    return products;
        //}
        //[HttpGet ("{id}")]
        //public Product GetById(int id)
        //{
        //    var product = Context.Products.SingleOrDefault(p => p.Id == id);
        //    return product;
        //}
        //[HttpGet("name/{name}")]
        //public Product GetByName(string name)
        //{
        //    var product = Context.Products.SingleOrDefault(p => p.Name.Contains(name));
        //    return product;
        //}
        //[HttpPost]
        //public HttpResponseMessage CreateProduct([FromBody] Product product)
        //{
        //    Context.Products.Add(product);
        //    var response = new HttpResponseMessage(HttpStatusCode.Created);
        //    return response;
        //}
        //[HttpPut("id/{id}")]
        //public HttpResponseMessage UpdateProduct(int id, [FromBody] Product product)
        //{
        //    var ExistingProduct = Context.Products.FirstOrDefault(p => p.Id == id);
        //    ExistingProduct.Name= product.Name;
        //    ExistingProduct.Description = product.Description;
        //    ExistingProduct.Price=product.Price;
        //    return new HttpResponseMessage(HttpStatusCode.NoContent);
        //}
        //[HttpDelete]
        //public HttpResponseMessage DeleteProduct(int id)
        //{
        //    var ExistingProduct = Context.Products.FirstOrDefault(p => p.Id == id);
        //    Context.Products.Remove(ExistingProduct);
        //    return new HttpResponseMessage(HttpStatusCode.NoContent);
        //}


        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var products = Context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }
        [HttpGet("name/{name}")]
        public ActionResult<Product> GetByName(string name)
        {
            var product = Context.Products.SingleOrDefault(p => p.Name.Contains(name));
            if (product == null) { return NotFound(); }
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            Context.Products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id, product });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var ExistingProduct = Context.Products.FirstOrDefault(p => p.Id == id);
            if (ExistingProduct == null) { return NotFound(); }
            ExistingProduct.Name = product.Name;
            ExistingProduct.Description = product.Description;
            ExistingProduct.Price = product.Price;
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var ExistingProduct = Context.Products.FirstOrDefault(p => p.Id == id);
            if (ExistingProduct == null) { return NotFound(); }
            Context.Products.Remove(ExistingProduct);
            return NoContent();
        }
    }
}
