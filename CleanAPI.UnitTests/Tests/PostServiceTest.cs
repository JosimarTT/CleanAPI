﻿using CleanAPI.Core.CustomEntities;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Core.Interfaces.Services;
using CleanAPI.Core.Services;
using CleanAPI.UnitTests.Mocks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CleanAPI.UnitTests.Tests
{
    public class PostServiceTest
    {
        private readonly PostService _postService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IOptions<PaginationOptions>> _paginationOptionsMock = new Mock<IOptions<PaginationOptions>>();

        public PostServiceTest()
        {
            _postService = new PostService(_unitOfWorkMock.Object, _paginationOptionsMock.Object);

        }

        [Fact]
        public async Task ShouldReturnAPost()
        {
            var postId = 1;
            var postDate = DateTime.Now;
            var postDescription = "description";
            var postImage = "image";

            Post newPost = new()
            {
                Id = postId,
                Date = postDate,
                Description = postDescription,
                Image = postImage
            };

            _unitOfWorkMock.Setup(x => x.PostRepository.GetById(postId)).ReturnsAsync(newPost);
            
            var post = await _postService.GetPost(postId);

            postId.Should().Be(post.Id);
            postDate.Should().Be(post.Date);
            postDescription.Should().Be(post.Description);
            postImage.Should().Be(post.Image);
        }
    }
}
