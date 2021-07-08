using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly CleanAPIContext _dbContext;
        public PostRepository(CleanAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _dbContext.Posts.ToListAsync();
            return posts;
        }
    }
}
