namespace RebarProject.Models
{
    public class ShakeForOrder
    {
        public Shake Shake { get; set; }
        public double Price {  get; set; }
        public int Amount {  get; set; }

        public ShakeForOrder(Shake shake,double price,int amount)
        { //צריך לקרוא לבנאי העתקה פה.
            this.Shake = shake;
            this.Price = price;
            this.Amount = amount;
        }
    }
}
