using DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IServiceManager<T> where T : BaseClass
    {
        //bu interface içindeki metotlar bütün entity'ler için kullanımda olacak metotlar.
        //Listeleme T
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetInActives();
        //Oluşturma
        Task CreateAsync(T entity);
        Task CreateAsync(List<T> entities);

        //Güncelleme
        Task UpdateAsync(T entity);
        Task UpdateAsync(List<T> entities);
        //Silme
        Task DeleteAsync(int id);
        //Arama
        T FindById(int id);
        
    }
}
