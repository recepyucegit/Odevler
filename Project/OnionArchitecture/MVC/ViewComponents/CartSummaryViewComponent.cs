using Application.ServiceManager;
using Microsoft.AspNetCore.Mvc;
namespace MVC.ViewComponents
{
    /// <summary>
    /// Sepet özeti için ViewComponent
    /// Layout'ta kullanılabilir
    /// Kullanım: @await Component.InvokeAsync("CartSummary")
    /// </summary>
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly CartServiceManager _cartServiceManager;
        public CartSummaryViewComponent(CartServiceManager cartServiceManager)
        {
            _cartServiceManager = cartServiceManager;
        }
        public IViewComponentResult Invoke()
        {
            var cart = _cartServiceManager.GetCart();
            return View(cart);
        }
    }
}