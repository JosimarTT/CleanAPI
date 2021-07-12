using CleanAPI.Core.Entities;
using CleanAPI.Core.Exceptions;
using CleanAPI.Core.Interfaces;
using CleanAPI.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAPI.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public IEnumerable<Post> GetPosts(PostQueryFilter filters)
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            if (filters.UserId != null) posts = posts.Where(x => x.UserId == filters.UserId);
            if (filters.Date > DateTime.MinValue) posts = posts.Where(x => x.Date == filters.Date);
            if (!string.IsNullOrWhiteSpace(filters.Description)) posts = posts.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));

            return posts;
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
                throw new BusinessException("User does not exist");

            var userPosts = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if (userPosts.Count() < 10)
            {
                var lastPost = userPosts.OrderByDescending(x => x.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("You are not enable to publish");
                }
            }
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SavechangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SavechangesAsync();
            return true;
        }
    }
}
