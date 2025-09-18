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



    }
}
