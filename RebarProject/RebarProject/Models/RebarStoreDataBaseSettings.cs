namespace RebarProject.Models
{
    public class RebarStoreDataBaseSettings : IRebarStoreDateBaseSettings
    {
        public string DailyReportCollectionName { get; set; } = string.Empty;
        public string OrderCollectionName { get; set; } = string.Empty;
        public string ShakeCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
