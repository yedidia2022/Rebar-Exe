namespace RebarProject.Models
{
    public interface IAccountStoreDateBaseSettings
    {
        string AccountCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
