using System.Reflection.Metadata.Ecma335;

namespace CA_StreetliftingCodeFirst.Models.Entities
{
    public class RoutineAndExercise
    {
        public  int RoutineId { get; set; } //PK
        public int ExerciseId { get; set; } //PK

        public Routine Routine { get; set; } // Navigation property to Routine

        public Exercise Exercise { get; set; } // Navigation property to Exercise

    }
}
