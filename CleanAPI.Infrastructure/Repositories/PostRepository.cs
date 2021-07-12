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

        public async Task<Post> GetPost(int id)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }

        public async Task InsertPost(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.PostId);
            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPost(id);
            _dbContext.Posts.Remove(currentPost);

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
