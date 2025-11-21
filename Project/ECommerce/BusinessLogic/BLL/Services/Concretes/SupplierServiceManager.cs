using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;
using System.Linq;

namespace BLL.Services.Concretes
{
    public class SupplierServiceManager : ServiceManager<Supplier>, ISupplierServiceManager
    {
        private readonly IRepository<Supplier> _repository;

        public SupplierServiceManager(IRepository<Supplier> repository) : base(repository)
        {
            _repository = repository;
        }

        public Supplier? GetByUsername(string username)
        {
            return _repository.GetActives()
                .FirstOrDefault(s => s.Username == username);
        }
    }
}