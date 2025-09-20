using DAL.Entities.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ProjectContext: IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {
        }
        // onConfigiring metodu appsettings.json dosyasındaki connection stringi alır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4H6H6K3;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }






    }
}
