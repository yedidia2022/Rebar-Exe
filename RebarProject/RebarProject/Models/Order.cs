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
        public double SumPayment {
            get { return SumPayment; }
            set
            {
                if (value > 0)
                    this.SumPayment = value;
            }
        }
        [BsonElement("id")]
        public Guid Id { get; } 
        [BsonElement("customerName")]
        public string CustomerName { get; set; }=string.Empty;  
        [BsonElement("orderDate")]
        public DateTime OrderDate {
            get { return OrderDate; }
            set
            {
                if (value > DateTime.Today)
                    this.OrderDate = value;
            }
        }

        [BsonElement("orderStartTime")]
        public DateTime OrderStartTime { get; set; }
        [BsonElement("orderEndTime")]
        public DateTime OrderEndTime { get; set; }
        [BsonElement("sales")]
        public List<Sale>? Sales { get;  set; }

        public double TimeToPrepare
        {
            get;
            set;
        }

        public Order() { 
        Id = Guid.NewGuid();
        }

    }
}
   

