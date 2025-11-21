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
    public class CategoryServiceManager : ServiceManager<Category>,ICategoryServiceManager
    {

        //ServiceManager class'ı içerisinde bağımlılıklık injection için constructor oluşturmuştuk. O yüzden burada da base class'ın constructor'ını çağırmamız gerekiyor.
        public CategoryServiceManager(IRepository<Category> repository) : base(repository)
        {
        }

        //Category entity'sine özel metotlar burada olacak.
    }
}
