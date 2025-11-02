using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name).IsRequired(true).HasMaxLength(155);
            builder.Property(product => product.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(product => product.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(product => product.UnitPrice).IsRequired(true);


            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierId);


        }
    }
}
