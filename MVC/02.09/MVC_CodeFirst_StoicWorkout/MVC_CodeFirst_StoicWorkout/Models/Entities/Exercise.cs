using System.Reflection.Metadata.Ecma335;

namespace MVC_CodeFirst_StoicWorkout.Models.Entities
{
    public class Exercise
    {
        public int ID { get; set; }
        public string ExerciseName { get; set; }
        public string RepRange   { get; set; }
        public string Sets       { get; set; }
        public string RestTime   { get; set; }
        public string Difficulty { get; set; }
        public string Equipment  { get; set; }
        public string TargetMuscleGroup { get; set; }

    }
}
