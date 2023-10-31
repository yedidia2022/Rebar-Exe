using RebarProject.Models;

namespace RebarProject.Services
{
    public interface IDailyReportService
    {
        List<DailyReport> Get();
        DailyReport Get(DateOnly date);
        DailyReport Create(DailyReport dailyReport);
       
    }
}
