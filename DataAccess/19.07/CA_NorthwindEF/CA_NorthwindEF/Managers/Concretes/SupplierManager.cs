using CA_NorthwindEF.Managers.Abstracts;
using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_NorthwindEF.Managers.Concretes
{
    internal class SupplierManager : ISupplierManager
    {

        NorthwindContext context = new NorthwindContext();


        public string CreateSupplier(Supplier supplier)
        {
            try
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                return $"{supplier.CompanyName},{supplier.ContactName}  eklendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            Supplier deleted = GetSupplierById(supplierId);
            context.Suppliers.Remove(deleted);
            context.SaveChanges();
        }

        public Supplier GetSupplierById(int id)
        {
            Supplier supplier = context.Suppliers.Find(id);

            return supplier;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return context.Suppliers;
        }

        public void UpdateSupplier(Supplier updated)
        {
            Supplier supplier = context.Suppliers.Find(updated.SupplierId);

            supplier.CompanyName = updated.CompanyName;
            supplier.ContactName = updated.ContactName;
            context.SaveChanges();
        }
    }
}
