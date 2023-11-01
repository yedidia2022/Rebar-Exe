using RebarProject.Models;
using MongoDB.Driver;
using System.Diagnostics.Eventing.Reader;

namespace RebarProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Order> _accounts;
        private readonly ShakeService shakeService;
        private readonly CountService countService;


        public OrderService(IRebarStoreDateBaseSettings settings, IMongoClient mongoClinet)
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

        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            countService.AddOrder(order);

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


        public Order menuAndAddShakeToIts()
        {
            int shakesCount = 0;
            List<Shake> shakes = shakeService.Get();
            if (shakes == null)
                return null;

            shakesCount = shakes.Count;
            int numberChoice;
            Console.WriteLine("press 1 to choose shake, 2 to add shake to the menu");
            string userChoice = Console.ReadLine();
            if (!int.TryParse(userChoice, out numberChoice))
                throw new Exception("not valid input");


            if (numberChoice == 1)
            {
                Order newOrder = new Order();
                newOrder = chooseShakesFromTheMenu(shakes, shakesCount);
                return newOrder;
            }
            else
            if (numberChoice == 2)
            {
                Shake shake = new Shake();
                shake = shakeService.Create(shake);
                return null;
            }
            return null;






        }
        public Order chooseShakesFromTheMenu(List<Shake> shakes, int shakesCount)
        {
            DateTime startOrder = DateTime.Now;
            int maxShakes = 10, numberChoice, amountOfCups;
            double price, sumForPayment = 0;
            string userChoice;
            List<ShakeForOrder> shakesWasChosen = new List<ShakeForOrder>();
            if (shakesCount == 0)
            {
                Console.WriteLine("noshake in the menu");
                return null;
            }
            for (int i = 0; i < shakesCount && maxShakes > 0; i++)
            {
                int isTillWantsMore = 1;
                Console.WriteLine("enter {0} to choose this shake {1}", i, shakes[i].Name);
                userChoice = Console.ReadLine();
                if (userChoice == "")
                    throw new Exception("not valid");

                if (!int.TryParse(userChoice, out numberChoice))
                    throw new Exception("not valid input");
                if (numberChoice > shakesCount - 1)
                    throw new Exception("there is not this shake");
                while (isTillWantsMore == 1)
                {
                    Console.WriteLine("enter S or M or L ");
                    string size = Console.ReadLine();

                    if (size == "M" || size == "L" || size == "S")
                    {
                        Console.WriteLine("how many cups do you want from this shake in this size");
                        userChoice = Console.ReadLine();
                        if (!int.TryParse(userChoice, out amountOfCups))
                            throw new Exception("not valid input");
                        price = size == "M" ? shakes[i].PriceForMedium : size == "L" ? shakes[i].PriceForLarge : shakes[i].PriceForSmall;
                        if (amountOfCups == 1)
                        {
                            shakesWasChosen.Add(new ShakeForOrder(shakes[i], price, size));
                            maxShakes--;
                            sumForPayment += price;
                        }
                        else
                            if (amountOfCups > maxShakes)
                        {
                            Console.WriteLine("you will have more then 10, so we will do just {0}", maxShakes);
                            amountOfCups = maxShakes;
                        }
                        while (amountOfCups > 0)
                        {
                            maxShakes--;
                            amountOfCups--;
                            shakesWasChosen.Add(new ShakeForOrder(shakes[i], price, size));
                        }


                        Console.WriteLine("do yow want this shake in another size press 1 for yes all the others for countinue?");
                        userChoice = Console.ReadLine();
                        if (!int.TryParse(userChoice, out isTillWantsMore))
                            throw new Exception("not valid");
                    }

                }





            }
            Console.WriteLine("enter your name");
            string coustomerName = Console.ReadLine();
            if (coustomerName != null)
            {
                Order newOrder = new Order();
                newOrder.ShakeList = shakesWasChosen;
                newOrder.CustomerName = coustomerName;
                newOrder.SumPayment = sumForPayment;
                newOrder.OrderDate = DateTime.Now;
                newOrder.OrderStartTime = startOrder;
                newOrder.OrderEndTime = DateTime.Now;
                TimeSpan timePrepering= DateTime.Now - startOrder;
                newOrder.TimeToPrepare = timePrepering.TotalMinutes;
                return newOrder;
            }

            return null;

        }



        public void takeTheOrder()
        {
            Order orderToDB = menuAndAddShakeToIts();
            if (orderToDB != null)
            {
                _orders.InsertOne(orderToDB);
                Console.WriteLine("we prepare your order");

            }
            else
                Console.WriteLine("we din't enter the order");
        }










    }
}
