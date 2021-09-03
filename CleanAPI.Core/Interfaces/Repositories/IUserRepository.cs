using CleanAPI.Core.DTOs;
using CleanAPI.Core.Entities;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Login(string userName);
    }
}