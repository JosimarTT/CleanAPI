﻿using CleanAPI.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Post> PostRepository { get; }
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<Comment> CommentRepository { get; }

        void SaveChanges();
        Task SavechangesAsync();
    }
}