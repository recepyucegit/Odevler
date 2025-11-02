using Domain.Entities;
using Infrastructure.Persistance.Configurations;

using Infrastructure.Persistance.SeedData;

using Infrastructure.Persistence.Configurations;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Persistance
{
    public class NorthwindDbContext : IdentityDbContext
    {
        public NorthwindDbContext()
        {
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configurations
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            //Order Configuration
            builder.ApplyConfiguration(new OrderConfiguration());
            //OrderDetail Configuration
            builder.ApplyConfiguration(new OrderDetailConfiguration());

            // Seed Data
            DatabaseSeeder.SeedData(builder);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=DESKTOP-J4PTH70;database=NorthwindOnionDB;uid=sa;pwd=123;TrustServerCertificate=True;");



            base.OnConfiguring(optionsBuilder);
        }
    }
}