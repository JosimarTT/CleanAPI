using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Infrastructure.Data;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CleanAPIContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UnitOfWork(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_dbContext);

        public IRoleRepository RoleRepository => _roleRepository ?? new RoleRepository(_dbContext);

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SavechangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
