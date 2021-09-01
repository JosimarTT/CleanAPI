using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(CleanAPIContext dbContext) : base(dbContext) { }
        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entity.FirstOrDefaultAsync(x => x.User == login.User && x.Password == login.Password);
        }
    }
}
