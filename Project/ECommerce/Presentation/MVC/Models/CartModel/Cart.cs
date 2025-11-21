namespace MVC.Models.CartModel
{
    public class Cart
    {
        //bir alışveriş sepetinin ....'sı olur.

        public Cart()
        {
            Quantity = 1;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }

        public int Quantity { get; set; }//null=>0

        public decimal? Subtotal
        {
            get
            {
                return UnitPrice * Quantity;
            }
        } //readonly

    }
}
