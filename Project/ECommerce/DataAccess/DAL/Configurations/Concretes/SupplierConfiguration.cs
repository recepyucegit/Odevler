using DAL.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations.Concretes
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.CompanyName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.ContactName)
                   .HasMaxLength(100);

            builder.Property(x => x.ContactTitle)
                   .HasMaxLength(100);

            builder.Property(x => x.Address)
                   .HasMaxLength(250);

            builder.Property(x => x.City)
                   .HasMaxLength(100);

            builder.Property(x => x.Country)
                   .HasMaxLength(100);

            builder.Property(x => x.Phone)
                   .HasMaxLength(50);

            // ✅ Authentication alanları
            builder.Property(x => x.Username)
                   .HasMaxLength(50);

            builder.Property(x => x.PasswordHash)
                   .HasMaxLength(255);

            builder.Property(x => x.Email)
                   .HasMaxLength(100);

            //  Unique constraint (Username varsa unique olsun)
            builder.HasIndex(x => x.Username)
                   .IsUnique()
                   .HasFilter("[Username] IS NOT NULL");  // Null'lar unique kontrolünden muaf

            //  İlişki: Supplier -> Products (1-to-Many)
            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Supplier)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            //  İlişki: Supplier -> SupplierPermissions (1-to-Many)
            builder.HasMany(x => x.Permissions)
                   .WithOne(x => x.Supplier)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);

            //  Seed data
            builder.HasData(DAL.Seeds.SupplierSeeder.GetFakeSuppliers());
        }
    }
}