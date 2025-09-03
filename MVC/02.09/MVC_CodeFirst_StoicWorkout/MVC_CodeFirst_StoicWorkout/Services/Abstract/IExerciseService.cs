using MVC_CodeFirst_StoicWorkout.Models.Enums;
using MVC_CodeFirst_StoicWorkout.Models.ViewModels;
using MVC_CodeFirst_StoicWorkout.Repositories.Abstract;


namespace MVC_CodeFirst_StoicWorkout.Services.Abstract
{
    public interface IExerciseService
    {
        List<ExerciseListViewModel> GetAllExercises();
        MessageStatus CreateExercise(ExerciseListViewModel createViewModel);
    }
}
