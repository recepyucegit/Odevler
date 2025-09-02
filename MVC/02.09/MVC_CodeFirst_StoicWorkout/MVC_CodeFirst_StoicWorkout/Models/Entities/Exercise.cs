using System.Reflection.Metadata.Ecma335;

namespace MVC_CodeFirst_StoicWorkout.Models.Entities
{
    public class Exercise
    {
        public int ID { get; set; }
        public string PullUp   { get; set; }
        public string PushUp { get; set; }
        public string  Squat { get; set; }
        public string MuscleUp { get; set; }
        public string Dip { get; set; }
        public string Lunge { get; set; }

    }
}
