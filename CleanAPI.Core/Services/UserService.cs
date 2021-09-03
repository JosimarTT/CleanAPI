using CleanAPI.Core.CustomEntities;
using CleanAPI.Core.DTOs;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Exceptions;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<User> Login(string userName)
        {
            return await _unitOfWork.UserRepository.Login(userName);
        }

        public PagedList<User> GetPaged(UserfilterDto filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? _paginationOptions.DefaultPageSize : filter.PageSize;

            var users = _unitOfWork.UserRepository.GetAll();
            if (filter.Id != Guid.Empty) users = users.Where(x => x.Id == filter.Id);
            if (!string.IsNullOrWhiteSpace(filter.UserName)) users = users.Where(x => x.UserName == filter.UserName);

            var paged = PagedList<User>.Create(users, filter.PageNumber, filter.PageSize);

            return paged;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task Insert(User user)
        {
            var findUser = await _unitOfWork.UserRepository.GetById(user.Id);
            if (findUser != null)
                throw new BusinessException("Username already taken");
            user.RoleId = new Guid("9164cf6d-10c0-4b10-8797-8d70c771b371");
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SavechangesAsync();
        }

        public async Task<bool> Update(User user)
        {
            User editUser = await _unitOfWork.UserRepository.GetById(user.Id);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            _unitOfWork.UserRepository.Update(editUser);
            await _unitOfWork.SavechangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SavechangesAsync();
            return true;
        }
    }
}
