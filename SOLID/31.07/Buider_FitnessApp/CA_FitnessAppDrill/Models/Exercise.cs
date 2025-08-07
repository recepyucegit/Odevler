using System.Reflection.Metadata.Ecma335;

namespace CA_FitnessAppDrill.Models
{
    internal class Exercise
    {
        public string  PullUp { get; set; }
        public string PushUp { get; set; }
        public string Dips { get; set; }
        public string MuscleUp { get; set; }
        public string HandStandPushUp { get; set; }
        public string FrontLever { get; set; }
        public string Hafesto { get; set; }

        public override string ToString()
        {
            return PullUp+"\n" +
                PushUp + "\n" +
                Dips + "\n" +
                MuscleUp + "\n" +
                HandStandPushUp + "\n" +
                FrontLever + "\n" +
                Hafesto;
        }
       

    }
}
