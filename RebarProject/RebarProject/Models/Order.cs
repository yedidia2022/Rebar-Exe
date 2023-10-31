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
        [BsonElement("id")]
        public Guid Id { get; set; } 
        [BsonElement("customerName")]
        public string CustomerName { get; set; }=string.Empty;  
        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }
        [BsonElement("sales")]
        public List<Sale>? Sales { get; set; }

    }
}
   

