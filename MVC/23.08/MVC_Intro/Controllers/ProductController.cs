using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;

namespace MVC_Intro.Controllers
{
    public class ProductController : Controller
    {


       static List<Product> _productList = new List<Product>();



        [HttpGet]
        //Ürün liste sayfası
        public IActionResult Index()
        {
            return View(_productList);
        }


        [HttpGet]
        //Ürün ekleme sayfası
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(string productName, decimal unitPrice, string categoryName)
        //{
        //    //parametre değerleri "Product" nesnesi tarafında kullanılacak.
        //    Product product = new Product()
        //    {
        //        ProductName = productName,
        //        UnitPrice = unitPrice,
        //        CategoryName = categoryName
        //    };
        //    _productList.Add(product);
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create(Product product)
        {
            //parametre değerleri "Product" nesnesi tarafında kullanılacak.
            product.ID=_productList.Count+1;
            _productList.Add(product);
            //return View();
            return RedirectToAction("Index");
        }
    }
}
