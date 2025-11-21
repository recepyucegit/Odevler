using DAL.Context;
using DAL.Entities.Abstracts;
using DAL.Repositories.Abstracts;
using DAL.Utils;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseClass
    {
        private readonly ProjectContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                var result = await _context.SaveChangesAsync();  

                if (result == 0)
                {
                    throw new Exception("Veri kaydedilemedi!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw;
            }
        }

        public async Task CreateAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = FindById(id);
            _dbSet.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        public T FindById(int id)
        {
           var entity= _dbSet.Find(id);
            return entity;
        }

        public IQueryable<T> GetActives()
        {
            return _dbSet.Where(x => x.Status == Entities.Enums.DataStatus.Active).Select(x => x);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Select(x => x);
        }

        public IQueryable<T> GetInActives()
        {
            return _dbSet.Where(x => x.Status == Entities.Enums.DataStatus.Inactive).Select(x => x);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.IpAddress = IpAddressFinder.GetHostName();
            entity.ModifiedComputerName = System.Environment.MachineName;
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(List<T> entities)
        {
            foreach(var entity in entities)
            {
                entity.ModifiedComputerName = System.Environment.MachineName;
                entity.ModifiedDate = DateTime.Now;
                _dbSet.Update(entity);
               
            }
            await _context.SaveChangesAsync();
        }
    }
}
