using CleanAPI.Core.Entities;
using System.Threading.Tasks;

namespace CleanAPI.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
