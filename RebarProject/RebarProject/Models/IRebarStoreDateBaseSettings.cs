namespace RebarProject.Models
{
    public interface IRebarStoreDateBaseSettings
    {
        string DailyReportCollectionName { get; set; }
        string OrderCollectionName { get; set; }
       string ShakeCollectionName { get; set; } 
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
