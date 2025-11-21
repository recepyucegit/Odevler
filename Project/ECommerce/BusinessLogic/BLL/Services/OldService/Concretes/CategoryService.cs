using BLL.Services.OldService.Abstracts;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;

namespace BLL.Services.OldService.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Listeleme
        public IQueryable<Category> CategoryGetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IQueryable<Category> CategoryGetActives()
        {
            return _categoryRepository.GetActives();
        }

        public IQueryable<Category> CategoryGetInActives()
        {
            return _categoryRepository.GetInActives();
        }

        // Oluşturma
        public async Task CategoryCreateAsync(Category entity)
        {
            await _categoryRepository.CreateAsync(entity);
        }

        public async Task CategoryCreateAsync(List<Category> entities)
        {
            await _categoryRepository.CreateAsync(entities);
        }

        // Güncelleme
        public async Task CategoryUpdateAsync(Category entity)
        {
            await _categoryRepository.UpdateAsync(entity);
        }

        public async Task CategoryUpdateAsync(List<Category> entities)
        {
            await _categoryRepository.UpdateAsync(entities);
        }

        // Silme
        public async Task CategoryDeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        // Arama
        public Category CategoryFindById(int id)
        {
            return _categoryRepository.FindById(id);
        }
    }
}
