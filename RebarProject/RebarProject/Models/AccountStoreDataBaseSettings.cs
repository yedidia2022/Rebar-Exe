namespace RebarProject.Models
{
    public class AccountStoreDataBaseSettings : IAccountStoreDateBaseSettings
    {
        public string AccountCollectionName { get ; set ; }=string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
