using CleanAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUser(int userId);
    }
}
