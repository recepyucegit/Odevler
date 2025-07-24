using CA_StreetliftingCodeFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_StreetliftingCodeFirst.Models.Seeds
{
    internal class ExerciseSeedData
    {
        public static List<Exercise> exercisesSeedData= new List<Exercise>
        {
            new Exercise
            {
             Id=1,
                DeadLift="Deadlift güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır."
                ,Squat="Squat güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılı." ,
                BenchPress="Bench Press güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır."
                ,OverHeadPress="Overhead Press güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır."
                ,PullUp="Pull Up güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır."


            },
            new Exercise
            {
                Id=2,
                Dip="Dip güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır."
                ,Row="Row güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır."
                ,PushUp="Push Up güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır."

            },
            new Exercise
            {
                Id=3,
                HollowBodyHold="Hollow Body Hold güçlenme fazında 30-60 sn @9 RPE olarak yapılır."
                ,Plank="Plank güçlenme fazında 30-60 @9 RPE olarak yapılır."
                ,LegRaise="Leg Raise güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır."
            }

        };

    }
}
