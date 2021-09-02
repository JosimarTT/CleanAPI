using CleanAPI.Core.CustomEntities;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Services;
using CleanAPI.Core.QueryFilters;
using Moq;
using System.Threading.Tasks;

namespace CleanAPI.UnitTests.Mocks
{
    class PostServiceMock : Mock<IPostService>
    {
        public PostServiceMock GetPosts(PagedList<Post> pagedList)
        {
            Setup(x => x.GetPosts(It.IsAny<PostQueryFilter>()))
                .Returns(pagedList);
            return this;
        }

        public PostServiceMock GetPost(Post post)
        {
            Setup(x => x.GetPost(It.IsAny<int>()))
                .ReturnsAsync(post);
            return this;
        }
    }
}
