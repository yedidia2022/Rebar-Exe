using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarProject.Models
{
    [BsonIgnoreExtraElements]

    public class Account
    {
        //אולי כדאי לעשות רק את זה וקונרלטר בשביל שיהיהאיך לפנות מהלקוח
        
        public List<Order>? Orders { get; set; } 
       
        public double SumForTheOrders { get; set; } 
       

    }
}
   

