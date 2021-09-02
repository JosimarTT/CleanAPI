﻿using CleanAPI.Core.Entities;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Repositories
{
    public interface ISecurityRepository : IBaseRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}