using HelloWorldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdersController : ControllerBase
    {
        private List<Order> orders =
        [
            new Order { Id = 1, Number = "Order-1", Name = "Order 1", Qty = 2, Price = 20.5f },
            new Order { Id = 2, Number = "Order-2", Name = "Order 2", Qty = 1, Price = 15.0f },
            new Order { Id = 3, Number = "Order-3", Name = "Order 3", Qty = 5, Price = 50.0f }
        ];

        [HttpGet("get/{number}")]
        public Order? GetFromRoute([FromRoute] string number)
        {
            return orders.FirstOrDefault(x => x.Number == number);
        }


        [HttpGet("get-from-query")]
        public Order? GetFromQuery([FromQuery] int id,  string number)
        {
            return orders.FirstOrDefault(x => x.Id == id && x.Number == number);
        }

        [HttpGet("get-list")]
        public List<Order> GetList()
        {
            return orders.ToList();
        }

        [HttpPost("add-order")]
        public List<Order> AddOrder([FromBody] Order order)
        {
            orders.Add(order);
            return orders.ToList();
        }


        [HttpDelete("delete-order/{id}")]
        public List<Order> DeleteOrder([FromRoute] int id)
        {
            var getOrder = orders.FirstOrDefault(x => x.Id == id);
            if (getOrder != null)
            {
                orders.Remove(getOrder);
            }
            else
            {
                return orders.ToList();
            }
            return orders.ToList();
        }
    }
}
