using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst.Models.Entities;

namespace MVC_CodeFirst.Context
{
    public class MovieContext:DbContext
    {

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E0P9L99\\SQLEXPRESS01;database=MVC_MovieDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
