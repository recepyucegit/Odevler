using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindDbContext context) : base(context)
        {
        }

       
        //Category'ye özel metotlar buraya implement edilir.
    }
}
