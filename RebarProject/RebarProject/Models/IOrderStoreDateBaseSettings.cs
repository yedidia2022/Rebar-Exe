namespace RebarProject.Models
{
    public interface IOrderStoreDateBaseSettings
    {
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
