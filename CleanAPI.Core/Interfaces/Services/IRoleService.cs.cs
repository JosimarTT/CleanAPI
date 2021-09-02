using CleanAPI.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Services
{
    interface IRoleService
    {
        Task<User> GetById(Guid guid);
        Task Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(Guid guid);
    }
}
