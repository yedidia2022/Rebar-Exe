using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class CountService : IOrderService
    {
        private readonly Account account;

        public CountService(Account account)
        {
            this.account = account;
        }
        public List<Order> Get()
        {
            return account.Orders;
        }

        public double GetSum()
        {
            return account.SumForTheOrders;

        }
        //להוסיף פונקציה של גט ע"י תאריך
        public Order AddOrder(Order order)
        {
            List<Order> orders;
            orders = account.Orders;
            orders.Add(order);
            account.Orders = orders;
            account.SumForTheOrders += order.SumPayment;
           return order;
        }
        public void Update(Guid id)
        {
            List<Order> orders = account.Orders;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == id)
                {
                    orders.RemoveAt(i);
                    account.SumForTheOrders -= orders[i].SumPayment;
                }

            }

        }
    }
}
