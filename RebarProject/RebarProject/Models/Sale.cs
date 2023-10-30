using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarProject.Models
{
    public class Sale
    {
        [BsonElement("precent")]
        public double Precent { get; set; } 
        [BsonElement("description")]
        public string Description { get; set; } = String.Empty;
       

    }
}
