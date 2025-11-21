using DAL.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations.Concretes
{
    public class SupplierPermissionConfiguration : IEntityTypeConfiguration<SupplierPermission>
    {
        public void Configure(EntityTypeBuilder<SupplierPermission> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Permission)
                   .IsRequired()
                   .HasMaxLength(50);

            //  İlişki: SupplierPermission -> Supplier (Many-to-1)
            builder.HasOne(x => x.Supplier)
                   .WithMany(x => x.Permissions)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);

            //  Index: Hızlı sorgu için
            builder.HasIndex(x => new { x.SupplierId, x.Permission });

            //  Seed data
            builder.HasData(DAL.Seeds.SupplierPermissionSeeder.GetFakeSupplierPermissions());
        }
    }
}