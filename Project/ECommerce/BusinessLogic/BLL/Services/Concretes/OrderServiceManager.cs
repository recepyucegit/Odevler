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
    public class OrderServiceManager : ServiceManager<Order>, IOrderServiceManager
    {
        public OrderServiceManager(IRepository<Order> repository) : base(repository)
        {
        }
        // Order'a özel metotlar eklenebilir.
    }
}
