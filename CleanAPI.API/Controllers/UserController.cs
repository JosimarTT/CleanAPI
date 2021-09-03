using AutoMapper;
using CleanAPI.API.Responses;
using CleanAPI.Core.DTOs;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Services;
using CleanAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UserController(IMapper mapper, IUserService userService, IPasswordService passwordService)
        {
            _mapper = mapper;
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] UserfilterDto filter)
        {
            var users = _userService.GetPaged(filter);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto) { };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Insert(UserLoginDto userLoginDto)
        {
            var user = _mapper.Map<User>(userLoginDto);
            user.Password = _passwordService.Hash(userLoginDto.Password);
            await _userService.Insert(user);
            userLoginDto = _mapper.Map<UserLoginDto>(user);
            var response = new ApiResponse<UserLoginDto>(userLoginDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(Guid id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;
            var result = await _userService.Update(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var result = await _userService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
