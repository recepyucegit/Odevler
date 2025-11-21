using DAL.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IOrderServiceManager : IServiceManager<Order>
    {
        // Order'a özel metotlar ekleyebilirsiniz.
    }
}
