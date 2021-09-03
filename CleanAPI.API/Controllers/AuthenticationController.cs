using CleanAPI.Core.DTOs;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Services;
using CleanAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        public AuthenticationController(IConfiguration configuration, IUserService userService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLoginDto login)
        {
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return NotFound();
        }

        private async Task<(bool, User)> IsValidUser(UserLoginDto login)
        {
            var user = await _userService.Login(login.UserName);
            var isValid = _passwordService.Validate(user.Password, login.Password);
            return (isValid, user);
        }

        private string GenerateToken(User user)
        {
            //header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role.Name)
            };
            //payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.Now.AddHours(9999)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
