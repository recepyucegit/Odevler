using CA_NorthwindEF.Managers.Concretes;
using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_NorthwindEF.Managers
{
    internal class ConsoleManager
    {

         CategoryManagerTest categoryManager = new CategoryManagerTest();
        ProductManager productManager = new ProductManager();
        //Tedarikçi işlemleri için instance oluşturma
        SupplierManager supplierManager = new SupplierManager();


        #region Kategori Console İşlemleri


        internal Category GetConsoleCategoryValues()
        {

            Category category = new Category();

            Console.WriteLine("ltüfen kategori adı girin: ");
            category.CategoryName = Console.ReadLine();
            Console.WriteLine("açıklama girin: ");
            category.Description = Console.ReadLine();

            return category;
        }

        internal string UpdateConsoleCategory(int id)
        {
            try
            {
                Category category = categoryManager.GetCategoryById(id);
                Console.WriteLine("Güncellenecek kategori ad: ");
                category.CategoryName = Console.ReadLine();
                Console.WriteLine("Güncellenecek açıklama");
                category.Description = Console.ReadLine();

                categoryManager.UpdateCategory(category);

                return "Güncelleme başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        internal string DeleteConsoleCategory(int id)
        {


            try
            {
                categoryManager.DeleteCategory(id);
                return "kategori başarılı şekilde kaldırıldı!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        internal void GetConsoleCategories()
        {

            Console.WriteLine("Kategoriler çoktan az'a mı listelensin?");

            string tercih = Console.ReadLine();
            if (tercih == "evet" || tercih == "e")
            {
                foreach (var item in categoryManager.GetCategories(true))
                {
                    Console.WriteLine(item.CategoryName);
                }
            }
            else
            {
                foreach (var item in categoryManager.GetCategories(false))
                {
                    Console.WriteLine(item.CategoryName);
                }
            }




        }
        #endregion



        #region Ürün Console İşlemleri

        //internal string DeleteConsoleCategory(int id)
        //{


        //    try
        //    {
        //        categoryManager.DeleteCategory(id);
        //        return "kategori başarılı şekilde kaldırıldı!";
        //    }
        //    catch (Exception ex)
        //    {

        //        return ex.Message;
        //    }

        //}

        internal string DeleteConsoleProduct(int id)
        {
            try
            {
                productManager.DeleteProduct(id);
                return "Ürün başarılı şekilde kaldırıldı!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void GetConsoleProductValues()
        {
            foreach (var item in productManager.GetProducts())
            {
                Console.WriteLine(item.ProductName);
            }
        }

        internal Product CreateConsoleProductValues()
        {

            Product product = new Product();

            Console.WriteLine("ltüfen ürün adı girin: ");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Fiyat girin: ");
            product.UnitPrice = decimal.Parse(Console.ReadLine());

            productManager.CreateProduct(product);

            return product;
        }

        internal string UpdateConsoleProduct(int id)
        {
            try
            {
                Product product = productManager.GetProductById(id);
                Console.WriteLine("Güncellenecek ürün adı: ");
                product.ProductName = Console.ReadLine();
                Console.WriteLine("Güncellenecek fiyat: ");
                product.UnitPrice = decimal.Parse(Console.ReadLine());

                productManager.UpdateProduct(product);

                return "Güncelleme başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }





        #endregion


        #region Tedarikçi Console İşlemleri
        // Tedarikçi işlemleri için gerekli olan metotlar
        // Tedarikçi ekleme, güncelleme, silme ve listeleme işlemleri
        // Tedarikçi ekleme işlemi için CreateConsoleSupplierValues metodu
        internal Supplier CreateConsoleSupplierValues()
        {
            Supplier supplier = new Supplier();
            Console.WriteLine("Tedarikçi adı girin:");
            supplier.CompanyName = Console.ReadLine();
            Console.WriteLine("Tedarikçi iletişim adı girin");
            supplier.ContactName = Console.ReadLine();
            supplierManager.CreateSupplier(supplier);
            return supplier;
        }
        // Tedarikçi listeleme işlemi için GetConsoleSuppliers metodu
        internal void GetConsoleSuppliers()
        {
            foreach (var item in supplierManager.GetSuppliers())
            {
                Console.WriteLine(item.CompanyName);
            }

        }
        // Tedarikçi güncelleme işlemi için UpdateConsoleSupplier metodu

        internal void UpdateConsoleSuppliers(int id)
        {
            Supplier supplier = supplierManager.GetSupplierById(id);
            Console.WriteLine("Güncellenecek tedarikçi adı: ");
            supplier.CompanyName = Console.ReadLine();
            Console.WriteLine("Güncellenecek tedarikçi iletişim adı: ");
            supplier.ContactName = Console.ReadLine();
            supplierManager.UpdateSupplier(supplier);


        }

        // Tedarikçi silme işlemi için DeleteConsoleSupplier metodu
        internal string DeleteConsoleSupplier()
        {
            try
            {
                
                Console.WriteLine("Kaldırmal istediğiniz tedarikçinin Id numarasını giriniz");
                int id= int.Parse(Console.ReadLine());
                supplierManager.DeleteSupplier(id);


                return "Tedarikçi başarılı şekilde kaldırıldı!";

            }

            catch(Exception ex)
            { 
             return ex.Message;
            }

        }




        #endregion

        //internal Product CreateConsoleProductValues()
        //{

        //    Product product = new Product();

        //    Console.WriteLine("ltüfen ürün adı girin: ");
        //    product.ProductName = Console.ReadLine();
        //    Console.WriteLine("Fiyat girin: ");
        //    product.UnitPrice = decimal.Parse(Console.ReadLine());

        //    productManager.CreateProduct(product);

        //    return product;
        //}
    }
}
