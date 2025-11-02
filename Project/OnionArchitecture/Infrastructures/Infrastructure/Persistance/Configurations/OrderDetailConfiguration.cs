using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            // Primary Key
            builder.HasKey(od => od.ID);

            // Properties
            builder.Property(od => od.Quantity)
                .IsRequired();

            builder.Property(od => od.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(od => od.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Composite Key (Opsiyonel - OrderId + ProductId benzersiz olabilir)
            builder.HasIndex(od => new { od.OrderId, od.ProductId })
                .IsUnique();

            // Relationships
            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}