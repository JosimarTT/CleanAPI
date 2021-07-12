using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CleanAPIContext _dbContext;
        public UserRepository(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }
    }
}
