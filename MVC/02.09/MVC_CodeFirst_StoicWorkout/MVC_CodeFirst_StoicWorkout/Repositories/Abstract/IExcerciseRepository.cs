using MVC_CodeFirst_StoicWorkout.Models.Entities;

namespace MVC_CodeFirst_StoicWorkout.Repositories.Abstract
{
    public interface IExcerciseRepository
    {
        void Create(Exercise exercise);
        List<Exercise> List();

    }
}
