using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CleanAPIContext _dbContext;
        protected readonly DbSet<T> _entity;
        public BaseRepository(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entity.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }
    }
}
