using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace RebarProject.Models
{
    [BsonIgnoreExtraElements]
    public class Shake
    {
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("description")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("id")]
        public Guid Id { get; set; }
        [BsonElement("priceForSmall")]
        public double PriceForSmall { get; set; }
        [BsonElement("priceForMedium")]
        public double PriceForMedium { get; set; }
        [BsonElement("priceForLarge")]

        public double PriceForLarge { get; set; }

    }
}
