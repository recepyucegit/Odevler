using Application.DTOs.CartDTOs;
using Application.Extensions;
using Application.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.ServiceManager
{
    /// <summary>
    /// Sepet işlemlerini yöneten servis
    /// Session tabanlı sepet yönetimi
    /// </summary>
    public class CartServiceManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private const string CartSessionKey = "ShoppingCart";

        public CartServiceManager(
            IHttpContextAccessor httpContextAccessor,
            IProductRepository productRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Mevcut sepeti getir, yoksa yeni sepet oluştur
        /// </summary>
        public CartDTO GetCart()
        {
            var session = _httpContextAccessor.HttpContext?.Session;

            if (session == null)
                return new CartDTO();

            var cart = session.GetObject<CartDTO>(CartSessionKey);

            if (cart == null)
            {
                cart = new CartDTO();
                session.SetObject(CartSessionKey, cart);
            }

            return cart;
        }

        /// <summary>
        /// Sepeti kaydet
        /// </summary>
        private void SaveCart(CartDTO cart)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            session?.SetObject(CartSessionKey, cart);
        }

        /// <summary>
        /// Sepete ürün ekle
        /// </summary>
        public async Task<(bool Success, string Message)> AddToCartAsync(AddToCartDTO dto)
        {
            try
            {
                // Ürünü veritabanından getir
                var product = await _productRepository.GetByIdAsync(dto.ProductId);

                if (product == null)
                {
                    return (false, "Ürün bulunamadı!");
                }

                // Stok kontrolü
                if (product.UnitsInStock < dto.Quantity)
                {
                    return (false, $"Yeterli stok yok! Mevcut stok: {product.UnitsInStock}");
                }

                // Sepeti getir
                var cart = GetCart();

                // Cart item oluştur
                var cartItem = new CartItemDTO
                {
                    ProductId = product.ID,
                    ProductName = product.Name,
                    UnitPrice = product.UnitPrice,
                    Quantity = dto.Quantity,
                    Description = product.Description
                };

                // todo: Sepete ekle
                

                // Sepeti kaydet
                SaveCart(cart);

                return (true, "Ürün sepete eklendi!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Sepetten ürün çıkar
        /// </summary>
        public (bool Success, string Message) RemoveFromCart(int productId)
        {
            try
            {
                var cart = GetCart();

                var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
                if (item == null)
                {
                    return (false, "Ürün sepette bulunamadı!");
                }

                //todo: ürünün sepetten kaldırılması.
                SaveCart(cart);

                return (true, "Ürün sepetten çıkarıldı!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Ürün miktarını güncelle
        /// </summary>
        public async Task<(bool Success, string Message)> UpdateQuantityAsync(int productId, int quantity)
        {
            try
            {
                var cart = GetCart();

                var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
                if (item == null)
                {
                    return (false, "Ürün sepette bulunamadı!");
                }

                // Stok kontrolü
                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null)
                {
                    return (false, "Ürün bulunamadı!");
                }

                if (product.UnitsInStock < quantity)
                {
                    return (false, $"Yeterli stok yok! Mevcut stok: {product.UnitsInStock}");
                }

                //todo: ürünün sepette güncellenmesi
                SaveCart(cart);

                return (true, "Miktar güncellendi!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Sepeti temizle
        /// </summary>
        public (bool Success, string Message) ClearCart()
        {
            try
            {
                var cart = GetCart();
              //todo: sepetin temizlenmesi
                SaveCart(cart);

                return (true, "Sepet temizlendi!");
            }
            catch (Exception ex)
            {
                return (false, $"Hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Sepetteki ürün sayısını getir
        /// </summary>
        public int GetCartItemCount()
        {
            var cart = GetCart();
            return cart.TotalItemCount;
        }

        /// <summary>
        /// Sepet toplam tutarını getir
        /// </summary>
        public decimal GetCartTotalAmount()
        {
            var cart = GetCart();
            return cart.TotalAmount;
        }

        /// <summary>
        /// Sepette belirli bir ürün var mı kontrol et
        /// </summary>
        public bool IsProductInCart(int productId)
        {
            var cart = GetCart();
            return cart.Items.Any(x => x.ProductId == productId);
        }

        /// <summary>
        /// Sepetteki ürün miktarını getir
        /// </summary>
        public int GetProductQuantityInCart(int productId)
        {
            var cart = GetCart();
            var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            return item?.Quantity ?? 0;
        }
    }
}