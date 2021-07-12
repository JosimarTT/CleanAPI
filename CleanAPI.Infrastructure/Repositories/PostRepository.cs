using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(CleanAPIContext _dbContext) : base(_dbContext) { }
        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entity.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
