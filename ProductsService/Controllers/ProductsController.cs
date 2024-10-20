using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
    {
        new Product { ProductId = 1, ProductName = "Laptop", Price = 999.99M },
        new Product { ProductId = 2, ProductName = "Mouse", Price = 19.99M }
    };

        [HttpGet]
        public IActionResult GetAllProducts() => Ok(Products);

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
