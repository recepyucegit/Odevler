using DAL.Configurations.Abstracts;
using DAL.Entities.Concretes;
using DAL.Seeds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations.Concretes
{
    internal class CategoryConfiguration:BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {


            builder
                .Property(x => x.CategoryName)
                .HasMaxLength(255)
                .IsRequired(true);

            builder
              .Property(x => x.Description)
              .IsRequired(false)
              .HasMaxLength(500);


            //Fake Categories
            //List<Category> categories = new List<Category>
            //{
            //    new Category{ID=1, CategoryName="Test Category 1",Description="Test Category Description 1"},
            //    new Category{ID=2, CategoryName="Test Category 2",Description="Test Category Description 2"},
            //    new Category{ID=3, CategoryName="Test Category 3",Description="Test Category Description 3"}
            //};

            //builder
            //    .HasData(categories);

            builder.HasData(CategorySeeder.GetFakeCategories());

            base.Configure(builder);
        }
    }
}
