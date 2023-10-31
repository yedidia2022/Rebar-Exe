using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Order> _accounts;

        public OrderService(IOrderStoreDateBaseSettings settings, IMongoClient mongoClinet)
        {
            var database = mongoClinet.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrderCollectionName);
           // _accounts= database.GetCollection<Account>(settings.AccountCollectionName);
        }
        public List<Order> Get()
        {
            return _orders.Find(order => true).ToList();
        }

        public Order Get(Guid id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();

        }
        //להוסיף פונקציה של גט ע"י תאריך
        public Order Create(Order order)
        {   
            _orders.InsertOne(order);
            return order;
        }
        public void Update(Guid id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);

        }





        public void Remove(Guid id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }

    }
}
