using BLL.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DAL.Context; // ProjectContext burada
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
       private readonly IOrderServiceManager _orderService;
        private readonly IOrderDetailServiceManager _orderDetailService;
        private readonly IShipperServiceManager _shipperService;
        private readonly ICategoryServiceManager _categoryService;
        private readonly IProductServiceManager _productService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserServiceManager _userServiceManager;

        public HomeController(
            IOrderServiceManager orderService,
            IOrderDetailServiceManager orderDetailService,
            IShipperServiceManager shipperService,
            ICategoryServiceManager categoryService,
            IProductServiceManager productService,
            UserManager<IdentityUser> userManager,
            IUserServiceManager userServiceManager
            )
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _shipperService = shipperService;
            _categoryService = categoryService;
            _productService = productService;
            _userManager = userManager;
            _userServiceManager = userServiceManager;
        }
        
        public IActionResult Index()
        {
             // Son 10 siparişi getir
            var recentOrders = _orderService.GetAll()
                .OrderByDescending(x => x.CreatedDate)
                .Take(10)
                .ToList();

            // Her order için shipper bilgisini yükle
            foreach (var order in recentOrders)
            {
                if (order.ShipperId.HasValue)
                {
                    order.Shipper = _shipperService.FindById(order.ShipperId.Value);
                }
            }

            // Dashboard istatistikleri
            var totalOrders = _orderService.GetAll().Count();
            var pendingOrders = _orderService.GetAll().Count(o => o.ShipperId == null);
            var shippedOrders = _orderService.GetAll().Count(o => o.ShipperId != null);
            var totalProducts = _productService.GetAll().Count();
            var totalCategories = _categoryService.GetAll().Count();

            // ViewBag'e istatistikleri gönder
            ViewBag.TotalOrders = totalOrders;
            ViewBag.PendingOrders = pendingOrders;
            ViewBag.ShippedOrders = shippedOrders;
            ViewBag.TotalProducts = totalProducts;
            ViewBag.TotalCategories = totalCategories;
            ViewBag.TotalUsers = _userManager.Users.Count();


            //todo: aşağıdaki işlem servis katmanına taşınması gerekiyor.
            ViewBag.TotalRevenue = _orderDetailService.GetTotalRevenue();

            #region Servis Test İşlemleri
            //var userOrderDetails = _orderDetailService.GetUserOrderDetail();

            //var productsWithCategories = _productService.GetProductsWithCategory();

            //var usersAndRoles = _userServiceManager.GetUsersAndRoles(); 
            #endregion

            return View(recentOrders);
        }
    }
}