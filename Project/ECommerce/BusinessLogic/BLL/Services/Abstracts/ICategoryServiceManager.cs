using DAL.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface ICategoryServiceManager:IServiceManager<Category>
    {
        //bu interface içerisinde sadece Category entity'sine özel metotlar olacak.

    }
}
