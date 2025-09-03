



using MVC_CodeFirst_StoicWorkout.Models.Enums;
using MVC_CodeFirst_StoicWorkout.Models.ViewModels;
using MVC_CodeFirst_StoicWorkout.Services.Abstract;
using MVC_CodeFirst_StoicWorkout.Repositories.Abstract;
using MVC_CodeFirst_StoicWorkout.Repositories.Concretes;
using MVC_CodeFirst_StoicWorkout.Models.Entities;


namespace MVC_CodeFirst_StoicWorkout.Services.Concretes


{
    public class ExerciseService: IExerciseService
    {
        private readonly IExcerciseRepository _exerciseRepository;

        public ExerciseService(IExcerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public MessageStatus CreateExercise(ExerciseListViewModel createViewModel)
        {
            try
            {
                Exercise exercise = new Exercise
                {
                    ExerciseName = createViewModel.ExerciseName,
                    RepRange = createViewModel.RepRange,
                    Sets = createViewModel.Sets,
                    RestTime = createViewModel.RestTime,
                    Difficulty = createViewModel.Difficulty,
                    Equipment = createViewModel.Equipment,
                    TargetMuscleGroup = createViewModel.TargetMuscleGroup

                };
                _exerciseRepository.Create(exercise);
                return MessageStatus.Success;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return MessageStatus.Error;
            }
        }

        public List<ExerciseListViewModel> GetAllExercises()
        {
            throw new NotImplementedException();
        }
    }
}
