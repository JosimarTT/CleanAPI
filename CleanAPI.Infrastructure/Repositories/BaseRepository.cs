using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CleanAPIContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(CleanAPIContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            T entity = await GetById(id);
            _dbSet.Remove(entity);
        }
    }
}
