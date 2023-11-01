using MongoDB.Bson.Serialization.Attributes;

namespace RebarProject.Models
{
    public class DailyReport
    {
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("ordersAmount")]
        public int OrdersAmount { get; set; }
        [BsonElement("totalPayment")]
        public double TotalPayment {  get; set; }

    }
}
