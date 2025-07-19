using CA_NorthwindEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_NorthwindEF.Managers.Abstracts
{
    internal interface ISupplierManager
    {
        //Create => Eylemi (Metot)
        string CreateSupplier(Supplier supplier);

        //GetById
        Supplier GetSupplierById(int id);

        //Get

        IEnumerable<Supplier> GetSuppliers();

        //Update

        void UpdateSupplier(Supplier updated);

        //Delete

        void DeleteSupplier(int supplierId);



    }
}
