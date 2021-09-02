﻿using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User> , IUserRepository
    {
        public UserRepository(CleanAPIContext context) : base(context) { }
    }
}
