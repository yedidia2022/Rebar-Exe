namespace RebarProject.Models
{
    public interface IDailyReportStoreDateBaseSettings
    {
        string DailyReportCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
