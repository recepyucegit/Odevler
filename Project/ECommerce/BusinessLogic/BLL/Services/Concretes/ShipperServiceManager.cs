using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class ShipperServiceManager : ServiceManager<Shipper>, IShipperServiceManager
    {
        public ShipperServiceManager(IRepository<Shipper> repository) : base(repository)
        {
        }

        // Aktif kargo firmalarını getir
        public List<Shipper> GetActiveShippers()
        {
            return GetActives().Where(s => s.IsActive).ToList();
        }
    }
}
