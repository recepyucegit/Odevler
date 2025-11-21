using Bogus;
using DAL.Entities.Concretes;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeds
{
    internal class ProductSeeder
    {


        public static List<Product> GetFakeProducts()
        {
            List<Product> products = new List<Product>();

            var faker = new Faker();

            int categoryCounter = 1;
            int supplierCounter = 1;

            for (int i = 1; i < 101; i++)
            {

                Product product = new Product();
                product.ID = i;
                product.ProductName = faker.Commerce.ProductName();
                product.Description = faker.Lorem.Sentence(5);
                product.Price = Convert.ToDecimal(faker.Commerce.Price(1, 1000));
                product.Stock = faker.Random.Int(1, 100);
                product.CreatedDate = DateTime.Now;

                if (i % 10 == 0)
                {
                    product.CategoryId = categoryCounter;
                    categoryCounter++;
                }
                else
                {
                    product.CategoryId = categoryCounter;
                }
                if (i % 10 == 0)
                {
                    product.SupplierId = supplierCounter;
                    supplierCounter++;
                    if (supplierCounter > 10) supplierCounter = 1; // 10 supplier var, döngüye al
                }
                else
                {
                    product.SupplierId = supplierCounter;
                }
                products.Add(product);

            }

            return products;
        }
    }
}
