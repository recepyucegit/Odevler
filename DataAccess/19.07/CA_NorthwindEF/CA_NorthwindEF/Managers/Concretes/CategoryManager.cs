using CA_NorthwindEF.Managers.Abstracts;
using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_NorthwindEF.Managers.Concretes
{
    internal class CategoryManager : ICategoryManager
    {

        NorthwindContext context = new NorthwindContext(); //Veritanbı
        public void CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            //parametre olarak gelen Id'e ait category veritabaından kaldıracak.
            Category deleted = GetCategoryById(categoryId);
            context.Categories.Remove(deleted);
            context.SaveChanges();
        }

        public List<Category> GetCategories(bool isDesc)
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

        public Category GetCategoryById(int id)
        {
            //parametre olarak gelen Id'si veritabanında bulunan category'lerde arayarak eşitlenen category bilgisi döndürlecek.

            Category category = context.Categories.Find(id);

            return category;
        }

        public void UpdateCategory(Category updated)
        {
            //parametre oalrak gelen updated veritabanında bulunan aynı Id'e sahip category bilgileri ile yer değişecek.

            Category category = context.Categories.Find(updated.CategoryId);//1013
            category.CategoryName = updated.CategoryName;
            category.Description = updated.Description;

            context.SaveChanges();
        }
    }
}
