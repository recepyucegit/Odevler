using BLL.Services.Abstracts;
using BLL.Services.DTOs;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class ProductServiceManager : ServiceManager<Product>,IProductServiceManager
    {
        //ServiceManager class'ı içerisinde bağımlılıklık injection için constructor oluşturmuştuk. O yüzden burada da base class'ın constructor'ını çağırmamız gerekiyor.
        public ProductServiceManager(IRepository<Product> repository) : base(repository)
        {
        }

        public List<ProductCategoryDTO> GetProductsWithCategory()
        {
            //ürünler ile kategorileri joinleyip dto'ya mapleyip geriye döndüren metot.
            var productsWithCategory = GetAll()
                .Select(p => new ProductCategoryDTO
                {
                    ProductId = p.ID,
                    ProductName = p.ProductName,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Kategori Yok", // Kategori null ise "Kategori Yok" yaz
                    CategoryId = p.CategoryId,
                    UnitPrice = p.Price,
                    Stock = p.Stock
                }).ToList();

            return productsWithCategory;
        }
    }
}
