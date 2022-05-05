using Microsoft.AspNetCore.Mvc;
using TG_Model.Models;

namespace Toys_and_Games.Services
{
    public interface IProductCommands
    {
        ActionResult<Product> Product(int Id);
        List<Product> Product();
        bool AddProduct(Product p);
        bool Product(Product p);
        bool DeleteProduct(int Id);
    }
}
