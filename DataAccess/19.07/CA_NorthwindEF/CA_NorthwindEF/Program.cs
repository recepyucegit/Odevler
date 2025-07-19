//EF
//Veritabanında bulunan tabloları projes içerisinde class haline dönüştürmek ve bu tablo içerisinde bulunan kolonları da classlar içerisinde property olarak dahil etmek.

//Nuget Paketleri
//install-package
//Microsoft.EntityFrameworkCore.SQLServer
//Microsoft.EntityFrameworkCore.Tools
//Scaffold-Dbcontext: Veritabanı yansımasını projeye dahil eder.

//OOP Prensiplerine göre verilere işlemlerin uygulanması.


using CA_NorthwindEF.Managers;
using CA_NorthwindEF.Managers.Concretes;
using CA_NorthwindEF.Models;
using System.Runtime.Versioning;

namespace CA_NorthwindEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Model içerisinde bulunan nesnelere ait işlemleri farklı bir klasörde gerçekleştirmemiz gerekmektedir.

            //Category category = new Category
            //{
            //    CategoryName = "Test 5",
            //    Description = "Test 5"
            //};

            //Console'dan category bilgilerinin alınması.
            //CategoryManagerTest categoryManager = new CategoryManagerTest();

            //ConsoleManager consoleManager = new ConsoleManager();

           ConsoleManager consoleManager = new ConsoleManager();

            //Kategori Listeleme
            //consoleManager.GetConsoleCategories();
            //Console.WriteLine("*******");
            //Ürün Listeleme
            //consoleManager.GetConsoleProductValues();
            //Ürün Ekleme

            //Product product = new Product
            //{
            //    ProductName = "Test Ürün 1",
            //    UnitPrice = 100,
            //    UnitsInStock = 10,
            //    CategoryId = 1
            //};
            //ProductManager productManager = new ProductManager();

            //Supplier supplier = new Supplier();

            //Console.WriteLine("Tedarikçi adı girin:");
            //supplier.CompanyName = Console.ReadLine();
            //Console.WriteLine("Tedarikçi iletişim adı girin");
            //supplier.ContactName = Console.ReadLine();

            //SupplierManager supplierManager = new SupplierManager();

            //string result = supplierManager.CreateSupplier(supplier);
            //Console.WriteLine(result);
            //{
            //    CompanyName = "Test Company",
            //    ContactName = "Test Contact",
            //};

            //SupplierManager supplierManager = new SupplierManager();
            //string result=supplierManager.CreateSupplier(supplier);
            //Console.WriteLine(result);




            //Product product1 = new Product
            //{
            //    ProductName = "Test Ürün 2",
            //    UnitPrice = 200,
            //    UnitsInStock = 20,
            //    CategoryId = 2
            //};
            //string result = productManager.CreateProduct(product1);
            //Console.WriteLine(result);

            //consoleManager.CreateConsoleProductValues();

            //consoleManager.DeleteConsoleProduct(79);

            //consoleManager.UpdateConsoleProduct(80);

            //consoleManager.UpdateConsoleCategory(1);

            //*****************************************************//


            //consoleManager.CreateConsoleSupplierValues();
            //SupplierManager supplierManager = new SupplierManager();

            //consoleManager.DeleteConsoleSupplier();




            //Supplier supplier=supplierManager.GetSupplierById(id);
            //Console.WriteLine("Değiştirilecek olan tedarikçi ismi giriniz:");
            //supplier.CompanyName = Console.ReadLine();
            //Console.WriteLine("Değiştirilecek olan tedarikçi iletişim ismi giriniz:");
            //supplier.ContactName = Console.ReadLine();
            //supplierManager.UpdateSupplier(supplier);






            Console.Read();
        }
    }
}


