using Microsoft.AspNetCore.Mvc;
using TG_DataAccess.Data;
using TG_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Toys_and_Games.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("Product/{Id}")]
        public ActionResult<Product> Product([FromRoute] int Id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == Id);
            if(product is null)
                return BadRequest();
            else
                return product;
        }
        [HttpGet("Product/All")]
        public List<Product> Product()
        {
            var result = new List<Product>();
            result = _db.Products.ToList();
            return result;
        }
        [HttpPost ("Product")]
        public IActionResult AddProduct([FromBody]Product p)
        {
            if(p != null)
            {
                _db.Products.Add(p);
                _db.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("Product Couldn't be null");

        }
        [HttpPut("Product")]
        public IActionResult Product([FromBody] Product p)
        {
            if(p.Id>0)
            {
                _db.Products.Update(p);
                _db.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }
        [HttpDelete("Product/{Id}")]
        public IActionResult DeleteProduct([FromRoute] int Id)
        {
            if(Id>0)
            {
                var objP = _db.Products.FirstOrDefault(p => p.Id == Id);
                if (objP == null)
                    return NotFound();
                _db.Products.Remove(objP);
                _db.SaveChanges();
                return Ok();
            }
            else
                return NotFound("Id Couldn't be 0");
        }
    }
}
