using CleanAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}