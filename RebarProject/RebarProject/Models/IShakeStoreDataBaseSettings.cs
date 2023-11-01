namespace RebarProject.Models
{
    public interface IShakeStoreDataBaseSettings
    { string ShakeCollectionName { get; set; }
      string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
