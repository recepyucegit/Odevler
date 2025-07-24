using Microsoft.EntityFrameworkCore;

using CA_StreetliftingCodeFirst.Models.Entities;
using CA_StreetliftingCodeFirst.Models.Seeds;
using System.Security.Cryptography.X509Certificates;


namespace CA_StreetliftingCodeFirst.Models.Context

{
    public class StreetliftingContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<Routine> Routines { get; set; }

        public DbSet<Measurament> Measuraments { get; set; }

        public DbSet<Exercise> Exercises { get; set; }



        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E0P9L99\\SQLEXPRESS01;Database=StreetliftingCodeFirst;Trusted_Connection=True;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region One to One Relotionship
            // One to One Mapping

            modelBuilder.Entity<User>()
                .HasOne(x => x.AppUserDetails)  // Her User bir UserDetail'e aittir
                .WithOne(y => y.AppUsers)       // Her UserDetail bir User'a aittir
               .HasForeignKey<UserDetail>(d=>d.UserId); // UserDetail tablosundaki UserId, User tablosunun Id'sine referans verir





            #endregion


            #region One to Many Relotionship

            modelBuilder.Entity<Measurament>()
                .HasOne(x => x.AppUsers)
                .WithMany(u => u.Measuraments)
                .HasForeignKey(m => m.UserId); // Measurament tablosundaki UserId, User tablosunun Id'sine referans verir




            #endregion

            #region Many to Many Mapping

            //Composite Key for Many to Many Mapping

            modelBuilder.Entity<RoutineAndExercise>()
                .HasKey(x => new { x.RoutineId, x.ExerciseId });

            modelBuilder.Entity<RoutineAndExercise>()
                .HasOne(x=>x.Exercise)
                .WithMany(y => y.RoutinesExercises)
                .HasForeignKey(x => x.ExerciseId);

            modelBuilder.Entity<RoutineAndExercise>()
                .HasOne(x => x.Routine)
                .WithMany(y => y.RoutinesExercises)
                .HasForeignKey(x => x.RoutineId);




            #endregion


















            // User Seed Data
            modelBuilder.Entity<User>()
                .HasData(UserSeedData.usersData);

            // UserDetails Seed Data

            modelBuilder.Entity<UserDetail>()
                .HasData(UserDetailSeedData.userDetailsData);

            //Exercise Seed Data

            modelBuilder.Entity<Exercise>()
                .HasData(ExerciseSeedData.exercisesSeedData);

            //Routine Seed Data

            modelBuilder.Entity<Routine>()
                .HasData(RoutineSeedData.routineSeedData);












            base.OnModelCreating(modelBuilder);

        }



    }
}
