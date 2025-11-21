using BLL.Services.OldService.Abstracts;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.OldService.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _ProductRepository;

        public ProductService(IRepository<Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        // Listeleme
        public IQueryable<Product> ProductGetAll()
        {
            return _ProductRepository.GetAll();
        }

        public IQueryable<Product> ProductGetActives()
        {
            return _ProductRepository.GetActives();
        }

        public IQueryable<Product> ProductGetInActives()
        {
            return _ProductRepository.GetInActives();
        }

        // Oluşturma
        public async Task ProductCreateAsync(Product entity)
        {
            await _ProductRepository.CreateAsync(entity);
        }

        public async Task ProductCreateAsync(List<Product> entities)
        {
            await _ProductRepository.CreateAsync(entities);
        }

        // Güncelleme
        public async Task ProductUpdateAsync(Product entity)
        {
            await _ProductRepository.UpdateAsync(entity);
        }

        public async Task ProductUpdateAsync(List<Product> entities)
        {
            await _ProductRepository.UpdateAsync(entities);
        }

        // Silme
        public async Task ProductDeleteAsync(int id)
        {
            await _ProductRepository.DeleteAsync(id);
        }

        // Arama
        public Product ProductFindById(int id)
        {
            return _ProductRepository.FindById(id);
        }
    }
}
