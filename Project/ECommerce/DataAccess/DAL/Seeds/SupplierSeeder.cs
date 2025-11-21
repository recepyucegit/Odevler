using Bogus;
using DAL.Entities.Concretes;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Seeds
{
    public class SupplierSeeder
    {
        public static List<Supplier> GetFakeSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            //  İlk 3 supplier: Test için özel kullanıcılar
            suppliers.Add(new Supplier
            {
                ID = 1,
                CompanyName = "ABC Tedarik Ltd.",
                ContactName = "Ali Veli",
                ContactTitle = "Satış Müdürü",
                Address = "Atatürk Cad. No:123",
                City = "İstanbul",
                Country = "Türkiye",
                Phone = "0212-555-0001",
                Email = "supplier1@test.com",
                Username = "supplier1",
                PasswordHash = "Pass123!",  // Production'da hash'lenmeli!
                IsActive = true,
                Status = DataStatus.Active,
                CreatedDate = DateTime.Now,
                MasterId = Guid.NewGuid(),
                ComputerName = "SEED",
                IpAddress = "127.0.0.1"
            });

            suppliers.Add(new Supplier
            {
                ID = 2,
                CompanyName = "XYZ Dağıtım A.Ş.",
                ContactName = "Ayşe Yılmaz",
                ContactTitle = "Genel Müdür",
                Address = "İnönü Bulvarı No:456",
                City = "Ankara",
                Country = "Türkiye",
                Phone = "0312-555-0002",
                Email = "supplier2@test.com",
                Username = "supplier2",
                PasswordHash = "Pass123!",
                IsActive = true,
                Status = DataStatus.Active,
                CreatedDate = DateTime.Now,
                MasterId = Guid.NewGuid(),
                ComputerName = "SEED",
                IpAddress = "127.0.0.1"
            });

            suppliers.Add(new Supplier
            {
                ID = 3,
                CompanyName = "Global Tedarik Ltd.",
                ContactName = "Mehmet Kaya",
                ContactTitle = "Satış Direktörü",
                Address = "Cumhuriyet Mah. No:789",
                City = "İzmir",
                Country = "Türkiye",
                Phone = "0232-555-0003",
                Email = "supplier3@test.com",
                Username = "supplier3",
                PasswordHash = "Pass123!",
                IsActive = true,
                Status = DataStatus.Active,
                CreatedDate = DateTime.Now,
                MasterId = Guid.NewGuid(),
                ComputerName = "SEED",
                IpAddress = "127.0.0.1"
            });

            //  Geri kalan 7 supplier: Bogus ile fake data
            var faker = new Faker();
            for (int i = 4; i <= 10; i++)
            {
                Supplier supplier = new Supplier
                {
                    ID = i,
                    CompanyName = faker.Company.CompanyName(),
                    ContactName = faker.Name.FullName(),
                    ContactTitle = faker.Name.JobTitle(),
                    Address = faker.Address.StreetAddress(),
                    City = faker.Address.City(),
                    Country = "Türkiye",
                    Phone = faker.Phone.PhoneNumber(),
                    Email = faker.Internet.Email(),
                    Username = $"supplier{i}",  // ✅ supplier4, supplier5, ...
                    PasswordHash = "Pass123!",
                    IsActive = true,
                    Status = DataStatus.Active,
                    CreatedDate = DateTime.Now,
                    MasterId = Guid.NewGuid(),
                    ComputerName = "SEED",
                    IpAddress = "127.0.0.1"
                };
                suppliers.Add(supplier);
            }

            return suppliers;
        }
    }
}