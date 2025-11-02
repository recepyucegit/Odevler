using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Get
        Task<T> GetByIdAsync(int id);

        //GetAll
        //parametresiz
        Task<IReadOnlyList<T>> GetAllAsync();
        //parametreli
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T,bool>> predicate); //kullanımda lambda ifadesi dahil edilecek.

        //Add
        Task<T> AddAsync(T entity);

        //Update
        Task UpdateAsync(T entity);

        //Delete
        Task DeleteAsync(T entity);
    }
}
