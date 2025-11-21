using DAL.Entities.Concretes;

namespace BLL.Services.OldService.Abstracts
{
    public interface ICategoryService
    {
        // Listeleme
        IQueryable<Category> CategoryGetAll();
        IQueryable<Category> CategoryGetActives();
        IQueryable<Category> CategoryGetInActives();

        // Oluşturma
        Task CategoryCreateAsync(Category entity);
        Task CategoryCreateAsync(List<Category> entities);

        // Güncelleme
        Task CategoryUpdateAsync(Category entity);
        Task CategoryUpdateAsync(List<Category> entities);

        // Silme
        Task CategoryDeleteAsync(int id);

        // Arama
        Category CategoryFindById(int id);

    }
}
