﻿using CleanAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
