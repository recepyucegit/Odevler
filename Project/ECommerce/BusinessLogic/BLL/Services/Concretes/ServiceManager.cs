using BLL.Services.Abstracts;
using DAL.Entities.Abstracts;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class ServiceManager<T> : IServiceManager<T> where T : BaseClass
    {
        private readonly IRepository<T> _repository;

        public ServiceManager(IRepository<T> repository)
        {
            _repository = repository;
        }


        public async Task CreateAsync(T entity)
        {
            try
            {
               await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public async Task CreateAsync(List<T> entities)
        {
            try
            {
                await _repository.CreateAsync(entities);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                //parametre oalrak gelen Id'i repository içerisinde bulunan find metpdu ile arayacağız. İçin dolu entity'i daha sonra kaldıracağız.
                var entity = _repository.FindById(id);
                if (entity != null)
                {
                     await _repository.DeleteAsync(id);
                }
                else
                {
                    throw new Exception("Silinecek veri bulunamadı");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public T FindById(int id)
        {
            //parametre olarak gelen Id'yi repository içerisindeki findById metodu ile arayacağız. 
           
            var entity = _repository.FindById(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new Exception("Aranan veri bulunamadı");
            }


        }

        public IQueryable<T> GetActives()
        {
            //aktif olanları listeleyecek.
            return _repository.GetActives();
        }

        public IQueryable<T> GetAll()
        {
            //tüm verileri listeleyecek.
            return _repository.GetAll();
        }

        public IQueryable<T> GetInActives()
        {
            //pasif olanları listeleyecek.
            return _repository.GetInActives();
        }

        public async Task UpdateAsync(T entity)
        {
            //dışarıdan alınan entity'i repository içerisindeki update metoduna göndereceğiz.
            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public async Task UpdateAsync(List<T> entities)
        {
            //dışarıdan alınan entity listesini repository içerisindeki update metoduna göndereceğiz.
            try
            {
                await _repository.UpdateAsync(entities);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
        }
    }
}
