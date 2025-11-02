using Domain.Entities;

namespace Application.Repositories
{
    public interface ISupplierRepository:IRepository<Supplier>
    {
        Task<Supplier> GetSupplierWithProductsAsync(int id);
        Task<IReadOnlyList<Supplier>> GetSuppliersWithProductsAsync();
    }
}
