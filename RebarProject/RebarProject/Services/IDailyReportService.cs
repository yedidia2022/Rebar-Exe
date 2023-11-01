using RebarProject.Models;

namespace RebarProject.Services
{
    public interface IDailyReportService
    {
        List<DailyReport> Get();
        DailyReport Get(DateTime date);
        DailyReport Create(DailyReport dailyReport);
       
    }
}
