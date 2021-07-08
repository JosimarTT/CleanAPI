using CleanAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
