using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Her kategori'nin benzersiz anahtarı ID özelliğidir.
            builder.HasKey(x => x.ID); //PK
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(category => category.CategoryId);
        }
    }
}
