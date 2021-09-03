using CleanAPI.Core.DTOs;
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
    public class UserRepository: BaseRepository<User> , IUserRepository
    {
        public UserRepository(CleanAPIContext context) : base(context) { }

        public async Task<User> Login(string userName)
        {
         return await _dbSet.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
