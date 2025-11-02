using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    [Authorize(Roles = "Admin")] // Admin yetkisi gerektir
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Dashboard Ana Sayfası
        public IActionResult Index()
        {
            ViewBag.Title = "Dashboard Ana Sayfa";
            return View();
        }

        // İstatistikler Sayfası
        public IActionResult Statistics()
        {
            ViewBag.Title = "İstatistikler";
            return View();
        }

        // Raporlar Sayfası
        public IActionResult Reports()
        {
            ViewBag.Title = "Raporlar";
            return View();
        }

        // Ayarlar Sayfası
        public IActionResult Settings()
        {
            ViewBag.Title = "Ayarlar";
            return View();
        }
    }
}