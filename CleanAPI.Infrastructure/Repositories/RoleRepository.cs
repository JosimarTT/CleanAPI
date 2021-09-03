using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Infrastructure.Data;

namespace CleanAPI.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(CleanAPIContext context) : base(context) { }
    }
}
