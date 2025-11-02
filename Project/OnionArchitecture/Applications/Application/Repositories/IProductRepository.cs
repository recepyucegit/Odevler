using Domain.Entities;

namespace Application.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        //Product'a özel metotlar buraya eklenir.
    }
}
