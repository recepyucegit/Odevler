using CA_FitnessAppDrill.Abstract;

namespace CA_FitnessAppDrill.Directors
{
    internal class Director
    {
        public void Construct(IExercise exercise)
        {
            exercise.BuildPullUp();
            exercise.BuildPushUp();
            exercise.BuildDips();
            exercise.BuildMuscleUp();
            exercise.BuildHandStandPushUp();
            exercise.BuildFrontLever();
            exercise.BuildHafesto();


        }
    }
}
