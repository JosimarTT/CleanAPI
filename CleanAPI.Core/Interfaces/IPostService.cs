using CleanAPI.Core.Entities;
using CleanAPI.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetPost(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}