using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_StoicWorkout.Models.Entities;

namespace MVC_CodeFirst_StoicWorkout.Context
{
    public class StoicWorkoutContext:DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E0P9L99\\SQLEXPRESS01;database=MVC_CodeFirst_StoicWorkout;Trusted_Connection=True;TrustServerCertificate=True;");

                base.OnConfiguring(optionsBuilder);
            }
            
        }


    }
}
