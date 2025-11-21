using Bogus;
using Bogus.DataSets;
using DAL.Entities.Concretes;

namespace DAL.Seeds
{
    public class CategorySeeder
    {
        public static List<Category> GetFakeCategories()
        {
            List<Category> categories = new List<Category>();

           var faker = new Faker();

            for (int i = 0; i < 10; i++)
            {

                Category category = new Category
                {
                    ID = i + 1,
                    CategoryName = faker.Commerce.Categories(1)[0],
                    Description = faker.Lorem.Word()

                };

                categories.Add(category);

            }


            return categories;



        }
    }
}
