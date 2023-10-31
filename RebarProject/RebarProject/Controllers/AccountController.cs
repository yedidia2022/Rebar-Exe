using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebarProject.Models;
using RebarProject.Services;

namespace RebarProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Account account;
        public AccountController(Account account)
        {
            this.account = account;
        }
        // GET: AccountController
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return account.Orders;
        }

        public ActionResult <double> GetSum()
        {
            return account.SumForTheOrders;
        }



        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {   List<Order> orders = new List<Order>();
            orders= account.Orders;
            orders.Add(order);
            account.Orders = orders;
            account.SumForTheOrders += order.SumPayment;
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

      

        public ActionResult Delete(Guid id)
        {
            List<Order> orders= account.Orders;
          
            for(int i=0;i<orders.Count;i++)
            {
                if (orders[i].Id == id) {
                    orders.RemoveAt(i);
                    account.SumForTheOrders -= orders[i].SumPayment;
                    return Ok($"order with id = {id} deleted");
                }


            }
            return NotFound($"order with Id={id}not found");


        }

       
    }
}
