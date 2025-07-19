

using CA_NorthwindEF.Models;

namespace CA_NorthwindEF.Managers
{
    internal class CategoryManagerTest
    {
        //Context
        NorthwindContext context = new NorthwindContext();


        /// <summary>
        /// Bu metot dışarıdan alınan category tipini veritabanına ekler
        /// </summary>
        /// <param name="category"></param>
        internal void CreateCategory(Category category)
        {
            //veritabanına kayıt işlemi
            context.Categories.Add(category);
            context.SaveChanges();
        }

        /// <summary>
        /// dışarıdan category'e göre güncelleme işlemini yapar
        /// </summary>
        /// <param name="updated"></param>
        internal void UpdateCategory(Category updated)//1013 Sapka Yazlık sapkalar
        {
            //parametre oalrak gelen updated veritabanında bulunan aynı Id'e sahip category bilgileri ile yer değişecek.

            Category category = context.Categories.Find(updated.CategoryId);//1013
            category.CategoryName = updated.CategoryName;
            category.Description= updated.Description;

            context.SaveChanges();
        }

        /// <summary>
        /// parametre oalrak gönderilen Id'e ait Category veritabanında kaldırılır.
        /// </summary>
        /// <param name="categoryId"></param>
        internal void DeleteCategory(int categoryId)
        {
            //parametre olarak gelen Id'e ait category veritabaından kaldıracak.
           Category deleted= GetCategoryById(categoryId);
            context.Categories.Remove(deleted);
            context.SaveChanges();
        }


        //List
        internal List<Category> GetCategories(bool isDesc)
        {
            //veritabanındaki bütün kategorilerin listelenmesi
            if (isDesc)
            {
                return context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            }
            else
            {
                return context.Categories.ToList();
            }
            
        }

        /// <summary>
        /// parametre olarak alınan Id'si category içerisinde bulunan Id sütununa göre arar ve bulduğu getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Category GetCategoryById(int id)
        {
            //parametre olarak gelen Id'si veritabanında bulunan category'lerde arayarak eşitlenen category bilgisi döndürlecek.

            Category category = context.Categories.Find(id);

            return category;

        }
    }
}
