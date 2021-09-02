using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
