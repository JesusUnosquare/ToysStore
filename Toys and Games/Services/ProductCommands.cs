using Microsoft.AspNetCore.Mvc;
using TG_DataAccess.Data;
using TG_Model.Models;

namespace Toys_and_Games.Services
{
    public class ProductCommands : IProductCommands
    {
        private readonly ApplicationDbContext _db;
        public ProductCommands(ApplicationDbContext context)
        {
                _db= context;
        }
        public ActionResult<Product> Product(int Id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == Id);
            if (product is null)
                return new BadRequestResult();
            else
                return product;
        }
        [HttpGet]
        public List<Product> Product()
        {
            var result = new List<Product>();
            result = _db.Products.ToList();
            return result;
        }
        [HttpPost]
        public bool AddProduct(Product p)
        {
            if (p != null)
            {
                _db.Products.Add(p);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        [HttpPut]
        public bool Product(Product p)
        {
            if (p.Id > 0)
            {
                _db.Products.Update(p);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        [HttpDelete("{Id}")]
        public bool DeleteProduct(int Id)
        {
            var objP = _db.Products.FirstOrDefault(p => p.Id == Id);
            if (objP != null)
            {
                _db.Products.Remove(objP);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
