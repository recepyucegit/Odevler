using MVC_CodeFirst_StoicWorkout.Context;
using MVC_CodeFirst_StoicWorkout.Models.Entities;
using MVC_CodeFirst_StoicWorkout.Repositories.Abstract;

namespace MVC_CodeFirst_StoicWorkout.Repositories.Concretes
{
    public class ExcerciseRepository: IExcerciseRepository
    {
        //Create
        StoicWorkoutContext _context=new StoicWorkoutContext();

        public void Create(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
        }


        //List
        public List<Exercise> List()
        {
            return _context.Exercises.ToList();

        }

    }
}
