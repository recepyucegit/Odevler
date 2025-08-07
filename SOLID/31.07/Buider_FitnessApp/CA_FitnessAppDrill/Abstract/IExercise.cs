using CA_FitnessAppDrill.Models;

namespace CA_FitnessAppDrill.Abstract
{
    internal interface IExercise
    {
        public void BuildPullUp();
        public void BuildPushUp();
        public void BuildDips();
        public void BuildMuscleUp();
        public void BuildHandStandPushUp();
        public void BuildFrontLever();
        public void BuildHafesto();

        Exercise GetExercise();
    }
}
