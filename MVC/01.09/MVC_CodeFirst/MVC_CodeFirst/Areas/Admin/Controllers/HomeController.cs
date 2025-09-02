using Microsoft.AspNetCore.Mvc;
using MVC_CodeFirst.Models.ViewModels;
using MVC_CodeFirst.Services.Abstracts;
using MVC_CodeFirst.Services.Concretes;

namespace MVC_CodeFirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movieViewModel)
        {
            var result = _movieService.CreateMovie(movieViewModel);
            if (result == Models.Enums.MessageStatus.Success)
            {
                TempData["success"] = "veri kaydedildi!";
            }
            else if (result == Models.Enums.MessageStatus.Error)
            {
                TempData["error"] = "bir hata meydana geldi. Console ekranına bakın.";
            }

            return RedirectToAction("Index");
        }
    }
}
