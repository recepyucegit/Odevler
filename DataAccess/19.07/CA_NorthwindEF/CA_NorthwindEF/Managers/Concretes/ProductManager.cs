using CA_NorthwindEF.Managers.Abstracts;
using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CA_NorthwindEF.Managers.Concretes
{
    internal class ProductManager : IProductManager
    {

        NorthwindContext context = new NorthwindContext();

        public string CreateProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return "ürün kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        //public void UpdateProduct(Product updated)
        //{
        //    Product product = context.Products.Find(updated.ProductId);
        //    product.ProductName = updated.ProductName;
        //    product.UnitPrice = updated.UnitPrice;

        //}

        public Product GetProductById(int id)
        {
            Product product = context.Products.Find(id);
            return product  ;
        }

       public string UpdateProduct(Product updated)
        {
            Product product = context.Products.Find( updated.ProductId);
            product.ProductName = updated.ProductName;
            product.UnitPrice = updated.UnitPrice;
            
            context.SaveChanges();
            return "Ürün güncellendi!";



        }

        public void DeleteProduct(int id)
        {
            Product deleted= GetProductById(id);
            context.Products.Remove(deleted);
            context.SaveChanges();
        }

    }
}
//public void DeleteCategory(int categoryId)
//{
//    //parametre olarak gelen Id'e ait category veritabaından kaldıracak.
//    Category deleted = GetCategoryById(categoryId);
//    context.Categories.Remove(deleted);
//    context.SaveChanges();
//}

//public void UpdateCategory(Category updated)
//{
//    //parametre oalrak gelen updated veritabanında bulunan aynı Id'e sahip category bilgileri ile yer değişecek.

//    Category category = context.Categories.Find(updated.CategoryId);//1013
//    category.CategoryName = updated.CategoryName;
//    category.Description = updated.Description;

//    context.SaveChanges();
//}