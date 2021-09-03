using CleanAPI.Infrastructure.Interfaces;
using CleanAPI.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace CleanAPI.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _passwordOptions;
        public PasswordService(IOptions<PasswordOptions> passwordOptions)
        {
            _passwordOptions = passwordOptions.Value;
        }
        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, _passwordOptions.SaltSize, _passwordOptions.Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_passwordOptions.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{_passwordOptions.Iterations}.{salt}.{key}";
            }
        }

        public bool Validate(string hash, string password)
        {
            var parts = hash.Split('.');
            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                var keyToCheck = algorithm.GetBytes(_passwordOptions.KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }
    }
}
