using Microsoft.AspNetCore.Mvc;
using OrdersService.Models;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static List<Order> Orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                CustomerName = "John Doe",
                Products = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, ProductName = "Laptop", Price = 999.99M, Quantity = 1 }
                }
            },
            new Order
            {
                OrderId = 2,
                OrderDate = DateTime.Now,
                CustomerName = "Jane Doe",
                Products = new List<OrderItem>
                {
                    new OrderItem { ProductId = 2, ProductName = "Mouse", Price = 19.99M, Quantity = 1 }
                }
            }
        };

        [HttpGet]
        public IActionResult GetAllOrders() => Ok(Orders);

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
