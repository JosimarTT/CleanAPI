using CleanAPI.Core.CustomEntities;
using CleanAPI.Core.DTOs;
using CleanAPI.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> Login(string userName);
        PagedList<User> GetPaged(UserfilterDto filter);
        Task<User> GetById(Guid guid);
        Task Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(Guid guid);
    }
}
