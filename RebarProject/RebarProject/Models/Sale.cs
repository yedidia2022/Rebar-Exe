using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarProject.Models
{
    public class Sale
    {
        
        public double Precent { get; set; } 
       
        public string Description { get; set; } = String.Empty;
       

    }
}
