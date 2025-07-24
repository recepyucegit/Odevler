using CA_StreetliftingCodeFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_StreetliftingCodeFirst.Models.Seeds
{
    internal class RoutineSeedData
    {
        public static List<Routine> routineSeedData = new List<Routine>
           
        
        {
            new Routine
            {
                Id = 1,
                FullBody = "Deadlift-Squat-BenchPress-PullUp-HollowBodyHold",
                UpperBody = "Dips-Row-Pushup  ",
                LowerBody = "Squat-Plank",
                Push = "OHP-BenchPress",
                Pull = "Row- Pullup ",
                Legs = "Squat",
                Core = "Deadlift-Plank-LegRaise",
                
            },



        };





    }
}
