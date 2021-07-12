using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CleanAPIContext _dbContext;
        private readonly DbSet<T> _entity;
        public BaseRepository(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            _entity.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entity.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _entity.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
