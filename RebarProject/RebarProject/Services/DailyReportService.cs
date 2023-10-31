using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IMongoCollection<DailyReport> _dailyReports;
        private readonly IMongoCollection<Order> _accounts;

        public DailyReportService(IDailyReportStoreDateBaseSettings settings, IMongoClient mongoClinet)
        {
            var database = mongoClinet.GetDatabase(settings.DatabaseName);
            _dailyReports = database.GetCollection<DailyReport>(settings.DailyReportCollectionName);

        }
        public List<DailyReport> Get()
        {
            return _dailyReports.Find(dailyReport => true).ToList();
        }

        public DailyReport Get(DateOnly date)
        {
            return _dailyReports.Find(dailyReport => dailyReport.Date == date).FirstOrDefault();

        }
        public DailyReport Create(DailyReport dailyReport)
        {
            _dailyReports.InsertOne(dailyReport);
            return dailyReport;
        }






    }
}
