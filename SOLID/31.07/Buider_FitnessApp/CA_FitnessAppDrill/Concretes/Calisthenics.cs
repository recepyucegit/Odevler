using CA_FitnessAppDrill.Abstract;
using CA_FitnessAppDrill.Models;

namespace CA_FitnessAppDrill.Concretes
{
    internal class Calisthenics : IExercise
    {
        Exercise exercise= new Exercise();
        public void BuildDips()
        {
            exercise.Dips = "Dips arka kol göğüs ve omuz kaslarını etkili bir şekilde çalıştıran çok eklemli bir haraketkettir. ";
        }

        public void BuildFrontLever()
        {
            exercise.FrontLever = "Front Lever, vücut ağırlığı ile yapılan bir egzersizdir. Bu hareket, sırt, karın ve omuz kaslarını güçlendirir. " +
                "Front Lever, vücudu yatay bir pozisyonda tutmayı gerektirir ve bu da üst vücut gücünü ve kontrolünü artırır.";
        }

        public void BuildHafesto()
        {
            exercise.Hafesto = "Hafesto, vucut ağırlığı ile yapılan bir egzersizdir. Bu haraket bicepsler için oldukça etkilidir.";
        }

        public void BuildHandStandPushUp()
        {
            exercise.HandStandPushUp = "Handstand Push-Up, vücut ağırlığı ile yapılan bir egzersizdir. Bu hareket, omuz, triceps ve karın kaslarını güçlendirir. " +
                "Ayrıca denge ve koordinasyon becerilerini de geliştirir.";
        }

        public void BuildMuscleUp()
        {
            exercise.MuscleUp = "Muscle Up, vücut ağırlığı ile yapılan bir egzersizdir. Bu hareket, hem çekiş hem de itiş hareketlerini içerir ve üst vücut gücünü artırır. " +
                "Muscle Up, barfiks ve dips hareketlerinin birleşimidir.";
        }

        public void BuildPullUp()
        {
            exercise.PullUp = "Pull-Up, vücut ağırlığı ile yapılan bir egzersizdir. Bu hareket, sırt, omuz ve kol kaslarını güçlendirir. " +
                "Pull-Up, barfiks çubuğuna asılarak yapılan bir harekettir.";
        }

        public void BuildPushUp()
        {
            exercise.PushUp = "Push-Up, vücut ağırlığı ile yapılan bir egzersizdir. Bu hareket, göğüs, omuz ve triceps kaslarını güçlendirir. " +
                "Push-Up, yere paralel bir pozisyonda yapılan bir harekettir.";
        }

        public Exercise GetExercise()
        {
            return exercise;
        }
    }
}
