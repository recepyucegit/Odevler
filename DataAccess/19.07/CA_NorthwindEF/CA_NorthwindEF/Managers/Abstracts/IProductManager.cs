using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_NorthwindEF.Managers.Abstracts
{
    internal interface IProductManager
    {
        //IEnumerable<>=> bir list içerisinden ayrı bir liste gelecekse o değeri yakalamak ve değere ulaşmak için kullanırız.
        //List<>=> bir liste içerisinde tekil değerler gelir.
        IEnumerable<Product> GetProducts();

        string CreateProduct(Product product);

        Product GetProductById(int id);

        string UpdateProduct(Product product);

        void DeleteProduct(int id);


    }
}
