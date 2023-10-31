﻿namespace RebarProject.Models
{
    public class DailyReportStoreDataBaseSettings : IDailyReportStoreDateBaseSettings
    {
        public string DailyReportCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
