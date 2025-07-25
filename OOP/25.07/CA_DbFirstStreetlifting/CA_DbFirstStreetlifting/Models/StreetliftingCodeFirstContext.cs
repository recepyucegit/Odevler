using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_DbFirstStreetlifting.Models;

public partial class StreetliftingCodeFirstContext : DbContext
{
    public StreetliftingCodeFirstContext()
    {
    }

    public StreetliftingCodeFirstContext(DbContextOptions<StreetliftingCodeFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Measurament> Measuraments { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E0P9L99\\SQLEXPRESS01;database=StreetliftingCodeFirst;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Measurament>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Measuraments_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Measuraments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.HasMany(d => d.Exercises).WithMany(p => p.Routines)
                .UsingEntity<Dictionary<string, object>>(
                    "RoutineAndExercise",
                    r => r.HasOne<Exercise>().WithMany().HasForeignKey("ExerciseId"),
                    l => l.HasOne<Routine>().WithMany().HasForeignKey("RoutineId"),
                    j =>
                    {
                        j.HasKey("RoutineId", "ExerciseId");
                        j.ToTable("RoutineAndExercise");
                        j.HasIndex(new[] { "ExerciseId" }, "IX_RoutineAndExercise_ExerciseId");
                    });
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_UserDetails_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.UserDetail).HasForeignKey<UserDetail>(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
