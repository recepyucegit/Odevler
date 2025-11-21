using BLL.Services.DTOs;
using DAL.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IProductServiceManager:IServiceManager<Product>
    {
        //bu interface içerisinde sadece Product entity'sine özel metotlar olacak.

        List<ProductCategoryDTO> GetProductsWithCategory();
    }
}
