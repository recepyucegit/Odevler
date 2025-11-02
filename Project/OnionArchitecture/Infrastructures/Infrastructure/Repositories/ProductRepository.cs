using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(NorthwindDbContext context) : base(context)
        {
        }

        //Product'a özel metotlar buraya eklenir.
    }
}
