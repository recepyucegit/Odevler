namespace MVC.Models.CartModel
{
    public class CartItem
    {

        //public List<Cart> _myCart=new List<Cart>();

        public Dictionary<int, Cart> _myCart = new Dictionary<int, Cart>();
        //Sepete ürün eklenmesi

        public void AddItem(Cart cart)
        {
            if (_myCart.ContainsKey(cart.Id))
            {
                _myCart[cart.Id].Quantity++;
            }
            else
            {
                _myCart.Add(cart.Id, cart);
            }
        }
    }
}
