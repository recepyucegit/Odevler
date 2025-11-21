using DAL.Repositories.Abstracts;
using DAL.Entities.Concretes;

namespace BLL.Services.OldService.Abstracts
{
    public interface IProductService
    {
        // Listeleme
        IQueryable<Product> ProductGetAll();
        IQueryable<Product> ProductGetActives();
        IQueryable<Product> ProductGetInActives();

        // Oluşturma
        Task ProductCreateAsync(Product entity);
        Task ProductCreateAsync(List<Product> entities);

        // Güncelleme
        Task ProductUpdateAsync(Product entity);
        Task ProductUpdateAsync(List<Product> entities);

        // Silme
        Task ProductDeleteAsync(int id);

        // Arama
        Product ProductFindById(int id);

    }
}
