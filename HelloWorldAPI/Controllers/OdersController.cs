using HelloWorldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdersController : ControllerBase
    {
        public AppDbContext _context;
        public OdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("get/{number}")]
        public Order? GetFromRoute([FromRoute] string number)
        {
            return _context.Orders.FirstOrDefault(x => x.Number == number);
        }


        [HttpGet("get-from-query")]
        public Order? GetFromQuery([FromQuery] int id,  string number)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id && x.Number == number);
        }

        [HttpGet("get-list")]
        public List<Order> GetList()
        {
            return _context.Orders.ToList();
        }

        [HttpPost("add-order")]
        public List<Order> AddOrder([FromBody] Order order)
        {
            var getOrder = _context.Orders.FirstOrDefault(x => x.Number == order.Number || x.Name == order.Name);
            if (getOrder != null)
                return [];
                
            _context.Orders.Add(order);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        [HttpPut("update-order")]
        public List<Order> UpdateOrder([FromBody] Order newOrder)
        {
            var oldOrder = _context.Orders.FirstOrDefault(x => x.Id == newOrder.Id);
            if (oldOrder != null)
            {
                oldOrder.Number = newOrder.Number;
                oldOrder.Name = newOrder.Name;
                oldOrder.Qty = newOrder.Qty;
                oldOrder.Price = newOrder.Price;
                _context.Entry(oldOrder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return [];
            }
            return _context.Orders.ToList();
        }

        [HttpDelete("delete-order/{id}")]
        public List<Order> DeleteOrder([FromRoute] int id)
        {
            var getOrder = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (getOrder != null)
            {
                _context.Orders.Remove(getOrder);
                _context.SaveChanges();
            }
            else
            {
                return [];
            }
            return _context.Orders.ToList();
        }
    }
}
