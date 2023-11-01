namespace RebarProject.Models
{
    public class ShakeForOrder
    {
        public Shake Shake { get; set; }
        public double Price {
            get { return Price; }
            set
            {
                if (value > 0)
                    this.Price = value;
            }
        }
        public string Size {  get; set; }

        public ShakeForOrder(Shake shake,double price,string size)
        { //צריך לקרוא לבנאי העתקה פה.
            this.Shake = new Shake(shake);
            this.Price = price;
            this.Size = size;
        }
    }
}
