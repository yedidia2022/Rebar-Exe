using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IMongoCollection<DailyReport> _dailyReports;
        private readonly CountService countService;


        public DailyReportService(IRebarStoreDateBaseSettings settings, IMongoClient mongoClinet)
        {
            var database = mongoClinet.GetDatabase(settings.DatabaseName);
            _dailyReports = database.GetCollection<DailyReport>(settings.DailyReportCollectionName);

        }
        public List<DailyReport> Get()
        {
            return _dailyReports.Find(dailyReport => true).ToList();
        }

        public DailyReport Get(DateTime date)
        {
            return _dailyReports.Find(dailyReport => dailyReport.Date == date).FirstOrDefault();

        }
        public DailyReport Create(DailyReport dailyReport)
        {
            _dailyReports.InsertOne(dailyReport);
            return dailyReport;
        }


        public void closeCashbox()
        {
            double sumPayment = 0;
            int amount = 0;
            List<Order> allOrders = countService.Get();
            foreach (Order order in allOrders)
            {
                if (order.OrderDate == DateTime.Now)
                {
                    amount++;
                    sumPayment += order.SumPayment;
                }
            }
            DailyReport dailyreport = new DailyReport();
            dailyreport.Date = DateTime.Now;
            dailyreport.TotalPayment = sumPayment;
            dailyreport.OrdersAmount = amount;
            Console.WriteLine(" number of orders from today:", dailyreport.OrdersAmount);
            Console.WriteLine(" the sum payment of orders from today:", dailyreport.TotalPayment);
            _dailyReports.InsertOne(dailyreport);

        }



    }
}
