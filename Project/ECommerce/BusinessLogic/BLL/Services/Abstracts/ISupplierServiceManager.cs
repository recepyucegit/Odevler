using DAL.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface ISupplierServiceManager : IServiceManager<Supplier>
    {
        // Supplier'a özel metotlar eklenebilir
        Supplier? GetByUsername(string username);
        //List<Supplier> GetActiveSuppliers();
    }
}
