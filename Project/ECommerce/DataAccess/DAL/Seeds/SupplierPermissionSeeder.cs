using DAL.Entities.Concretes;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Seeds
{
    public class SupplierPermissionSeeder
    {
        public static List<SupplierPermission> GetFakeSupplierPermissions()
        {
            List<SupplierPermission> permissions = new List<SupplierPermission>();
            int id = 1;

            // ✅ Supplier 1: Sadece okuma yetkisi
            permissions.Add(new SupplierPermission
            {
                ID = id++,
                SupplierId = 1,
                Permission = "ReadProduct",
                Status = DataStatus.Active,
                CreatedDate = DateTime.Now,
                MasterId = Guid.NewGuid(),
                ComputerName = "SEED",
                IpAddress = "127.0.0.1"
            });

            // ✅ Supplier 2: Okuma ve ekleme yetkisi
            permissions.Add(new SupplierPermission
            {
                ID = id++,
                SupplierId = 2,
                Permission = "ReadProduct",
                Status = DataStatus.Active,
                CreatedDate = DateTime.Now,
                MasterId = Guid.NewGuid(),
                ComputerName = "SEED",
                IpAddress = "127.0.0.1"
            });
            permissions.Add(new SupplierPermission
            {
                ID = id++,
                SupplierId = 2,
                Permission = "AddProduct",
                Status = DataStatus.Active,
                CreatedDate = DateTime.Now,
                MasterId = Guid.NewGuid(),
                ComputerName = "SEED",
                IpAddress = "127.0.0.1"
            });

            // ✅ Supplier 3: Tüm yetkiler
            string[] allPermissions = { "ReadProduct", "AddProduct", "EditProduct", "DeleteProduct" };
            foreach (var perm in allPermissions)
            {
                permissions.Add(new SupplierPermission
                {
                    ID = id++,
                    SupplierId = 3,
                    Permission = perm,
                    Status = DataStatus.Active,
                    CreatedDate = DateTime.Now,
                    MasterId = Guid.NewGuid(),
                    ComputerName = "SEED",
                    IpAddress = "127.0.0.1"
                });
            }

            // ✅ Supplier 4-10: Random yetkiler
            var random = new Random();
            for (int supplierId = 4; supplierId <= 10; supplierId++)
            {
                // Her supplier için rastgele 1-4 arası yetki ver
                int permCount = random.Next(1, 5);
                var selectedPerms = new HashSet<string>();

                while (selectedPerms.Count < permCount)
                {
                    string randomPerm = allPermissions[random.Next(allPermissions.Length)];
                    selectedPerms.Add(randomPerm);
                }

                foreach (var perm in selectedPerms)
                {
                    permissions.Add(new SupplierPermission
                    {
                        ID = id++,
                        SupplierId = supplierId,
                        Permission = perm,
                        Status = DataStatus.Active,
                        CreatedDate = DateTime.Now,
                        MasterId = Guid.NewGuid(),
                        ComputerName = "SEED",
                        IpAddress = "127.0.0.1"
                    });
                }
            }

            return permissions;
        }
    }
}