using Application.DTOs.CartDTOs;
using Application.ServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// MVC Sepet Controller - Session tabanlı sepet işlemleri
    /// </summary>
    public class CartController : Controller
    {
        private readonly CartServiceManager _cartServiceManager;
        private readonly ProductServiceManager _productServiceManager;

        public CartController(
            CartServiceManager cartServiceManager,
            ProductServiceManager productServiceManager)
        {
            _cartServiceManager = cartServiceManager;
            _productServiceManager = productServiceManager;
        }

        /// <summary>
        /// Sepet sayfası - GET: /Cart/Index
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartServiceManager.GetCart();
            return View(cart);
        }

        /// <summary>
        /// Sepete ürün ekle - POST: /Cart/AddToCart
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var dto = new AddToCartDTO
            {
                ProductId = productId,
                Quantity = quantity
            };

            var result = await _cartServiceManager.AddToCartAsync(dto);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            // Ürün listesine geri dön veya sepete yönlendir
            return RedirectToAction("Index", "Product");
        }

        /// <summary>
        /// Sepete AJAX ile ürün ekle - POST: /Cart/AddToCartAjax
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddToCartAjax([FromBody] AddToCartDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Geçersiz veri!" });
            }

            var result = await _cartServiceManager.AddToCartAsync(dto);

            return Json(new
            {
                success = result.Success,
                message = result.Message,
                cartItemCount = _cartServiceManager.GetCartItemCount(),
                cartTotalAmount = _cartServiceManager.GetCartTotalAmount()
            });
        }

        /// <summary>
        /// Sepetten ürün çıkar - POST: /Cart/RemoveFromCart
        /// </summary>
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var result = _cartServiceManager.RemoveFromCart(productId);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ürün miktarını güncelle - POST: /Cart/UpdateQuantity
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
        {
            var result = await _cartServiceManager.UpdateQuantityAsync(productId, quantity);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// AJAX ile miktar güncelle - POST: /Cart/UpdateQuantityAjax
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateQuantityAjax(int productId, int quantity)
        {
            var result = await _cartServiceManager.UpdateQuantityAsync(productId, quantity);

            return Json(new
            {
                success = result.Success,
                message = result.Message,
                cartItemCount = _cartServiceManager.GetCartItemCount(),
                cartTotalAmount = _cartServiceManager.GetCartTotalAmount()
            });
        }

        /// <summary>
        /// Sepeti temizle - POST: /Cart/Clear
        /// </summary>
        [HttpPost]
        public IActionResult Clear()
        {
            var result = _cartServiceManager.ClearCart();

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Sepet özeti widget - Partial View
        /// Layout'ta kullanılmak üzere
        /// </summary>
        [HttpGet]
        public IActionResult CartSummary()
        {
            var cart = _cartServiceManager.GetCart();
            return PartialView("_CartSummary", cart);
        }

        /// <summary>
        /// AJAX ile sepet bilgilerini getir
        /// </summary>
        [HttpGet]
        public IActionResult GetCartInfo()
        {
            var cart = _cartServiceManager.GetCart();

            return Json(new
            {
                itemCount = cart.TotalItemCount,
                totalAmount = cart.TotalAmount,
                items = cart.Items
            });
        }

        /// <summary>
        /// Ödeme sayfasına git
        /// </summary>
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartServiceManager.GetCart();

            if (!cart.Items.Any())
            {
                TempData["ErrorMessage"] = "Sepetiniz boş!";
                return RedirectToAction("Index");
            }

            return View(cart);
        }
    }
}