namespace RebarProject.Models
{
    public class ShakeStoreDataBaseSettings : IShakeStoreDataBaseSettings
    {
        public string ShakeCollectionName { get ; set ; }=string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
