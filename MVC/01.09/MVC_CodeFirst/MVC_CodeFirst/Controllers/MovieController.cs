using Microsoft.AspNetCore.Mvc;
using MVC_CodeFirst.Models;
using MVC_CodeFirst.Models.ViewModels;
using MVC_CodeFirst.Repositories.Abstracts;
using MVC_CodeFirst.Services.Abstracts;

namespace MVC_CodeFirst.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        #region Repository Pattern
        ////constructor açarak ve içerisine Program.cs bünyesinde dahil edilen custom servislerden istediğimizi kullanabiliriz.


        //#region Dependency Injection
        //private readonly IMovieRepository _movieRepository;

        //public MovieController(IMovieRepository movieRepository)
        //{
        //    _movieRepository = movieRepository;
        //} 
        //#endregion


        ////Pages Action 

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(string movieTitle, string movieDescription)
        //{
        //    try
        //    {
        //        Movie movie = new Movie
        //        {
        //            Title = movieTitle,
        //            Description = movieDescription
        //        };

        //        _movieRepository.CreateMovie(movie);
        //        //Başarılı olması durumunda TempData oluşturulacak.
        //        TempData["Success"] = $"{movie.Title} veritabanına eklendi!";


        //    }
        //    catch (Exception ex)
        //    {
        //        //Hata olması durumunda bir tempdata oluşturulacak.
        //        TempData["Error"] = ex.Message;

        //    }
        //    return View();
        //} 
        #endregion

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies= _movieService.GetMovies();

            return View(movies);
        }

        
    }
}
