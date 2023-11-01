using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RebarProject.Models
{
    public class Sale
    {
        
        public double Precent {
            get { return Precent; }
            set
            {
                if (value > 0)
                    this.Precent = value;
            }
        } 
       
        public string Description { get; set; } = String.Empty;
       

    }
}
