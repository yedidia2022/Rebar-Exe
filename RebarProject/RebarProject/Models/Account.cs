using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarProject.Models
{
    [BsonIgnoreExtraElements]

    public class Account
    {
        //אולי כדאי לעשות רק את זה וקונרלטר בשביל שיהיהאיך לפנות מהלקוח

        [BsonElement("id")]
        public Guid Id { get;}
        [BsonElement("orders")]
        public List<Order>? Orders { get; set; }
        [BsonElement("sumForOrders")]
        public double SumForTheOrders {
            get { return SumForTheOrders; }
            set { if (value > 0)
                    SumForTheOrders = value;
            } } 

        public Account() {
            this.Id = Guid.NewGuid();

        }
       

    }
}
   

