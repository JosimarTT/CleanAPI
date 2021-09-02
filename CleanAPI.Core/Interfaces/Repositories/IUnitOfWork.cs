using CleanAPI.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<Comment> CommentRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        void SaveChanges();
        Task SavechangesAsync();
    }
}
