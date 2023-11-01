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
        public double SumPayment { get; set; }
        [BsonElement("id")]
        public Guid Id { get; set; } 
        [BsonElement("customerName")]
        public string CustomerName { get; set; }=string.Empty;  
        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("orderStartTime")]
        public DateTime OrderStartTime { get; set; }
        [BsonElement("orderEndTime")]
        public DateTime OrderEndTime { get; set; }
        [BsonElement("sales")]
        public List<Sale>? Sales { get; set; }

        public Order() { 
        Id = Guid.NewGuid();
        }

    }
}
   

