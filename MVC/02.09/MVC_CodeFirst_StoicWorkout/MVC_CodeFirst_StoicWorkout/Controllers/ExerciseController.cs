using Microsoft.AspNetCore.Mvc;
using MVC_CodeFirst_StoicWorkout.Models.ViewModels.ExerciseViewModels;
using MVC_CodeFirst_StoicWorkout.Services.Abstract;

namespace MVC_CodeFirst_StoicWorkout.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        public IActionResult Index()
        {
           var exercise= _exerciseService.GetAllExercises();
            return View(exercise);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExerciseCreateViewModel exerciseCreate)
        {
            var result = _exerciseService.CreateExercise(exerciseCreate);
            if (result== Models.Enums.MessageStatus.Success)
            {
                TempData["succsess"] = "veri kaydedildi!";
            }
            else if (result==Models.Enums.MessageStatus.Error)

            {
                TempData["error"] = "veri kaydedilirken bir hata oluştu!";

            }
            return RedirectToAction("index");

            
        }
    }
}
