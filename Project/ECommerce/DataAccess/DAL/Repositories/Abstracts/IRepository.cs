using DAL.Entities.Abstracts;

namespace DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T: BaseClass
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
