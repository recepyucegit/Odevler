using System.Reflection.Metadata.Ecma335;

namespace CA_StreetliftingCodeFirst.Models.Entities
{
    public class Measurament
    {

        public int Id { get; set; }
        public int NeckMeasure { get; set; }

        public int ChestMeasure { get; set; }

        public  int BellyMeasure { get; set; }

        public int QuadricepsMeasure { get; set; }

        public int UserId { get; set; }
        public User AppUsers { get; set; }

        
    }
}
