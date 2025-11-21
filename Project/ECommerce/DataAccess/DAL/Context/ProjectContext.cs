using DAL.Configurations.Concretes;
using DAL.Entities.Concretes;
using DAL.Entities.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Context
{
    public class ProjectContext:IdentityDbContext
    {
        public ProjectContext() { }
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {
            
        }

        //Dbset
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPermission> SupplierPermissions { get; set; }


        //Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            //Eğer daha önce bir veri,tabanı tanımlaması yapılmadıysa o zaman tnaımla işlemini gerçekleştir.
            if (!optionsBuilder.IsConfigured)
            {


                //Aşğaıdaki connectionstring işlemlerinin bir karşılığı da MVC katmanı içerisinde appsettings.json tarafınd olması gerekmektedir.

                var fatihConnection = "server=DESKTOP-J4PTH70;database=Yzl3447_ProjectDB;uid=sa;pwd=123;TrustServerCertificate=True;";

                var DefaultConnection = "Server=DESKTOP-E0P9L99\\SQLEXPRESS01;database=Yzl3447_ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;";

                //var aliConnection = "Server=(localdb)\\MSSQLLocalDB;Database=Yzl3447_ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(DefaultConnection);






                base.OnConfiguring(optionsBuilder);
            }
        }


        //ModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Uzun işlem
            //Category Customize
            //builder.Entity<Category>()
            //    .Property(x => x.CategoryName)
            //    .HasMaxLength(255)
            //    .IsRequired(true);

            //builder.Entity<Category>()
            //  .Property(x => x.Description)
            //  .IsRequired(false)
            //  .HasMaxLength(500);

            //builder.Entity<Category>()
            //  .Property(x => x.ModifiedComputerName)
            //  .IsRequired(false)
            //  .HasMaxLength(255);





            //Category Fake Data
            //todo 3: Bogus kütüphanesi ile fake dataalr eklenecek.
            //List<Category> categories = new List<Category>
            //{
            //    new Category{ID=1, CategoryName="Test Category 1",Description="Test Category Description 1"},
            //    new Category{ID=2, CategoryName="Test Category 2",Description="Test Category Description 2"},
            //    new Category{ID=3, CategoryName="Test Category 3",Description="Test Category Description 3"}
            //};

            //builder.Entity<Category>()
            //    .HasData(categories); 
            #endregion


            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new ShipperConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new SupplierPermissionConfiguration());

            //todo: UserRole adında bir class oluşturulacak. bunun sebebi uygulama henüz ayağaya kaldırılmadan önce varsayılan rollerle birlikte ayağa kaldırılması gerekmektedir.



            base.OnModelCreating(builder);
        }


    }
}
