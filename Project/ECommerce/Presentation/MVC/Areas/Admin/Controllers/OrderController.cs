using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly IOrderServiceManager _orderService;
        private readonly IOrderDetailServiceManager _orderDetailService;
        private readonly IShipperServiceManager _shipperService;
        private readonly IProductServiceManager _productService;

        public OrderController(
            IOrderServiceManager orderService,
            IOrderDetailServiceManager orderDetailService,
            IShipperServiceManager shipperService,
            IProductServiceManager productService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _shipperService = shipperService;
            _productService = productService;
        }

        // Siparişleri listele
        public IActionResult Index()
        {
            var orders = _orderService.GetAll().OrderByDescending(x => x.CreatedDate).ToList();

            // Her order için shipper bilgisini manuel olarak yükle
            foreach (var order in orders)
            {
                if (order.ShipperId.HasValue)
                {
                    order.Shipper = _shipperService.FindById(order.ShipperId.Value);
                }
            }

            return View(orders);
        }

        // Kargo bilgisi güncelleme sayfası
        public IActionResult UpdateShipper(int id)
        {
            var order = _orderService.FindById(id);
            if (order == null)
            {
                TempData["Error"] = "Sipariş bulunamadı.";
                return RedirectToAction("Index");
            }

            // Mevcut shipper bilgisini yükle
            if (order.ShipperId.HasValue)
            {
                order.Shipper = _shipperService.FindById(order.ShipperId.Value);
            }

            // Aktif kargo firmalarını dropdown için gönder
            ViewBag.Shippers = _shipperService.GetActives()
                .Where(s => s.IsActive)
                .ToList();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShipper(int id, int shipperId)
        {
            try
            {
                var order = _orderService.FindById(id);
                if (order == null)
                {
                    TempData["Error"] = "Sipariş bulunamadı.";
                    return RedirectToAction("Index");
                }

                // Shipper'ı kontrol et
                var shipper = _shipperService.FindById(shipperId);
                if (shipper == null)
                {
                    TempData["Error"] = "Geçersiz kargo firması seçimi.";
                    return RedirectToAction("UpdateShipper", new { id = id });
                }

                // Order'ı güncelle
                order.ShipperId = shipperId;
                await _orderService.UpdateAsync(order);

                TempData["Success"] = $"Sipariş #{order.ID} kargo firmasına ({shipper.ShipperName}) teslim edildi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Güncelleme sırasında hata oluştu: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Sipariş detaylarını görüntüle
        public IActionResult Details(int id)
        {
            var order = _orderService.FindById(id);
            if (order == null)
            {
                TempData["Error"] = "Sipariş bulunamadı.";
                return RedirectToAction("Index");
            }

            // Shipper bilgisini yükle
            if (order.ShipperId.HasValue)
            {
                order.Shipper = _shipperService.FindById(order.ShipperId.Value);
            }

            // OrderDetail'leri ve Product bilgilerini getir
            var orderDetails = _orderDetailService.GetAll()
                .Where(od => od.OrderId == id)
                .ToList();

            // Her orderDetail için product bilgisini yükle
            foreach (var detail in orderDetails)
            {
                detail.Product = _productService.FindById(detail.ProductId);
            }

            ViewBag.OrderDetails = orderDetails;
            ViewBag.TotalAmount = orderDetails.Sum(od => od.Quantity * od.UnitPrice);

            return View(order);
        }
    }
}