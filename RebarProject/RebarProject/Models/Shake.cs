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
        public Guid Id { get;  }
        [BsonElement("priceForSmall")]
        public double PriceForSmall { 
            get { return PriceForSmall; }
            set {if (value > 0)
                    this.PriceForSmall = value;
            } }
        [BsonElement("priceForMedium")]
        public double PriceForMedium {
            get { return PriceForMedium; }
            set
            {
                if (value > 0)
                    this.PriceForMedium = value;
            }
        }
        [BsonElement("priceForLarge")]

        public double PriceForLarge {
            get { return PriceForLarge; }
            set
            {
                if (value > 0)
                    this.PriceForLarge = value;
            }
        }

        public Shake()
        {
            
            Id = Guid.NewGuid();
        }
        public Shake(Shake shake)
        {
            Name = shake.Name;
            Description = shake.Description;
            PriceForSmall = shake.PriceForSmall;
            PriceForMedium = shake.PriceForMedium;
            PriceForLarge = shake.PriceForLarge;
            Id = shake.Id;

        }

    }
}
