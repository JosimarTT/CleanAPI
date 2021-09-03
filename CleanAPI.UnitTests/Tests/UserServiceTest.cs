using CleanAPI.Core.CustomEntities;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Core.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CleanAPI.UnitTests.Tests
{
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IOptions<PaginationOptions>> _paginationOptionsMock = new Mock<IOptions<PaginationOptions>>();

        public UserServiceTest()
        {
            _userService = new UserService(_unitOfWorkMock.Object, _paginationOptionsMock.Object);

        }

        [Fact]
        public async Task ShouldReturnAPost()
        {
            var userId = new Guid("9164cf6d-10c0-4b10-8797-8d70c771b371");
            var userName = "username";
            User newUser = new()
            {
                Id = userId,
                UserName = userName
            };

            _unitOfWorkMock.Setup(x => x.UserRepository.GetById(userId)).ReturnsAsync(newUser);

            var findUser = await _userService.GetById(userId);

            userId.Should().Be(findUser.Id);
            userName.Should().Be(findUser.UserName);
        }
    }
}
