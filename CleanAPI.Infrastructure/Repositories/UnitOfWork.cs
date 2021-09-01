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
        private readonly ISecurityRepository _securityRepository;
        public UnitOfWork(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_dbContext);
        public IBaseRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_dbContext);
        public IBaseRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_dbContext);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_dbContext);

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SavechangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
