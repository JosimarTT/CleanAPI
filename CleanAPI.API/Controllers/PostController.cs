using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }
    }
}
