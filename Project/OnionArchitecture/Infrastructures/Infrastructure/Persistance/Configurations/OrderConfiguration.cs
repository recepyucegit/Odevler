using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            // Primary Key
            builder.HasKey(o => o.ID);

            // Properties
            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.ShippedDate)
                .IsRequired(false);

            builder.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(o => o.ShippingAddress)
                .HasMaxLength(500)
                .IsRequired();

            // Relationships
            //builder.HasOne(o => o.User)
            //   .WithMany(u => u.Orders)
            //   .HasForeignKey(o => o.UserId)
            //   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}