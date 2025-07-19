using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_NorthwindEF.Managers.Abstracts
{
    internal interface ICategoryManager
    {
        void CreateCategory(Category category);
        void UpdateCategory(Category updated);
        void DeleteCategory(int categoryId);

        List<Category> GetCategories(bool isDesc);
        Category GetCategoryById(int id);
    }
}
