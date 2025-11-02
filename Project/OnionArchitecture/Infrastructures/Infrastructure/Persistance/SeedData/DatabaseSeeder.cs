using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.SeedData
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Sabit seed - her seferinde aynı veriler üretilir
            Randomizer.Seed = new Random(12345);

            // 1. Kategoriler
            var categories = GenerateCategories();
            modelBuilder.Entity<Category>().HasData(categories);

            // 2. Tedarikçiler
            var suppliers = GenerateSuppliers();
            modelBuilder.Entity<Supplier>().HasData(suppliers);

            // 3. Ürünler
            var products = GenerateProducts(categories, suppliers);
            modelBuilder.Entity<Product>().HasData(products);
        }

        /// <summary>
        /// 10 kategori oluştur
        /// </summary>
        private static List<Category> GenerateCategories()
        {
            var categoryNames = new[]
            {
                "Elektronik",
                "Giyim",
                "Kitap & Kırtasiye",
                "Ev & Yaşam",
                "Spor & Outdoor",
                "Oyuncak & Hobi",
                "Kozmetik & Kişisel Bakım",
                "Gıda & İçecek",
                "Anne & Bebek",
                "Ayakkabı & Çanta"
            };

            var categories = new List<Category>();
            var faker = new Faker("tr");

            for (int i = 0; i < categoryNames.Length; i++)
            {
                categories.Add(new Category
                {
                    ID = i + 1,
                    Name = categoryNames[i],
                    Description = faker.Lorem.Sentence(8, 5),
                    CreatedDate = faker.Date.Past(2)
                });
            }

            return categories;
        }

        /// <summary>
        /// 20 tedarikçi oluştur
        /// </summary>
        private static List<Supplier> GenerateSuppliers()
        {
            var suppliers = new List<Supplier>();
            var faker = new Faker("tr");

            for (int i = 1; i <= 20; i++)
            {
                suppliers.Add(new Supplier
                {
                    ID = i,
                    CompanyName = $"{faker.Company.CompanyName()} {faker.PickRandom("A.Ş.", "Ltd. Şti.", "San. Tic.")}",
                    ContactName = faker.Name.FullName(),
                    PhoneNumber = faker.Phone.PhoneNumber("0### ### ## ##"),
                    Address = $"{faker.Address.StreetAddress()}, {faker.Address.City()}",
                    CreatedDate = faker.Date.Past(2)
                });
            }

            return suppliers;
        }

        /// <summary>
        /// 100 ürün oluştur
        /// </summary>
        private static List<Product> GenerateProducts(List<Category> categories, List<Supplier> suppliers)
        {
            var products = new List<Product>();
            var faker = new Faker("tr");

            for (int i = 1; i <= 100; i++)
            {
                var category = faker.PickRandom(categories);
                var supplier = faker.PickRandom(suppliers);

                products.Add(new Product
                {
                    ID = i,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    UnitPrice = Math.Round(faker.Random.Decimal(19.99m, 9999.99m), 2),
                    UnitsInStock = (short)faker.Random.Int(0, 500),
                    CategoryId = category.ID,
                    SupplierId = supplier.ID,
                    CreatedDate = faker.Date.Past(1)
                });
            }

            return products;
        }
    }
}