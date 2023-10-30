using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarProject.Models
{
    [BsonIgnoreExtraElements]

    public class Order
    {
        [BsonElement("shakeList")]
        public List<ShakeForOrder>? ShakeList { get; set; } 
        [BsonElement("sumPayment")]
        public string SumPayment { get; set; } 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("customerName")]
        public string CustomerName { get; set; }=string.Empty;  
        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }
        [BsonElement("sales")]

        public List<Sale>? Sales { get; set; }

    }
}
   

