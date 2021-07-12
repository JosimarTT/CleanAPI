using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CleanAPIContext _dbContext;
        private readonly IPostRepository _postRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Comment> _commentRepository;
        public UnitOfWork(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_dbContext);

        public IBaseRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_dbContext);

        public IBaseRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_dbContext);

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
