namespace CA_StreetliftingCodeFirst.Models.Entities
{
    public class Routine
    {
        public int Id { get; set; }

        public string? FullBody   { get; set; }

        public string? UpperBody  { get; set; }
        public string? LowerBody  { get; set; }

        public string? Push       { get; set; }
        public string? Pull       { get; set; }
        public string? Legs       { get; set; }

        public string? Core       { get; set; }

        public List<RoutineAndExercise> RoutinesExercises { get; set; } 

    }
}
