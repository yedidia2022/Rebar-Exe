using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class CountService 
    {
        //private readonly IMongoCollection<Order> _accounts;
        private readonly Account account;


        public CountService(/*IAccountStoreDateBaseSettings settings, IMongoClient mongoClinet,*/ Account account)
        {
            //var database = mongoClinet.GetDatabase(settings.DatabaseName);
            //_accounts = database.GetCollection<Order>(settings.AccountCollectionName);
            this.account = account;
        }
        public List<Order> Get()
        {
            return account.Orders
                .ToList();
        }

        public double GetSum()
        {
            return account.SumForTheOrders;

        }
        
        public void AddOrder(Order order)
        {
            List<Order> orders;
            orders = account.Orders;
            orders.Add(order);
            account.Orders = orders;
            account.SumForTheOrders += order.SumPayment;

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
