using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        //supplier'a özel metotlar buraya eklenir.

        private readonly NorthwindDbContext _context;

        public SupplierRepository(NorthwindDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Supplier> GetSupplierWithProductsAsync(int id)
        {
            return await _context.Set<Supplier>()
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<IReadOnlyList<Supplier>> GetSuppliersWithProductsAsync()
        {
            return await _context.Set<Supplier>()
                .Include(s => s.Products)
                .ToListAsync();
        }
        
    }
}
