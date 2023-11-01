using Microsoft.AspNetCore.Mvc;
using RebarProject.Models;
using RebarProject.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebarProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {   private readonly IOrderService orderService;
        private readonly IShakeService shakeService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;  
        }
        // GET: api/<SgakesController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return orderService.Get();
        }

        // GET api/<SgakesController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {
           var order = orderService.Get(id);
            if(order == null) 
            {
                return NotFound($"order with Id={id}not found");
            }
            return order;
        }

        // POST api/<SgakesController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            orderService.Create(order);
            return CreatedAtAction(nameof(Get), new {id = order.Id},order);
        }

        // PUT api/<SgakesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Order order)
        {
            var existingOrder= orderService.Get(id);
            if(existingOrder == null)
            {
                return NotFound($"order with Id={id}not found");
            }
            orderService.Update(id, existingOrder);
            return NoContent();
        }

        // DELETE api/<SgakesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var order = orderService.Get(id);
            if (order == null)
            {
                return NotFound($"order with Id={id}not found");
            }
            orderService.Remove(order.Id);
            return Ok($"order with id = {id} deleted");
        }
        
    }
}
